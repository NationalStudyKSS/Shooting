using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyFlight : MonoBehaviour
{
    public float moveSpeed;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        if (transform.position.y > 9)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<CharacterModel>();
            if (enemy != null)
            {
                enemy.TakeDamage(100f); // OnDeath가 자동 호출될 수 있게
            }

            Destroy(gameObject); // 충돌 후 제거
        }
    }
}
