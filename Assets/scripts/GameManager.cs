using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;


public class GameManager : MonoBehaviour
{
    private static int coins;
    public static int Coins { get { return coins; } }
    static GameManager instance;
    void Awake() {
        instance = this;
    }
    /// <summary>
    /// Change the total amount of coins
    /// </summary>
    /// <param name="change">positive is adding, negative is subtracting</param>
    public static void ChangeCoinAmount(int change) {
        coins += change;
    }
}
