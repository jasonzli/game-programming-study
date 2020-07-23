using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObserverUI : MonoBehaviour
{
    Slider _Slider;
    [SerializeField]
    private Transform _plane;

    [SerializeField]
    private float AmountToDecrease;
    [SerializeField]
    private float AmountToIncrease;
    // Start is called before the first frame update
    void OnEnable(){
        _Slider = GetComponent<Slider>();
        _plane.GetComponent<CollisionObserver>().PlaneIntersected += DropValue;
    }

    void OnDisable(){
        _plane.GetComponent<CollisionObserver>().PlaneIntersected -= DropValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddValue(){
        _Slider.value += AmountToIncrease;
    }

    void DropValue(Vector3 v){
        _Slider.value -= AmountToDecrease;
    }
}
