using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodShow : MonoBehaviour
{
    private BloodCheck playerBloodCheck;
    private Slider bloodBar;

    private void BloodPrint()
    {
        bloodBar.value = playerBloodCheck.Sblood;
    }
    private void Awake()
    {
        playerBloodCheck = GameObject.FindWithTag("Player").GetComponent<BloodCheck>();
        bloodBar = this.GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        BloodPrint();
    }
}
