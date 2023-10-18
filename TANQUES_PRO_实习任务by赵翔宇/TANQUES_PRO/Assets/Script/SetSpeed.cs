using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpeed : AngleAbout
{
	private short theGear;
	private short frontOrBack;
	private short leftOrRight;
	private short clockwiseOrNot;
	private Transform cameraPlace;
	private Vector3 targetSpeed;
	private bool lookLock;
	private Vector3 temTarget;

	public bool SlookLock
	{
		get
		{
			return lookLock;
		}
	}
	
	public delegate void EventHandler<TEventArgs>(object Psender, TEventArgs Pe)
		where TEventArgs : EventArgs;
	public class GearArgs : System.EventArgs
	{
		public short SgearNow { get; set; }
		public GearArgs(short PgearNow) 
		{
			SgearNow = PgearNow;
		}
	}
	public class SpeedArgs : System.EventArgs
	{
		public Vector3 SspeedNow { get; set; }
		public short Sclockwise { get; set; }
		public bool Stype { get; set; }
		public SpeedArgs(Vector3 PspeedNow,short Pclockwise,bool Ptype) 
		{
			SspeedNow = PspeedNow;
			Sclockwise = Pclockwise;
			Stype = Ptype;
		}
	}

	public static event EventHandler<GearArgs> EchangeGear = delegate(object Psender, GearArgs Pargs) { };
	public static event EventHandler<SpeedArgs> EchangeSpeed = delegate(object Psender, SpeedArgs Pargs) { };

	private void ChangeLook(object Pobject, EventArgs PeventArgs)
	{
		lookLock = !lookLock;
	}
	private void ChangeTarget(bool Ptype)
	{
		if (!lookLock)
		{
			 temTarget = new Vector3(-leftOrRight, 0, -frontOrBack);
		}
		else
		{
			Vector3 temForward = cameraPlace.forward;
			temForward.y = 0;
			temForward = temForward.normalized;
			Vector3 temRight = Quaternion.Euler(0f, 90f, 0) * temForward;
			temTarget = temForward * frontOrBack + temRight * leftOrRight;
		}
		
		targetSpeed = temTarget * (float)(theGear * 2f + 6f);
		EchangeSpeed?.Invoke(this, new SpeedArgs(targetSpeed, clockwiseOrNot,Ptype));
		
	}
	private void AddG(object Pobject, EventArgs PgearArgs)
	{
		if (theGear < 6)
		{
			theGear++;
			EchangeGear?.Invoke(this,new GearArgs(theGear));
		}
		ChangeTarget(true);
	}
	
	private void MinusG(object Pobject, EventArgs PgearArgs)
	{
		if (theGear > 1)
		{
			theGear--;
			EchangeGear?.Invoke(this,new GearArgs(theGear));
		}
		ChangeTarget(true);
	}

	
	private void ChangeWay(object Pproject, HearInput.SwitchArgs PswitchArgs)
	{
		switch (PswitchArgs.SkeyPlace)
		{
			case KeyCode.W:
				if (PswitchArgs.SswitchNow)
				{
					frontOrBack++;
				}
				else
				{
					frontOrBack--;
				}
				break;
			case KeyCode.S:
				if (PswitchArgs.SswitchNow)
				{
					frontOrBack--;
				}
				else
				{
					frontOrBack++;
				}
				break;
			case KeyCode.A:
				if (PswitchArgs.SswitchNow)
				{
					leftOrRight--;
				}
				else
				{
					leftOrRight++;
				}
				break;
			case KeyCode.D:
				if (PswitchArgs.SswitchNow)
				{
					leftOrRight++;
				}
				else
				{
					leftOrRight--;
				}
				break;
			case KeyCode.Q:
				if (PswitchArgs.SswitchNow)
				{
					clockwiseOrNot--;
				}
				else
				{
					clockwiseOrNot++;
				}
				break;
			case KeyCode.E:
				if (PswitchArgs.SswitchNow)
				{
					clockwiseOrNot++;
				}
				else
				{
					clockwiseOrNot--;
				}
				break;
		}
		ChangeTarget(true);
	}

	void Awake()
	{
		lookLock = true;
		theGear = 1;
		frontOrBack = 0;
		leftOrRight = 0;
		clockwiseOrNot = 0;
		cameraPlace = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
		HearInput.Epress1 += this.MinusG;
		HearInput.Epress3 += this.AddG;
		HearInput.EpressMove += this.ChangeWay;
		HearInput.EpressR += ChangeLook;
	}

	private void FixedUpdate()
	{
		ChangeTarget(false);
	}
}
