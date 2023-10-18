using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private GameObject theBullet;
    private Rigidbody bulletBody;
    private static Vector3 StheForward = new Vector3(0f, 0f, 10f);
    void Start()
    {
        theBullet = this.gameObject;
        bulletBody = theBullet.GetComponent<Rigidbody>();
        bulletBody.AddRelativeForce(StheForward, ForceMode.VelocityChange);
        Destroy(theBullet,8f);
    }
}
