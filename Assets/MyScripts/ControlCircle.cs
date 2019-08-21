using UnityEngine;
using System.Collections;

public class ControlCircle : MonoBehaviour
{
    public Texture ccImage;
    public Texture redDot;

    Vector2 touchPos;

    float rdRadius;
    Vector2 rdPos;
    Vector2 rdPivot; //the pivot position during movement
    Vector2 rdOrigin; //the pivot fixed zero point position for red dot
    Vector2 rdDistance; //distance of touch from the control circle center

    public float ccRadius; //radius of the control circle
    Vector2 ccPos;
    Vector2 ccPivot;

    public static Vector2 CCValue;

    bool InCircle = false; //detects if the touch is inside the control circle

    void Start()
    {
        //set size and pos for control circle
        ccRadius = Screen.height / 5;
        ccPos = new Vector2();
        ccPos.x = Screen.width - (ccRadius * 2) - 20;
        ccPos.y = Screen.height - (ccRadius * 2) - 20;

        ccPivot = new Vector2();
        ccPivot.x = ccPos.x + ccRadius;
        ccPivot.y = ccRadius + 20;

        //set size and pos for red dot
        rdRadius = ccRadius / 6;
        rdPos = new Vector2();
        rdPos.x = ccPos.x + ccRadius - rdRadius;
        rdPos.y = ccPos.y + ccRadius - rdRadius;

        rdPivot = GetRDPivot();
        rdOrigin = GetRDOrigin();

        touchPos = new Vector2();
        rdDistance = new Vector2();
        CCValue = new Vector2(0f, 0f);
    }

    void Update()
    {
        StartCoroutine(GetTouchPos());

        InCircle = Vector2.Distance(touchPos, ccPivot) <= ccRadius ? true : false;

        rdPivot = GetRDPivot();
        rdDistance = rdPivot - ccPivot;

        rdPos = InCircle
            ? Vector2.Lerp(rdPos, SetRDPos(), Time.deltaTime)
                : Vector2.Lerp(rdPos, rdOrigin, Time.deltaTime);

        CCValue = SetCCValue();
    }

    Vector2 SetCCValue()
    {
        return new Vector2(
            rdDistance.x / ccRadius,
            rdDistance.y / ccRadius);
    }

    Vector2 GetRDPivot()
    {
        return new Vector2(
            rdPos.x + rdRadius,
            Screen.height - rdPos.y - rdRadius);
    }

    Vector2 GetRDOrigin()
    {
        return new Vector2(
            rdPos.x,
            rdPos.y);
    }

    IEnumerator GetTouchPos()
    {
        foreach (Touch t in Input.touches)
        {
            switch (t.phase)
            {
                case TouchPhase.Began:
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    touchPos.Set(t.position.x, t.position.y);
                    break;

                default:
                    touchPos.Set(rdOrigin.x, rdOrigin.y);
                    break;
            }

            yield return null;
        }
    }

    Vector2 SetRDPos()
    {
        return new Vector2(
            touchPos.x - rdRadius,
            Screen.height - touchPos.y - rdRadius);
    }

    void OnGUI()
    {
        GUI.RepeatButton(new Rect(ccPos.x, ccPos.y, ccRadius * 2, ccRadius * 2), ccImage, new GUIStyle());
        GUI.Button(new Rect(rdPos.x, rdPos.y, rdRadius * 2, rdRadius * 2), redDot, new GUIStyle());
    }
}
