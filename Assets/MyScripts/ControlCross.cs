using UnityEngine;
using System.Collections;

public class ControlCross : MonoBehaviour
{
    public GUITexture goUp;
    public GUITexture goDown;
    public GUITexture goLeft;
    public GUITexture goRight;
    public GUITexture goCenter;

    private enum RectPos { Left, Right, Up, Down, Center };

    // Use this for initialization
    void Start()
    {
        goLeft.GetComponent<GUITexture>().pixelInset = GetRectPos(RectPos.Left);
        goRight.GetComponent<GUITexture>().pixelInset = GetRectPos(RectPos.Right);
        goUp.GetComponent<GUITexture>().pixelInset = GetRectPos(RectPos.Up);
        goDown.GetComponent<GUITexture>().pixelInset = GetRectPos(RectPos.Down);
        goCenter.GetComponent<GUITexture>().pixelInset = GetRectPos(RectPos.Center);
    }

    Rect GetRectPos(RectPos rPos)
    {
        int sizeFactor = 13;
        int btnLRWidth = Screen.width / sizeFactor;
        int btnLRHeight = Screen.height / sizeFactor;

        Rect pos = new Rect();

        switch (rPos)
        {
            case RectPos.Left:
                pos.Set(20, btnLRWidth + 20, btnLRWidth, btnLRHeight);
                break;

            case RectPos.Right:
                pos.Set(20 + btnLRWidth + btnLRHeight, btnLRWidth + 20, btnLRWidth, btnLRHeight);
                break;

            case RectPos.Up:
                pos.Set(20 + btnLRWidth, btnLRWidth + btnLRHeight + 20, btnLRHeight, btnLRWidth);
                break;

            case RectPos.Down:
                pos.Set(20 + btnLRWidth, 20, btnLRHeight, btnLRWidth);
                break;

            case RectPos.Center:
                pos.Set(20 + btnLRWidth, btnLRWidth + 20, btnLRHeight, btnLRHeight);
                break;
        }

        return pos;
    }
}
