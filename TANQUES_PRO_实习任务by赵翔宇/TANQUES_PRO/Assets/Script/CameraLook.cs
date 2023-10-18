using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraLook : AngleAbout
{
	private Transform cameraItself;
	private Transform carPlace;
	private Vector3 freshView;
	private float sensitivity;
	private Vector3 vFix;
	private float aFix;//处理水平面的旋转
	private float rFix;//处理垂直面的旋转
	private float bFix;//水平面应占用长度

	private void Roll(float Pangle,bool Pt)//true为X轴
	{
		if (Pt)
		{
			aFix += Pangle;
			while (aFix >= 360)
			{
				aFix -= 360;
			}
			while (aFix < 0)
			{
				aFix += 360;
			}

			float temFix = (aFix / 180) * (float)Math.PI;
			vFix.x = bFix * (float)Math.Sin(temFix);
			vFix.z = bFix * (float)Math.Cos(temFix);
		}
		else
		{
			rFix += Pangle;
			while (aFix >= 360)
			{
				aFix -= 360;
			}
			while (aFix < 0)
			{
				aFix += 360;
			}

			float temFix = (rFix / 180) * (float)Math.PI;
			vFix.y = 0.2f * (float)Math.Sin(temFix) + 0.35f;
			bFix = 0.2f * (float)Math.Cos(temFix);
		}
	}
	private void TurnX(object Pobject,HearInput.AxisArgs PaxisArgs)
	{
		freshView = new Vector3(0,PaxisArgs.SaxisNow*sensitivity,0);
		cameraItself.Rotate(freshView,Space.World);
		Roll(PaxisArgs.SaxisNow * sensitivity,true);
	} //X轴调整的方法
	private void TurnY(object Pobject,HearInput.AxisArgs PaxisArgs)
	{
		freshView = new Vector3(PaxisArgs.SaxisNow * sensitivity, 0, 0);
		cameraItself.Rotate(freshView);
		Roll(PaxisArgs.SaxisNow * sensitivity,false);
	} //Y轴相同

	private void CameraFollow()
	{
		Vector3 temPosition = carPlace.position;
		temPosition += vFix;
		cameraItself.position = temPosition;
	}//摄像机悬浮在炮塔后方
	// Start is called before the first frame update
	void Awake()
	{
		vFix = new Vector3(0f,0.5f,0.2f);
		aFix = 0f;
		rFix = 0f;
		bFix = 0.2f;
		sensitivity = 5f;
		carPlace = GameObject.FindWithTag("Player").transform;
		cameraItself = gameObject.transform;
		HearInput.EmouseX += this.TurnX;
		HearInput.EmouseY += this.TurnY;
	}

	private void Update()
	{
		CameraFollow();
	}
}

