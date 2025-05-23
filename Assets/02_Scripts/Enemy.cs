using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 5;
    public GameObject enemyEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp--;
            //print(hp);
            if (hp == 0)
            {
                Instantiate(enemyEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
