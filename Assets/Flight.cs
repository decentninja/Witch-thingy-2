using UnityEngine;
using System.Collections;

public class Flight : MonoBehaviour {
	public float forward = 1,
				 lift = 1,
				 drag = 0.1f,
				 turnspeed = 0.1f;

	public Transform camera;
	public Transform model;

	void Update() {
		var old = model.rotation;
		model.LookAt(model.position - camera.forward * 1000000);
		model.rotation = Quaternion.Lerp(old, model.rotation, turnspeed);
		float velocity = Input.GetAxis("Vertical") * forward;
		transform.Translate(camera.forward * velocity);
	}
}
