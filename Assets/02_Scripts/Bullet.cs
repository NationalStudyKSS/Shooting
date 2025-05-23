using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public EnemyController _enemy;
    public float damage = 20;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, bulletSpeed*Time.deltaTime, 0);
        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        EnemyController enemy = other.GetComponent<EnemyController>();
    //        if (enemy != null)
    //        {
    //            enemy.TakeDamage(10f); // 예시 데미지
    //            Destroy(gameObject); // 총알 제거
    //        }
    //    }
    //}
}
