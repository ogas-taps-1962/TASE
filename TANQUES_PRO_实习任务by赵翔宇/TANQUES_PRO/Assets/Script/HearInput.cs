using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HearInput : MonoBehaviour
{ 
	public delegate void EventHandler<TEventArgs>(object Psender, TEventArgs Pe) 
		where TEventArgs : EventArgs;

	public class AxisArgs : System.EventArgs
	{
		public float SaxisNow { get; set; }
		public AxisArgs(float PaxisNow) 
		{
			SaxisNow = PaxisNow;
		}
	}
	public class SwitchArgs : System.EventArgs
	{
		public bool SswitchNow { get; set; }
		public KeyCode SkeyPlace { get; set; }
		public SwitchArgs(bool PswitchNow, KeyCode PkeyPlace) 
		{
			SswitchNow = PswitchNow;
			SkeyPlace = PkeyPlace;
		}
	}
	
	public static event EventHandler<SwitchArgs> EpressMove = delegate(object Psender, SwitchArgs Pargs) {  };
	public static event EventHandler<EventArgs> Epress1 = delegate(object Psender, EventArgs Pargs) {  };
	public static event EventHandler<EventArgs> Epress3 = delegate(object Psender, EventArgs Pargs) {  };
	public static event EventHandler<EventArgs> EpressR = delegate(object Psender, EventArgs Pargs) {  }; 
	public static event EventHandler<EventArgs> EpressV = delegate(object Psender, EventArgs Pargs) {  };
	public static event EventHandler<EventArgs> Eclick = delegate(object Psender, EventArgs Pargs) {  };
	public static event EventHandler<AxisArgs> EmouseX = delegate(object Psender, AxisArgs Pargs) {  };
	public static event EventHandler<AxisArgs> EmouseY = delegate(object Psender, AxisArgs Pargs) {  }; 
	public static event EventHandler<AxisArgs> EmouseW = delegate(object Psender, AxisArgs Pargs) {  };
	//按键监听的事件
	private void Hear()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			EpressMove?.Invoke(this,new SwitchArgs(true,KeyCode.W));
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			EpressMove?.Invoke(this,new SwitchArgs(true,KeyCode.A));
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			EpressMove?.Invoke(this,new SwitchArgs(true,KeyCode.S));
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			EpressMove?.Invoke(this,new SwitchArgs(true,KeyCode.D));
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			EpressMove?.Invoke(this,new SwitchArgs(true,KeyCode.Q));
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			EpressMove?.Invoke(this,new SwitchArgs(true,KeyCode.E));
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			EpressMove?.Invoke(this,new SwitchArgs(false,KeyCode.W));
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			EpressMove?.Invoke(this,new SwitchArgs(false,KeyCode.A));
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			EpressMove?.Invoke(this,new SwitchArgs(false,KeyCode.S));
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			EpressMove?.Invoke(this,new SwitchArgs(false,KeyCode.D));
		}
		if (Input.GetKeyUp(KeyCode.Q))
		{
			EpressMove?.Invoke(this,new SwitchArgs(false,KeyCode.Q));
		}
		if (Input.GetKeyUp(KeyCode.E))
		{
			EpressMove?.Invoke(this,new SwitchArgs(false,KeyCode.E));
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Epress1?.Invoke(this,EventArgs.Empty);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			Epress3?.Invoke(this,EventArgs.Empty);
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			EpressR?.Invoke(this,EventArgs.Empty);
		}
		if (Input.GetKeyDown(KeyCode.V))
		{
			EpressV?.Invoke(this,EventArgs.Empty);
		}
		if (Input.GetKey(KeyCode.Mouse0))
		{
			Eclick?.Invoke(this,EventArgs.Empty);
		}
		if (Input.GetAxis("Mouse X") != 0)
		{
			EmouseX?.Invoke(this,new AxisArgs(Input.GetAxis("Mouse X")));
		}
		if (Input.GetAxis("Mouse Y") != 0)
		{
			EmouseY?.Invoke(this,new AxisArgs(Input.GetAxis("Mouse Y")));
		}
		if (Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			EmouseW?.Invoke(this,new AxisArgs(Input.GetAxis("Mouse ScrollWheel")));
		}
	}
	void Update()
	{
		Hear();
	}
}


