using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
  [SerializeField]
  float speed = 5.5f;

  void Update()
  {
    transform.Translate(transform.TransformDirection(transform.up) * speed * Time.deltaTime);

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
