using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRoll : AIbase
{
    private HingeJoint theJoint;
    private Vector3 theWay;
    private JointSpring theSpring;
    public float temChance;
    private void TheRoll()
    {
        theWay = _thePlayer.position - _itsTransform.position;
        theSpring.targetPosition = VectorXZToAngle(theWay)-temChance;
        while (theSpring.targetPosition >= 360f)
        {
            theSpring.targetPosition -= 360f;
        }
        while (theSpring.targetPosition <= 0f)
        {
            theSpring.targetPosition += 360f;
        }

        if (theSpring.targetPosition >= 180f)
        {
            theSpring.targetPosition -= 360f;
        }
        theJoint.spring = theSpring;
    }
    protected override void Awake()
    {
        base.Awake();
        theJoint = this.GetComponent<HingeJoint>();
        theSpring = theJoint.spring;
    }

    private void FixedUpdate()
    {
        TheRoll();
    }
}
