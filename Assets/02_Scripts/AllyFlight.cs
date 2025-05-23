using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyFlight : MonoBehaviour
{
    public float moveSpeed;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        if (transform.position.y > 9)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject             );
        }
    }
}
