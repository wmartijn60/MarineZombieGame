﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private float zombiespawnDelay = 0.1f;
    [SerializeField] private float survivorspawnDelay = 0.1f;
    [SerializeField] private float betweenDelay = 0.1f;

    [SerializeField] private int bossStartWave = 4;
    [SerializeField] private int maxWave = 5;
  
    [SerializeField] private List<GameObject> zombies;
    [SerializeField] private List<GameObject> survivors;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private Transform humanoids;

    private UIManager uiManager;

    public static int waveNumber = 1;
    public int WaveNumber { get { return waveNumber; } }
    public int MaxWave { get { return maxWave; } }
    public Transform Humanoids { get { return humanoids; } }

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) 
        {
            StartCoroutine("SendWave");
        }
    }

    public void StartWave() {
        StartCoroutine("SendWave");
    }

    private IEnumerator SendWave()
    {       

        for (int i = 0; i < (5 * waveNumber); i++)
        {
            Transform chosenSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            GameObject newSurvivor = GameObject.Instantiate(survivors[Random.Range(0, survivors.Count)], chosenSpawnPoint.position, chosenSpawnPoint.rotation, humanoids);
            newSurvivor.GetComponent<Survivor>().target = GameObject.FindGameObjectWithTag("Player").transform;
            yield return new WaitForSeconds(survivorspawnDelay);
        }
        yield return new WaitForSeconds(betweenDelay);
        for (int i = 0; i < (20 * waveNumber); i++) {
            Transform chosenSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            int rdm = Random.Range(0, 6);
            if (waveNumber >= bossStartWave && rdm > 4)
            {                
                GameObject newZombie = GameObject.Instantiate(zombies[1], chosenSpawnPoint.position, chosenSpawnPoint.rotation, humanoids);
                newZombie.GetComponent<Zombie>().target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            else
            {
                GameObject newZombie = GameObject.Instantiate(zombies[0], chosenSpawnPoint.position, chosenSpawnPoint.rotation, humanoids);
                newZombie.GetComponent<Zombie>().target = GameObject.FindGameObjectWithTag("Player").transform;
            }            
            yield return new WaitForSeconds(zombiespawnDelay);
        }
        waveNumber++;
        uiManager.waveStart();
    }
}
