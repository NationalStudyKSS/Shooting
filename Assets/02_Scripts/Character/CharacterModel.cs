using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 캐릭터의 데이터 관련 부분을 담당
/// </summary>
public abstract class CharacterModel : MonoBehaviour
{
    // 자식 클래스에서 달라질 수치들
    [SerializeField] protected float _damage;
    [SerializeField] protected float _maxHp;
    [SerializeField] protected float _currentHp;

    
    //[SerializeField] float _moveSpeed; // Mover가 이동관련 담당이므로 필요X

    // 체력변경 이벤트
    public event UnityAction<float, float> OnHpChanged; //(_currentHp, _maxHp)
    // 사망 이벤트
    public event UnityAction OnDeath;

    public float Damage => _damage;
    public float MaxHp => _maxHp;
    public float CurrentHp => _currentHp;

    // 초기화 함수: 체력을 최대치로 세팅
    public void Initialize()
    {
        _currentHp = _maxHp;
        OnHpChanged?.Invoke(_currentHp, _maxHp);
    }

    /// <summary>
    /// 데미지를 입었을 때 처리해주는 함수
    /// </summary>
    /// <param name="amount">데미지</param>
    public void TakeDamage(float amount)
    {
        if (_currentHp <= 0) return;
        
        // 아래 Mathf.Min 사용
        //_currentHp -= amount;

        _currentHp = Mathf.Max(_currentHp - amount, 0); // 체력 0 미만으로 안되도록
        OnHpChanged?.Invoke(_currentHp, _maxHp);

        if (_currentHp <= 0)
        {
            _currentHp = 0;
            OnDeath?.Invoke();
        }
    }
    
    /// <summary>
    /// 힐을 받거나 회복아이템을 먹었을때 함수
    /// </summary>
    /// <param name="amount">회복량</param>
    public void Heal(float amount)
    {
        if (_currentHp <= 0) return;
        
        _currentHp = Mathf.Min(_currentHp + amount, _maxHp); // 최대체력과 증가된체력중 작은값
        OnHpChanged?.Invoke(_currentHp, _maxHp);
    }
}
