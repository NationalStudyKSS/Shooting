using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print("ÃÑ¾Ë »ý¼º!!!");
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
