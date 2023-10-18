using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShow : AngleAbout
{
	private Transform cameraPlace;
	private Transform bodyPlace;
	private Transform canonPlace;
	private Transform bodyShow;
	private Transform canonShow;

	private void showPosition()
	{
		bodyShow.eulerAngles = new Vector3(0f, 0f, VectorXZToAngle(cameraPlace.forward) - VectorXZToAngle(bodyPlace.forward));
		canonShow.eulerAngles = new Vector3(0f, 0f, VectorXZToAngle(cameraPlace.forward) - VectorXZToAngle(canonPlace.forward));
	}

	private void Awake()
	{
		cameraPlace = GameObject.Find("Camera").GetComponent<Transform>();
		bodyPlace = GameObject.Find("保护网").GetComponent<Transform>();
		canonPlace = GameObject.Find("网布_2").GetComponent<Transform>();
		bodyShow = GameObject.Find("position_body").GetComponent<Transform>();
		canonShow = GameObject.Find("position_canon").GetComponent<Transform>();
	}

	private void FixedUpdate()
	{
		showPosition();
	}
}
