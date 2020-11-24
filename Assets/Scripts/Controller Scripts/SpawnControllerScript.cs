using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyZombies;
    int randomSpawnPoint, randomZombies;
    public bool spawnAllowed;

    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAZombie", 0f, 1f);    
    }

    // Update is called once per frame
    void SpawnAZombie()
    {
        if (spawnAllowed){
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomZombies = Random.Range(0, enemyZombies.Length);
            Instantiate (enemyZombies[randomZombies], spawnPoints [randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
