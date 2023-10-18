using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class TireMove : MonoBehaviour
{
    private enum Tire
    {
        lf = 0,
        lb = 1,
        rf = 2,
        rb = 3
    };
    public short tireType;
    public static float _rollSpeed=10000000f;
    public static Vector3 _rfWay = new Vector3(1f, 0, 1f).normalized;
    public static Vector3 _lfWay = new Vector3(-1f, 0, 1f).normalized;
    public static float _kP=0.5f, _kI=0.0002f, _kD=0.0002f;
    private Rigidbody tireItself;
    private Vector3 speedDifference,targetSpeed,theForce;
    private short clockwiseOrNot;
    private float numberDifference,preNumberDifference,addNumberDifference,deltaNumberDifference,outSpeed;

    private void ChangeSpeed(object Pobject, SetSpeed.SpeedArgs PspeedArgs)
    {
        targetSpeed = PspeedArgs.SspeedNow;
        clockwiseOrNot = PspeedArgs.Sclockwise;
        if (!PspeedArgs.Stype)
        {
            numberDifference = preNumberDifference = addNumberDifference = deltaNumberDifference = 0;
        }
    }

    private void DifferenceCatch()
    {
        speedDifference = tireItself.velocity - targetSpeed;
        if (tireType == (short)Tire.lf || tireType == (short)Tire.rb)
        {
            numberDifference = Vector3.Dot(speedDifference,_rfWay);
        }
        else
        {
            numberDifference = Vector3.Dot(speedDifference,_lfWay);
        }
    }
    private void ChangeForce()
    {
        DifferenceCatch();
        addNumberDifference += numberDifference * Time.deltaTime;
        deltaNumberDifference = (numberDifference - preNumberDifference) / Time.deltaTime;
        outSpeed = (_kP * numberDifference + _kI * addNumberDifference + _kD * deltaNumberDifference) * 80f;
        switch (clockwiseOrNot)//q,e旋转有巨大bug，但考虑到已经解决随视角转动问题，暂时不管（实在不行addtouque
        {
            case -1:
                if (tireType == (short)Tire.lf || tireType == (short)Tire.lb)
                {
                    outSpeed = -_rollSpeed;
                }
                else
                {
                    outSpeed = _rollSpeed;
                }
                break;
            case 1:
                if (tireType == (short)Tire.lf || tireType == (short)Tire.lb)
                {
                    outSpeed = _rollSpeed;
                }
                else
                {
                    outSpeed = -_rollSpeed;
                }
                break;
        }
        if (tireType == (short)Tire.lf || tireType == (short)Tire.rb)
        {
            theForce = outSpeed * _rfWay;
        }
        else
        {
            theForce = outSpeed * _lfWay;
        }
        preNumberDifference = numberDifference;
        tireItself.AddRelativeForce(theForce,ForceMode.Force);
    }
    
    void Awake()
    {
        targetSpeed = new Vector3();
        clockwiseOrNot = 0;
        numberDifference = 0f;
        preNumberDifference = 0f;
        addNumberDifference = 0f;
        tireItself = GameObject.Find("保护网").GetComponent<Rigidbody>();
        SetSpeed.EchangeSpeed += ChangeSpeed;
    }

    private void FixedUpdate()
    {
        ChangeForce();
    }
}
