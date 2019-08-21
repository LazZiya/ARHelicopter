using UnityEngine;
using System.Collections;
	
public class HelicopterScript : MonoBehaviour
{
	
	Animator anim;
	GameObject heli;
	Transform LargeBlades;
	Transform SmallBlades;
	
	public bool start = false;
	public float spinSpeed = 0.0f;
	public float flyingHeight = 0.0f;
	public Vector2 pr; //pitch-rol
	
	int startHash = Animator.StringToHash ("Start");
	int rolHash = Animator.StringToHash ("Rol");
	int pitchHash = Animator.StringToHash ("Pitch");
	int spinSpeedHash = Animator.StringToHash ("SpinSpeed");
	int rolStraightHash = Animator.StringToHash ("RolStraight");
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		heli = GameObject.Find ("HelicopterObj");
		LargeBlades = heli.transform.FindChild ("Helicopter/LargeBlades");
		SmallBlades = heli.transform.FindChild ("Helicopter/SmallBlades");
		
		pr.Set (0, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (start)
			RotateBlades ();
		
		if (flyingHeight > 10) {
			pr.Set (CCTextureScript.CCValue.x, CCTextureScript.CCValue.y);
	
			Rol (pr.x);
			Pitch (pr.y);
			Yaw (pr.x);
		}
		
		SetValues ();
	}
	
	void RotateBlades ()
	{
		spinSpeed = spinSpeed < 25.0f ? spinSpeed + 5 * Time.deltaTime : 25.0f;
		
		LargeBlades.Rotate (Vector3.forward, spinSpeed);
		SmallBlades.Rotate (Vector3.left, spinSpeed);
	}
	
	void SetValues ()
	{
		anim.SetBool (startHash, start);
					anim.SetFloat (spinSpeedHash, spinSpeed);
	}
	
	void Up ()
	{
		start = true;
		
		if (spinSpeed > 10) {
			heli.transform.Translate (Vector3.up * 2 * Time.deltaTime, Space.World);
			flyingHeight++;
		}
	}
	
	void Down ()
	{
		
		if ((spinSpeed > 10) && (flyingHeight > 0.0f)) {
			heli.transform.Translate (-Vector3.up * 2 * Time.deltaTime, Space.World);
			flyingHeight--;
		}
	}
	
	void Rol (float value)
	{
		anim.SetFloat (rolHash, value);
	}
	
	void Pitch (float value)
	{
		anim.SetFloat (pitchHash, value);
		
		heli.transform.Translate (Vector3.back * value * Time.deltaTime, Space.Self);
	}
	
	void Yaw (float value)
	{
		transform.Rotate (Vector3.up, value);
	}
	
	void RolStraight (float dir)
	{
		if (flyingHeight > 10) {
			anim.SetFloat (rolStraightHash, dir * 0.7f);
			heli.transform.Translate (Vector3.left * dir * Time.deltaTime, Space.Self);
		}
	}
	
	void BalancePos ()
	{
		anim.SetFloat (rolStraightHash, 0);
	}
}