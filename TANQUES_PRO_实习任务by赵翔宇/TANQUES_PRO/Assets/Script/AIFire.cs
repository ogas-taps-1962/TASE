using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFire : BulletFire
{
    private bool alive;
    private float temTime;
    
    protected void HearDead(object Pobject,BloodCheck.DeadArgs PdeadArgs)
    {
        if (PdeadArgs.SdeadNow==GameObject.FindWithTag("Enemy"))
        {
            alive = false;
            PdeadArgs.SdeadNow.GetComponent<BloodCheck>().Sblood = 100f;
        }
    }
    protected override void Start()
    {
        base.Start();
        temTime = 0f;
        alive = true;
    }

    private void FixedUpdate()
    {
        if (alive)
        {
            GetFire();
        }
        else
        {
            temTime += Time.deltaTime;
            if (temTime >= 5f)
            {
                temTime = 0;
                alive = true;
            }
        }
    }
}
