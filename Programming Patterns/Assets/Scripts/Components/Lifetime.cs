using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float timeLeft = 5;

    private void Start(){
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown(){
        while (timeLeft >= 0){
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        Destroy(this.gameObject);
    }
}
