using UnityEngine;
using System.Collections;

public class NavigationArrowScript : MonoBehaviour {

	// Use this for initialization
	void OnTouching(Touch t){
		switch(this.name){
			case "goLeft":
				HelicopterControllerScript.RolLeft();
				break;
			case "goRight":
				HelicopterControllerScript.RolRight ();
				break;
				
			case "goUp":
			case "goCenter":
				HelicopterControllerScript.Up ();
				break;
				
			case "goDown":
				HelicopterControllerScript.Down ();
				break;
		}
	}
	
	void OnReleasing(Touch t){
		HelicopterControllerScript.BalancePos ();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            HelicopterControllerScript.Up();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HelicopterControllerScript.Down();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HelicopterControllerScript.RolRight();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HelicopterControllerScript.RolLeft();
        }

    }
}
