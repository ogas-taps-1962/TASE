using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : AIbase
{

    private Vector3 theWay;
    private Vector3 target;
    private float theVer;

    private void MoveIt()
    {
        target = _thePlayer.position - _itsTransform.position;
        target.y = 0;
        theVer = Vector3.Angle(target, theWay);
        if (theVer > 90)
        {
            _itsRigidbody.AddRelativeForce(new Vector3(0,0,10f));
        }
        else
        {
            _itsRigidbody.AddRelativeForce(new Vector3(0,0,-10f));
        }
        
    }
    protected override void Awake()
    {
        base.Awake();
        theWay = _itsTransform.forward;
    }

    private void FixedUpdate()
    {
        MoveIt();
    }
}
