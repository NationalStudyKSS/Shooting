using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HeroSkill : MonoBehaviour
{
    [SerializeField] CharacterModel _model;
    [SerializeField] GameObject allyFlight;
    [SerializeField] float _coolTime = 5f;
    [SerializeField] Image _skill1Image;

    float _coolTimer = 0f;

    public event UnityAction<float, float> OnCoolTimeChanged;

    private void Update()
    {
        if (_coolTimer > 0f)
        {
            _coolTimer -= Time.deltaTime;
            OnCoolTimeChanged?.Invoke(_coolTimer, _coolTime);
        }
        Skill1CoolTime();
    }

    public void Skill1()
    {
        if (_coolTimer > 0f) return; // 쿨타임이 남아있으면 무시

        // 스킬 발동
        List<float> list = new List<float> { -2.5f, -1.25f, 0, 1.25f, 2.5f };
        foreach (var item in list)
        {
            Vector3 vec = new Vector3(item, transform.position.y, transform.position.z);
            Instantiate(allyFlight, vec, transform.rotation);
        }

        _coolTimer = _coolTime; // 쿨타임 초기화
    }

    public bool CanUseSkill => _coolTimer <= 0f;

    public void Skill1CoolTime()
    {
        _skill1Image.fillAmount = (_coolTime-_coolTimer) / _coolTime;
    }
}
