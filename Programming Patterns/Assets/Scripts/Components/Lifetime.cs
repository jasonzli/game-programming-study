using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lifetime : MonoBehaviour
{
    public float lifeTime = 5;
    public bool _Pooled;

    [SerializeField]
    private float timeLeft = 0;

    [SerializeField]
    public  float timeLeft = 0 ;

    private void Start(){
        StartCoroutine(Countdown());
    }

    void OnEnable(){
        timeLeft = lifeTime;
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown(){
        while (timeLeft >= 0){
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        RemoveObject(_Pooled);
    }

    void RemoveObject(bool pooled){
        if (pooled)
            Spawner.Instance.AddToPool(gameObject);
        else
            Destroy(gameObject);
    }
}
