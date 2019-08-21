using UnityEngine;
using System.Collections;

public class HelicopterControllerScript : MonoBehaviour {

	private static GameObject hel;

	// Use this for initialization
	void Start () {
		hel = GameObject.Find ("HelicopterObj");
	}
	
	public static void Up() {
		hel.SendMessage ("Up");
	}

	public static void Down() {
		hel.SendMessage ("Down");
	}

	public static void RolLeft(){
		hel.SendMessage ("RolStraight", -1);
	}

	public static void RolRight() {
		hel.SendMessage ("RolStraight", 1);
	}

	public static void BalancePos(){
		hel.SendMessage ("BalancePos");
	}
}
