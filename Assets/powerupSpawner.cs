using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class powerupSpawner : MonoBehaviour
{

    [SerializeField]

    GameObject spawner;

    [SerializeField]
    float timeBetweenPowerups = 8f;
    float timeSinceLastPowerup = 0;
    void Update()
    {
        timeSinceLastPowerup += Time.deltaTime;

        if (timeSinceLastPowerup > timeBetweenPowerups)
        {
            Instantiate(spawner);
            timeSinceLastPowerup = 0;
        }
    }
}
