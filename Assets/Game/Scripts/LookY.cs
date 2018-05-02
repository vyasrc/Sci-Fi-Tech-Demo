using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float _MouseY = Input.GetAxis("Mouse Y");
		Vector3 newRotation = transform.localEulerAngles;
		newRotation.x += _MouseY;
		transform.localEulerAngles = newRotation;
	}
}
