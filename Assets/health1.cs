using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class health1 : MonoBehaviour
{
    public int maxHealth = 3;
    public int CurrentHealth;
    void Start()
    {
        CurrentHealth = maxHealth;
    }

    void TakeDamage(int amount)

    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            Destroy(this.gameObject);

        }


    }

    // Update is called once per frame
}
