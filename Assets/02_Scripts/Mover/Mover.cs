using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float _speed;
    public abstract event UnityAction<Vector3> OnMoved;
    public virtual float Speed => _speed;

    public abstract void Move(Vector3 direction);

    public virtual void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
