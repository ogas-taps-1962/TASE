using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YawChange : AngleAbout
{
    private HingeJoint theYaw;
    private Transform cameraPlace;
    private Transform carPlace;
    private JointSpring yawTarget;
    private void ChangeX(Vector3 PtargetXZ,Vector3 PbaseXZ)
    {
        float temTarget = VectorXZToAngle(PtargetXZ);
        float temBase = VectorXZToAngle(PbaseXZ);
        float temAngle = temTarget - temBase;
        while (temAngle >= 360f)
        {
            temAngle -= 360f;
        }
        while (temAngle <= 0f)
        {
            temAngle += 360f;
        }

        if (temAngle >= 180f)
        {
            temAngle -= 360f;
        }
        yawTarget.targetPosition = temAngle;
        theYaw.spring = yawTarget;
    }
    void Awake()
    {
        theYaw = this.GetComponent<HingeJoint>();
        cameraPlace = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        carPlace = GameObject.FindWithTag("Player").GetComponent<Transform>();
        yawTarget = theYaw.spring;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeX(cameraPlace.forward,carPlace.forward);
    }
}
