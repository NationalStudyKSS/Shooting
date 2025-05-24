using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region 옛날 코드
    //public EnemyController _enemy;
    //public float damage = 20;
    //public float bulletSpeed;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    transform.Translate(0, bulletSpeed*Time.deltaTime, 0);
    //    if (transform.position.y > 10f)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    #endregion
    [SerializeField] TransformerMover _mover;

    private float _damage;
    private Vector3 _direction;

    void Start()
    {
        Destroy(gameObject, 5f); // 5초 후 자동 제거, 총알 수명관리
    }
    void Update()
    {
        if (_direction != Vector3.zero)
        {
            _mover.Move(_direction);
        }
    }

    public void Initialize(float damage, Vector3 direction)
    {
        _damage = damage;
        _direction = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet collided with: " + other.name);
        Debug.Log("Bullet Damage: " + _damage);

        if (other.CompareTag("Enemy"))
        {
            Character character = other.GetComponent<Character>();
            if (character != null)
            {
                character.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }

}
