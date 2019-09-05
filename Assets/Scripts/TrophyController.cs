﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyController : MonoBehaviour {
	public Vector3 rotationAngle;
	public float rotationSpeed;

	void Update () {
		transform.Rotate (rotationAngle * rotationSpeed * Time.deltaTime);
	}
}
