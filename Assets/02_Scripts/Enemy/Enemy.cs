using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    protected override void OnDeath()
    {
        base.OnDeath();
    }

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        // �Ʒ� �������� �̵��ϴ� ���� ���� ���
        Vector3 direction = Vector3.down;

        // Move �Լ��� ���� ���� (�ӵ��� Mover���� ó��)
        Move(direction);

        // ��ġ�� �Ʒ��� ����� �ı�
        if (transform.position.y < -1f)
        {
            Destroy(gameObject);
        }
    }
}
