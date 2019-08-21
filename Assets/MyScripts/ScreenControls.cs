using UnityEngine;
using System.Collections;

public class ScreenControls : MonoBehaviour {

	public static string detectionText = "searching...";
	public static bool blinkText = true;
	
	void OnGUI () {
		GUIStyle gStyle = new GUIStyle ();
		gStyle.richText = true;
	}
}
