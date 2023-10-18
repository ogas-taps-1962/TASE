using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCheck : MonoBehaviour
{
    protected float _blood = 100f;
    protected GameObject _itself;

    public float Sblood
    {
        get
        {
            return _blood;
        }
        set
        {
            _blood = value;
        }
    }
    
    public delegate void EventHandler<TEventArgs>(object Psender, TEventArgs Pe)
        where TEventArgs : EventArgs;
    public class DeadArgs : System.EventArgs
    {
        public GameObject SdeadNow { get; set; }
        public DeadArgs(GameObject PdeadNow) 
        {
            SdeadNow = PdeadNow;
        }
    }

    public static event EventHandler<DeadArgs> EdeadOne = delegate(object Psender, DeadArgs Pargs) { };

    protected void OnTriggerEnter(Collider Pother)
    {
        if (Pother.gameObject.CompareTag("Bullet"))
        {
            _blood -= 10f;
            if (_blood <= 0)
            {
                EdeadOne?.Invoke(this,new DeadArgs(_itself));
                print("gone");
            }
        }
    }
    protected virtual void Start()
    {
        _itself = this.gameObject;
    }
}
