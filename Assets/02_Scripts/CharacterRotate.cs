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
        // ���� ȭ��ǥ �Է� ��
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            //print("<<<<< ����!!!!!");
            transform.rotation = Quaternion.Euler(-90f, -45f, 0f);
        }
        // ������ ȭ��ǥ �Է� ��
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //print("!!!!! ������ >>>>>");
            transform.rotation = Quaternion.Euler(-90f, 45f, 0f);
        }
        // �ƹ� �Է� ���� ��
        else
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, 0);
        }
    }
}
