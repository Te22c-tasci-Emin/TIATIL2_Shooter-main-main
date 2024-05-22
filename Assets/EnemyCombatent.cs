using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.UI;
using UnityEngine;

public class EnemyCombatent : MonoBehaviour
{
    [SerializeField] private bool isBoss = false;
    [SerializeField] private float sineWaveFrequency = 1;
    [SerializeField] private float sineWaveAmplitude = 1;
    [SerializeField] private int health = 3;
    [SerializeField]
    GameObject ExplosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (!isBoss)
        {
            float x = UnityEngine.Random.Range(-7f, 7f);
            Vector2 position = new Vector2(x, 5.5f);
            transform.position = position;
        }
    }

    // Update is called once per frame
    void Update()

    {
        float speed = 2.5f;
        if (isBoss)
        {
            Vector2 movement = new Vector2(Mathf.Sin(Time.time * sineWaveFrequency) * sineWaveAmplitude, 0);
            transform.Translate(movement * speed * Time.deltaTime);
        }
        else
        {
            Vector2 movement = new Vector2(0, -1);
            transform.Translate(movement * speed * Time.deltaTime);

            if (transform.position.y < -3.5f)
            {
                Destroy(this.gameObject);
            }
        }



    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            ShipController.deathCounter++;
            health--;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }

            //if()
            //GameObject.Find("spawner").GetComponent<SpawnerController>().SpawnerSpawn

        }



    }
}

//om man dödat 25 enemies då gå boss fighten igång


