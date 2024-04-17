using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
  [SerializeField]
  float speed = 5.5f;

  void Update()
  {
    Vector2 movement = new Vector2(0, 1);
    transform.Translate(movement * speed * Time.deltaTime);

    if (transform.position.y > 5.5f)
    {
      Destroy(this.gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "enemy")
    {
      Destroy(this.gameObject);
    }

  }

}
