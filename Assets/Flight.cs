using UnityEngine;
using System.Collections;

public class Flight : MonoBehaviour {
	public float forward = 1,
			   	 roll = 1,
				 lift = 1,
				 drag = 0.1f;

	float velocity = 0;

	void Update() {
		if(Input.GetButton("Jump"))
			transform.Rotate(lift, 0, 0, Space.Self);
		if(Input.GetButton("Fire3"))
			transform.Rotate(-lift, 0, 0, Space.Self);
		velocity += Input.GetAxis("Vertical") * forward;
		velocity *= drag;
		transform.Rotate(0, 0, Input.GetAxis("Horizontal") * roll, Space.Self);
		transform.Translate(0, 0, -velocity, Space.Self);
	}
}
