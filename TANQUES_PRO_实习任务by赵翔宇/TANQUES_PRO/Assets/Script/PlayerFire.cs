using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : BulletFire
{
    protected void HearTrigger(object Pobject,EventArgs PeventArgs)
    {
        GetFire();
    }

    protected override void Start()
    {
        base.Start();
        HearInput.Eclick += HearTrigger;
    }
}
