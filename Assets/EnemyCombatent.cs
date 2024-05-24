using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCombatent : MonoBehaviour
{
    [SerializeField] private bool isBoss = false;
    [SerializeField] private int health = 3;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject boltPrefab;
    private static int deathCounter = 0;
    private bool invertMovement = false;

    float timeSinceLastShot = 0;
    float timeBetweenShots = 0;
    [SerializeField] float speed = 2.5f;

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


        if (isBoss)
        {

            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot > timeBetweenShots)
            {
                timeBetweenShots = UnityEngine.Random.Range(0.2f, 1.4f);
                timeSinceLastShot = 0;
                // Om boolen är true, skjut det bättre skottet
                // Annars skjut det vanliga
                GameObject bulletInstance = Instantiate(boltPrefab, gun.transform.position, Quaternion.identity);
                bulletInstance.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
            }
            Vector3 screenBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            // Vector2 movement = new Vector2(Mathf.Sin(Time.time * sineWaveFrequency) * sineWaveAmplitude, 0);
            Vector2 movement = new Vector2(1, 0);
            if (transform.localPosition.x >= screenBorder.x)
            {

                invertMovement = true;

            }
            else if (transform.localPosition.x <= -screenBorder.x)
            {
                invertMovement = false;
            }


            if (invertMovement)
            {
                movement.x = -Mathf.Abs(movement.x); // Ensure movement is negative
            }
            else
            {
                movement.x = Mathf.Abs(movement.x); // Ensure movement is positive
            }


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
            deathCounter++;
            health--;
            if (health <= 0 && isBoss)
            {
                SceneManager.LoadScene(3);
            }
            else if (health <= 0)
            {
                Destroy(this.gameObject);

            }



        }

        if (deathCounter >= 15)
        {
            deathCounter = 0;
            SceneManager.LoadScene(2);
        }
    }



}




//om man dödat 25 enemies då gå boss fighten igång


