using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPressure : MonoBehaviour
{
    [SerializeField] private float maxCapacity = 100;
    [SerializeField] private float energyCost;
    [SerializeField] private float rechargeRate;
    [SerializeField] private float rechargeTreshhold = 5;
    
    [SerializeField] private GameObject beam;

    private float pressure;
    private bool isCharging = false;

    void Start()
    {
        pressure = maxCapacity;
        beam.SetActive(false);
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && pressure > 0 && !isCharging)
        {
            beam.SetActive(true);
            pressure = pressure - energyCost * Time.deltaTime;
        }
        else
        {
            beam.SetActive(false);
        }

        if (pressure >= maxCapacity)
        {
            pressure = maxCapacity;
        }
        else if(!Input.GetKey(KeyCode.Mouse0) || isCharging)
        {
            pressure += rechargeRate * Time.deltaTime;
        }

        if (pressure <= 0 && beam.activeSelf)
        {
            isCharging = true;
        }
        else if (pressure >= rechargeTreshhold)
        {
            isCharging = false;
        }
    }
}
