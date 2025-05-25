using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Hero : Character
{
    [SerializeField] HeroSkill skill;
    [SerializeField] GameObject _restartPanel;

    [SerializeField] Transform _gunPoint;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float limitX;

    [SerializeField] float attackSpan = 0.5f; // 공격 딜레이(초)
    private float attackCooldown = 0f; // 남은 쿨타임

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if (attackCooldown > 0f)
        {
            attackCooldown -= Time.deltaTime;
        }
    }

    public void Initialize(InputHandler input)
    {
        input.OnAttackInput += Attack;
        input.OnSkill1Input += UseSkill1;
    }

    protected override void OnDeath()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0f;
        _restartPanel.SetActive(true);
        // 죽었을 때 이벤트(재시작 화면??)
    }

    public override void Move(Vector3 direction)
    {
        base.Move(direction);
        // (딱히 추가할거 없음)

        // 현재 위치 가져오기
        Vector3 pos = transform.position;

        // 좌우 경계 내로 제한
        pos.x = Mathf.Clamp(pos.x, -limitX, limitX);

        // 제한된 위치로 다시 적용
        transform.position = pos;
    }

    // 영웅이 공격하면? -> 총알을 생성
    public void Attack()
    {
        if (attackCooldown > 0f)
            return; // 쿨타임 끝나기 전엔 공격하지 않음

        GameObject bulletObj = Instantiate(_bulletPrefab, _gunPoint.position, _gunPoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        Vector3 shootDirection = transform.up; // 총알이 날아갈 방향

        HeroModel heroModel = _model as HeroModel;
        if (heroModel != null)
        {
            bullet.Initialize(heroModel.Damage, shootDirection); // 플레이어의 공격력과 발사방향을 넘겨줌
        }

        attackCooldown = attackSpan; // 쿨타임 초기화
    }

    public void UseSkill1()
    {
        skill.Skill1();
    }
}
