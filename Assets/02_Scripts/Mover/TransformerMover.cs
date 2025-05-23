using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransformerMover : Mover
{
    public override event UnityAction<Vector3> OnMoved;
    Vector3 _moveVec;
    public override void Move(Vector3 direction)
    {
        _moveVec = direction * Speed;
        transform.Translate(_moveVec * Time.deltaTime);

        // OnMoved�� �����ϸ� _moveVec�� �ְڴ�.
        OnMoved?.Invoke(_moveVec);
    }
}
