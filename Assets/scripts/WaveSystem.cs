using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveSystem : MonoBehaviour
{
    private int waveNumber;

    public List<Transform> spawnPoints = new List<Transform>();
    
    public void SendWave()
    {
        for (int i = 0; i < (5 * waveNumber); i++)
        {
            Survivor.Instantiate(spawnPoints[Random.Range(0, spawnPoints.Count)]);
        }
        
        for (int i = 0; i < (20 * waveNumber); i++)
        {
            Zombie.Instantiate(spawnPoints[Random.Range(0, spawnPoints.Count)]);
        }
    }
}
