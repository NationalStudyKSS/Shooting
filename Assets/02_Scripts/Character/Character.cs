using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //[Header("----- 컴포넌트 -----")]
    [SerializeField] protected CharacterModel _model;
    //[SerializeField] CharacterHud _hud;
    [SerializeField] protected Mover _mover;
    //[SerializeField] Animator _animator;
    //[SerializeField] SpriteRenderer _renderer;

    public void Initialize()
    {
        _model.Initialize();

        _mover.OnMoved += OnMoved;
        _model.OnDeath += OnDeath;
        
        //_model.OnHpChanged += _hud.SetHpBar; //아직 hud 작성안함
    }

    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }

    public virtual void Move(Vector3 direction)
    {
        _mover.Move(direction);
    }

    public virtual void TakeDamage(float amount)
    {
        _model.TakeDamage(amount);
    }

    public void OnMoved(Vector3 velocity)
    {

    }
}
