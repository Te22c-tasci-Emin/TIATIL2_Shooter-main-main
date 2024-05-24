using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{

  [SerializeField]
  float speed = 4.1f;

  [SerializeField]
  GameObject boltPrefab;

  [SerializeField]
  GameObject gun;

  [SerializeField]
  float timeBetweenShots = 0.5f;
  float timeSinceLastShot = 0;
  // float timeBetweenPowerup = 80f;
  float timeSinceLastPowerup = 0;
  bool isPoweredUp = false;

  [SerializeField]
  GameObject ExplosionPrefab;


  [SerializeField]

  private int maxHealth = 3;
  public int currentHealth;


  void Start()
  {
    currentHealth = maxHealth;
  }
  // Update is called once per frame
  void Update()
  {

    // Om vi just nu har powerup (boolen är true): dra av från timern
    // Om timern < 0: sätt boolen till false
    if (isPoweredUp == false)
    {
      timeSinceLastPowerup -= Time.deltaTime;
      timeBetweenShots = 0.25f;
    }


    else if (timeSinceLastPowerup > 0)
    {
      isPoweredUp = false;
      timeBetweenShots = 0.5f;
    }





    float moveX = Input.GetAxisRaw("Horizontal");
    float moveY = Input.GetAxisRaw("Vertical");

    Vector2 movementX = new Vector2(moveX, 0);
    Vector2 movementY = new Vector2(0, moveY);

    Vector2 movement = movementX + movementY;

    transform.Translate(movement * speed * Time.deltaTime);

    if (Mathf.Abs(transform.position.x) > 8.5f)
    {
      transform.Translate(-movementX * speed * Time.deltaTime);
    }

    if (Mathf.Abs(transform.position.y) > 4.5f)
    {
      transform.Translate(-movementY * speed * Time.deltaTime);
    }

    timeSinceLastShot += Time.deltaTime;
    if (Input.GetAxisRaw("Fire1") > 0 && timeSinceLastShot > timeBetweenShots)
    {
      timeSinceLastShot = 0;
      // Om boolen är true, skjut det bättre skottet
      // Annars skjut det vanliga
      Instantiate(boltPrefab, gun.transform.position, Quaternion.identity);
    }
  }


  public void Powerup()
  {

    isPoweredUp = true;
    timeSinceLastPowerup = 4f;

    // sätt timern till 5

  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "enemy" || other.gameObject.tag == "bullet")
    {


      Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
      currentHealth--;
      Destroy(other.gameObject);

      if (currentHealth <= 0)
      {
        
        Destroy(this.gameObject);
        SceneManager.LoadScene(1);
      }

    }

  }

}

