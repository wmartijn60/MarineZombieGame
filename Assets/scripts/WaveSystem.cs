using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] float ZombiespawnDelay = 0.1f;
    [SerializeField] float SurvivorspawnDelay = 0.1f;

    private int waveNumber = 0;
    [SerializeField] private List<GameObject> zombies;
    [SerializeField] private List<GameObject> survivors;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private Transform enemies;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) 
        {
            StartCoroutine("SendWave");
        }
    }

    public IEnumerator SendWave()
    {
        waveNumber++;
        for (int i = 0; i < (5 * waveNumber); i++)
        {
            Transform chosenSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            GameObject newSurvivor = GameObject.Instantiate(survivors[Random.Range(0, survivors.Count)], chosenSpawnPoint.position, chosenSpawnPoint.rotation);
            newSurvivor.GetComponent<Survivor>().target = GameObject.FindGameObjectWithTag("Player").transform;
            yield return new WaitForSeconds(SurvivorspawnDelay);
        }
        
        for (int i = 0; i < (20 * waveNumber); i++) {
            Transform chosenSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            GameObject newZombie = GameObject.Instantiate(zombies[Random.Range(0, zombies.Count)], chosenSpawnPoint.position, chosenSpawnPoint.rotation, enemies);
            newZombie.GetComponent<Zombie>().target = GameObject.FindGameObjectWithTag("Player").transform;
            yield return new WaitForSeconds(ZombiespawnDelay);
        }
    }
}
