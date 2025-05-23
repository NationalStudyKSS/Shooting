using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("----- ÄÄÆ÷³ÍÆ® -----")]
    //[SerializeField] HeroModel _model;
    //[SerializeField] CharacterHud _hud;
    [SerializeField] Mover _mover;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _renderer;

    public void Initialize()
    {
        //_model.Initialize();

        _mover.OnMoved += OnMoved;
        //_model.OnDeath += OnDeath;
        //_model.OnHpChanged += _hud.SetHpBar;
    }

    public virtual void Move(Vector3 direction)
    {
        _mover.Move(direction);
    }

    public void OnMoved(Vector3 velocity)
    {

    }
}
