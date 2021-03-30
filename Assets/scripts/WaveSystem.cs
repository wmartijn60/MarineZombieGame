using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveSystem : MonoBehaviour
{
    private int waveNumber;

    public List<Transform> spawnPoints = new List<Transform>();
    
    public void SendWave()
    {
        Zombie.Instantiate(spawnPoints[Random.Range(0, spawnPoints.Count)]);
    }
}
