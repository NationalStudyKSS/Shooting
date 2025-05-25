using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// ĳ������ ������ ���� �κ��� ���
/// </summary>
public abstract class CharacterModel : MonoBehaviour
{
    // �ڽ� Ŭ�������� �޶��� ��ġ��
    [SerializeField] protected float _damage;
    [SerializeField] protected float _maxHp;
    [SerializeField] protected float _currentHp;

    
    //[SerializeField] float _moveSpeed; // Mover�� �̵����� ����̹Ƿ� �ʿ�X

    // ü�º��� �̺�Ʈ
    public event UnityAction<float, float> OnHpChanged; //(_currentHp, _maxHp)
    // ��� �̺�Ʈ
    public event UnityAction OnDeath;

    public float Damage => _damage;
    public float MaxHp => _maxHp;
    public float CurrentHp => _currentHp;

    // �ʱ�ȭ �Լ�: ü���� �ִ�ġ�� ����
    public void Initialize()
    {
        _currentHp = _maxHp;
        OnHpChanged?.Invoke(_currentHp, _maxHp);
    }

    /// <summary>
    /// �������� �Ծ��� �� ó�����ִ� �Լ�
    /// </summary>
    /// <param name="amount">������</param>
    public void TakeDamage(float amount)
    {
        if (_currentHp <= 0) return;
        
        // �Ʒ� Mathf.Min ���
        //_currentHp -= amount;

        _currentHp = Mathf.Max(_currentHp - amount, 0); // ü�� 0 �̸����� �ȵǵ���
        OnHpChanged?.Invoke(_currentHp, _maxHp);

        if (_currentHp <= 0)
        {
            _currentHp = 0;
            OnDeath?.Invoke();
        }
    }
    
    /// <summary>
    /// ���� �ްų� ȸ���������� �Ծ����� �Լ�
    /// </summary>
    /// <param name="amount">ȸ����</param>
    public void Heal(float amount)
    {
        if (_currentHp <= 0) return;
        
        _currentHp = Mathf.Min(_currentHp + amount, _maxHp); // �ִ�ü�°� ������ü���� ������
        OnHpChanged?.Invoke(_currentHp, _maxHp);
    }
}
