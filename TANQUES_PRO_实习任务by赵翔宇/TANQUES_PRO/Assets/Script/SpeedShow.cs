using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedShow : MonoBehaviour
{
    private Rigidbody theCar;
    private Transform carPlace;
    private Text speedText;
    private SetSpeed theScript;
    private short gear;

    private void ChangeGear(object Pobject, SetSpeed.GearArgs PgearArgs)
    {
        gear = PgearArgs.SgearNow;
    }
    private void ChangeText()
    {
        speedText.text = "Speed:" + Vector3.Dot(theCar.velocity, carPlace.forward) + "\nGear:" + gear + "\nLook Lock:" +
                         theScript.SlookLock;
    }
    
    void Awake()
    {
        carPlace = GameObject.Find("保护网").GetComponent<Transform>();
        theCar = GameObject.Find("保护网").GetComponent<Rigidbody>();
        speedText = GameObject.Find("Speed").GetComponent<Text>();
        theScript = GameObject.Find("SpeedControl").GetComponent<SetSpeed>();
        gear = 1;
        SetSpeed.EchangeGear += ChangeGear;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeText();
    }
}
