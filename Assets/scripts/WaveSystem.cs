using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    private int waveNumber = 0;
    [SerializeField] private List<GameObject> zombies;
    [SerializeField] private List<GameObject> survivors;

    public List<Transform> spawnPoints = new List<Transform>();

    private void Update() {
        if (Input.GetKeyDown(KeyCode.J)) {
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
            //Survivor.Instantiate(spawnPoints[Random.Range(0, spawnPoints.Count)]);
            yield return new WaitForSeconds(0.1f);
        }
        
        for (int i = 0; i < (20 * waveNumber); i++) {
            Transform chosenSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            GameObject newZombie = GameObject.Instantiate(zombies[Random.Range(0, zombies.Count)], chosenSpawnPoint.position, chosenSpawnPoint.rotation);
            newZombie.GetComponent<Zombie>().target = GameObject.FindGameObjectWithTag("Player").transform;
            //Zombie.Instantiate(spawnPoints[Random.Range(0, spawnPoints.Count)]);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
