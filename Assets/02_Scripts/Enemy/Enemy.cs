using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    float _damage = 25f;    // ���߿� ������ȭ�ؾ���
    int _deathCount = 0;

    public int DeathCount => _deathCount;
    
    protected override void OnDeath()
    {
        base.OnDeath();
        _deathCount++;
    }

    private void Start()
    {
        _model.OnDeath += () => ScoreManager.Instance.AddScore(1);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            Hero hero = other.GetComponent<Hero>();
            Destroy(gameObject);
            hero.TakeDamage(_damage);
        }
    }
}
