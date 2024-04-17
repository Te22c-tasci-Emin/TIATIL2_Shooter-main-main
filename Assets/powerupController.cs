using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class powerupController : MonoBehaviour
{

    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-7f, 7f);

        Vector2 position = new Vector2(x, 5.5f);

        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {


        float speed = 2.5f;

        Vector2 movement = new Vector2(0, -1);
        transform.Translate(movement * speed * Time.deltaTime);

        if (transform.position.y < -3.5f)
        {
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<ShipController>().Powerup();
        }
    }
}
