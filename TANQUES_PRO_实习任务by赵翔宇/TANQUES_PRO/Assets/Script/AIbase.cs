using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIbase : AngleAbout
{
    protected Rigidbody _itsRigidbody;
    protected Transform _thePlayer;
    protected Transform _itsTransform;

    protected virtual void Awake()
    {
	    _itsRigidbody = this.GetComponent<Rigidbody>();
	    _itsTransform = this.GetComponent<Transform>();
	    _thePlayer = GameObject.Find("保护网").GetComponent<Transform>();
    }
}
