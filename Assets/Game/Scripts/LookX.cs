using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour {

	[SerializeField]
	private float _sensitivity = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float _MouseX = Input.GetAxis("Mouse X");
		Vector3 newRotation = transform.localEulerAngles;
		newRotation.y += _MouseX * _sensitivity;
		transform.localEulerAngles = newRotation;
	}
}
