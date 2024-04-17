using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [SerializeField]
    GameObject spawner;

    // Start is called before the first frame update
    float timeBetweenEnemies = 0.5f;    
   float timeSinceLastEnemies = 0;

   public int SpawnerSpawn; 

    // Update is called once per frame
    void Update()
    {
        timeSinceLastEnemies += Time.deltaTime;

        if (timeSinceLastEnemies > timeBetweenEnemies)
        {
        Instantiate(spawner);
        timeSinceLastEnemies = 0;
        }

    }
}






