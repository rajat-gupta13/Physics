﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ShowStats : MonoBehaviour {

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (name + " Inertia: " +rigidBody.inertiaTensor);
		Debug.Log (name + " COM: " + rigidBody.centerOfMass);
	}
}
