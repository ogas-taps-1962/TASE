using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleAbout : MonoBehaviour
{
    protected float VectorXZToAngle(Vector3 PcaseXZ)
    {
        PcaseXZ.y = 0;
        PcaseXZ = PcaseXZ.normalized;
        float temAngle = (float)Math.Acos(PcaseXZ.z) * Mathf.Rad2Deg;
        if (PcaseXZ.x < 0)
        {
            temAngle = -temAngle;
        }

        return temAngle;
    }
}
