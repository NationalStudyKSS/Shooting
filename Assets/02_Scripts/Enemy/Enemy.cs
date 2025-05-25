using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    float _damage = 25f;    // 나중에 데이터화해야함
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
        // 아래 방향으로 이동하는 방향 벡터 계산
        Vector3 direction = Vector3.down;

        // Move 함수에 방향 전달 (속도는 Mover에서 처리)
        Move(direction);

        // 위치가 아래로 벗어나면 파괴
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
