using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroSkill : MonoBehaviour
{
    [SerializeField] GameObject allyFlight;
    [SerializeField] float _coolTime = 5f;

    float _coolTimer = 0f;

    public event UnityAction<float, float> OnCoolTimeChanged;

    private void Update()
    {
        if (_coolTimer > 0f)
        {
            _coolTimer -= Time.deltaTime;
            OnCoolTimeChanged?.Invoke(_coolTimer, _coolTime);
        }
    }

    public void Skill1()
    {
        if (_coolTimer > 0f) return; // ��Ÿ���� ���������� ����

        // ��ų �ߵ�
        List<float> list = new List<float> { -2.5f, -1.25f, 0, 1.25f, 2.5f };
        foreach (var item in list)
        {
            Vector3 vec = new Vector3(item, transform.position.y, transform.position.z);
            Instantiate(allyFlight, vec, transform.rotation);
        }

        _coolTimer = _coolTime; // ��Ÿ�� �ʱ�ȭ
    }

    public bool CanUseSkill => _coolTimer <= 0f;
}
