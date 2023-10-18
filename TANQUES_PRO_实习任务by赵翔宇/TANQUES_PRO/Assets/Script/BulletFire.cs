using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public static GameObject _theBullet;
    protected Transform _gunPlace;
    protected float _cdTime;

    protected void GetFire()
    {
        if (_cdTime >= 0.5f)
        {
            Instantiate(_theBullet, _gunPlace.position, _gunPlace.rotation);
            _cdTime = 0f;
        }
    }
    protected virtual void Start()
    {
        _cdTime = 0f;
        _gunPlace = this.gameObject.GetComponent<Transform>();
    }

    protected void Update()
    {
        _cdTime += Time.deltaTime;
    }
}
