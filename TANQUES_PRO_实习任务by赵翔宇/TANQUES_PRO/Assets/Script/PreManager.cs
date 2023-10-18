using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreManager : MonoBehaviour
{
    public GameObject theBullet;
    public GameObject theWall;
    private void Awake()
    {
        BulletFire._theBullet = theBullet;
        WallBuild._theWall = theWall;
        SceneManager.LoadScene(1,LoadSceneMode.Additive);
    }
}
