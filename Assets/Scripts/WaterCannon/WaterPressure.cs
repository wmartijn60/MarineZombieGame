﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPressure : MonoBehaviour
{
    [SerializeField] private float maxCapacity = 100;
    [SerializeField] private float energyCost;
    [SerializeField] private float rechargeRate;
    [SerializeField] private float rechargeTreshhold = 5;
    
    [SerializeField] private GameObject beam;
    [SerializeField] private Slider pressureBar;
    [SerializeField] private Slider repressureBar;
    [SerializeField] private CountDown countDown;

    private float pressure;
    private bool isCharging = false;

    public bool isActive;

    void Start()
    {
        countDown.startingCountDown += TurnOff;
        countDown.stoppingCountdown += TurnOn;
        pressure = maxCapacity;
        beam.SetActive(false);
        repressureBar.value = 100 / maxCapacity * rechargeTreshhold;
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && pressure > 0 && !isCharging && isActive)
        {
            beam.SetActive(true);
            pressure = pressure - energyCost * Time.deltaTime;
            pressureBar.value = 100 / maxCapacity * pressure;
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
            pressureBar.value = 100 / maxCapacity * pressure;
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

    public void SetRepressureValue(int v)
    {
        rechargeTreshhold -= v;
        repressureBar.value = 100 / maxCapacity * rechargeTreshhold;
    }

    public void IncreaseCapacity(int v)
    {
        maxCapacity += v;
        pressureBar.value = 100 / maxCapacity * pressure;
    }

    public void IncreaseRechargeRate(int v)
    {
        rechargeRate += v;
    }

    public void TurnOff()
    {
        isActive = false;
    }
    public void TurnOn()
    {
        isActive = true;
    }
}