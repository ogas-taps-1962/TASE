using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuild : MonoBehaviour
{
    public static GameObject _theWall;
    private const float Clength = 3.2f;
    private static Quaternion temQua;
    private static void BuildWall()
    {
        temQua.eulerAngles = new Vector3(0, 0, 0);
        for (int i = 0; i < 4; i++)
        {
            Instantiate(_theWall, new Vector3(2*Clength, 0f, Clength * i),temQua);
            Instantiate(_theWall, new Vector3(2*Clength, 0f, -Clength * (i+1)),temQua);
            Instantiate(_theWall, new Vector3(-2*Clength, 0f, Clength * i),temQua);
            Instantiate(_theWall, new Vector3(-2*Clength, 0f, -Clength * (i+1)),temQua);
        }

        temQua.eulerAngles = new Vector3(0, 90f, 0);
        for (int i = 0; i < 2; i++)
        {
            Instantiate(_theWall, new Vector3(Clength * (i+1), 0f, 4*Clength),temQua);
            Instantiate(_theWall, new Vector3(Clength * (i-1), 0f, -4*Clength),temQua);
            Instantiate(_theWall, new Vector3(-Clength * i, 0f, 4*Clength),temQua);
            Instantiate(_theWall, new Vector3(-Clength * (i-2), 0f, -4*Clength),temQua);
        }
    }
    private void Start()
    {
        BuildWall();
    }
}
