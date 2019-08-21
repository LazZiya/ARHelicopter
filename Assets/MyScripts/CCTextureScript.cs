using UnityEngine;
using System.Collections;

public class CCTextureScript : MonoBehaviour
{
    private float ccRadius; //radius of the control circle
    private Vector2 ccPos;
    private Vector2 ccPivot;

    private Vector2 rdPos;
    private float rdRadius;
    private Vector2 rdOrigin; //the pivot fixed zero point position for red dot
    private Vector2 rdDistance; //distance of touch from the control circle center

    private Vector2 moveRedDotTo;

    public GUITexture redDot;
    private bool InCircle;

    public static Vector2 CCValue;

    //the pivot position during movement
    private Vector2 rdPivot
    {
        get
        {
            return new Vector2(rdPos.x + rdRadius, rdPos.y + rdRadius);
        }
    }

    // Use this for initialization
    void Start()
    {
        SetupControlCircle();
        SetupRedDot();
    }

    void SetupControlCircle()
    {
        //set size and pos for control circle
        ccRadius = Screen.height / 5;
        ccPos = new Vector2();
        ccPos.x = Screen.width - (ccRadius * 2) - 20;
        ccPos.y = 20;

        ccPivot = new Vector2();
        ccPivot.x = ccPos.x + ccRadius;
        ccPivot.y = ccRadius + 20;

        transform.position = Vector3.zero;
        transform.localScale = Vector3.zero;
        GetComponent<GUITexture>().pixelInset = new Rect(ccPos.x, ccPos.y, ccRadius * 2, ccRadius * 2);
    }

    void SetupRedDot()
    {
        //set size and pos for red dot
        rdRadius = ccRadius / 6;
        rdPos = new Vector2();
        rdPos.x = ccPos.x + ccRadius - rdRadius;
        rdPos.y = ccPos.y + ccRadius - rdRadius;

        rdOrigin = new Vector2(rdPos.x, rdPos.y);

        redDot.transform.position = Vector3.zero;
        redDot.transform.localScale = Vector3.zero;
        redDot.GetComponent<GUITexture>().pixelInset = new Rect(rdPos.x, rdPos.y, rdRadius * 2, rdRadius * 2);

        //do this to fix the red dot position at start
        //and prevent it from moving to the corner of the screen
        moveRedDotTo = rdPos;
    }

    // Update is called once per frame
    void OnTouching(Touch t)
    {
        InCircle = Vector2.Distance(t.position, ccPivot) <= ccRadius ? true : false;

        if (InCircle)
            moveRedDotTo = t.position;
    }

    void OnReleasing()
    {
        moveRedDotTo = rdOrigin;
    }

    void Update()
    {
        //PC control code
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveRedDotTo = new Vector2(ccPivot.x, ccPivot.y + ccRadius);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            moveRedDotTo = new Vector2(ccPivot.x - ccRadius, ccPivot.y - rdRadius * 2);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRedDotTo = new Vector2(ccPivot.x + ccRadius, ccPivot.y - rdRadius * 2);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            moveRedDotTo = new Vector2(ccPivot.x, ccPivot.y - ccRadius);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            moveRedDotTo = rdOrigin;
        }

        if (moveRedDotTo != rdPos)
        {
            rdDistance = rdPivot - ccPivot;
            rdPos = Vector2.Lerp(rdPos, moveRedDotTo, Time.deltaTime);
            redDot.GetComponent<GUITexture>().pixelInset = new Rect(rdPos.x, rdPos.y, rdRadius * 2, rdRadius * 2);
        }

        CCValue = SetCCValue();
    }

    Vector2 GetRDPivot()
    {
        return new Vector2(
            rdPos.x + rdRadius,
            rdPos.y + rdRadius);
    }

    Vector2 SetCCValue()
    {
        return new Vector2(
            rdDistance.x / ccRadius,
            rdDistance.y / ccRadius);
    }
}
