using UnityEngine;
using System.Collections;

public class TouchDetector : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.touches.Length>0){
			for(int i=0; i<Input.touchCount;i++){
				if(this.GetComponent<GUITexture>().HitTest(Input.GetTouch (i).position)){
					
					switch(Input.GetTouch (i).phase){
					case TouchPhase.Began:
					case TouchPhase.Moved:
					case TouchPhase.Stationary:
						this.GetComponent<GUITexture>().SendMessage("OnTouching", Input.GetTouch (i));
						break;
						
					case TouchPhase.Canceled:
					case TouchPhase.Ended:
					default:
						this.GetComponent<GUITexture>().SendMessage("OnReleasing", Input.GetTouch (i));
						break;
					}
				}
			}
		}
	}
}
