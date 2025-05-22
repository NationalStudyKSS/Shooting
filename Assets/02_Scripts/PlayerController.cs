using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveX;
    public float limitX = 2.5f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveX, 0, 0);
            if (transform.position.x < -limitX)
            {
                transform.position = new Vector3(-limitX, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveX, 0, 0);
            if (transform.position.x > limitX)
            {
                transform.position = new Vector3(limitX, 0, 0);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("총알 발사!!!");
        }
    }
}
