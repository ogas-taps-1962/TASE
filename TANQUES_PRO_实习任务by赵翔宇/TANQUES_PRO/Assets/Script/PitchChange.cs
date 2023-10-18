using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchChange : AngleAbout
{
    private HingeJoint thePitch;
    private Transform cameraPlace;
    private JointSpring pitchTarget;
    private float wFix;

    public delegate void EventHandler<TEventArgs>(object Psender, TEventArgs Pe)
        where TEventArgs : EventArgs;
    public class MilArgs : System.EventArgs
    {
        public float SmilNow { get; set; }
        public MilArgs(float PmilNow) 
        {
            SmilNow = PmilNow;
        }
    }

    public static event EventHandler<MilArgs> EchangeMil = delegate(object Psender, MilArgs Pargs) { };
    
    private void TurnW(object Pobject, HearInput.AxisArgs PaxisArgs)
    {
        wFix += PaxisArgs.SaxisNow*10f;
        if (wFix > 40f)
        {
            wFix = 40f;
        }
        if (wFix < 0f)
        {
            wFix = 0f;
        }
        EchangeMil?.Invoke(this,new MilArgs(wFix));
    }

    private void ChangeY(float PtargetY)
    {
        float temAngle = (float)Math.Asin(PtargetY) / (float)Math.PI * 180f + wFix;
        if (temAngle > 45f)
        {
            temAngle = 45f;
        }
        if (temAngle < -5f)
        {
            temAngle = -5f;
        }
        pitchTarget.targetPosition = temAngle;
        thePitch.spring = pitchTarget;
    }
    // Start is called before the first frame update
    void Awake()
    {
        wFix = 0f;
        thePitch = this.GetComponent<HingeJoint>();
        cameraPlace = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        pitchTarget = thePitch.spring;
        HearInput.EmouseW += 
            this.TurnW;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeY(cameraPlace.forward.y);
    }
}
