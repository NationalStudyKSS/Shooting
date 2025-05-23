using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float maxHp = 100f;
    public float currentHp = 100;

    private void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        // 화면 밖으로 나가면 삭제
        if (transform.position.y < -1f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHp -= amount;
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
