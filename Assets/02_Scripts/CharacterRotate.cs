using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotate : MonoBehaviour
{
    public PlayerController _player;
    // Update is called once per frame
    void Update()
    {
        //if (_player.currentHp == 0) return;
        // 왼쪽 화살표 입력 시
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            //print("<<<<< 왼쪽!!!!!");
            transform.rotation = Quaternion.Euler(-90f, -45f, 0f);
        }
        // 오른쪽 화살표 입력 시
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //print("!!!!! 오른쪽 >>>>>");
            transform.rotation = Quaternion.Euler(-90f, 45f, 0f);
        }
        // 아무 입력 없을 때
        else
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, 0);
        }
    }
}
