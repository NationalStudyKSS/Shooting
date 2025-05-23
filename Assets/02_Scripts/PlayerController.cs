using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerSkill _skill;
    public float moveX;
    public float limitX = 2.5f;
    private void Start()
    {
        print(Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveX*Time.deltaTime, 0, 0);
            if (transform.position.x < -limitX)
            {
                transform.position = new Vector3(-limitX, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveX*Time.deltaTime, 0, 0);
            if (transform.position.x > limitX)
            {
                transform.position = new Vector3(limitX, 0, 0);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print("총알 발사!!!");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _skill.Skill1();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print("Game Over");
            Application.LoadLevel(0);
        }
    }
}
