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

    [SerializeField] float attackSpan = 0.5f; // ���� ������(��)
    private float attackCooldown = 0f; // ���� ��Ÿ��

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
        // �׾��� �� �̺�Ʈ(����� ȭ��??)
    }

    public override void Move(Vector3 direction)
    {
        base.Move(direction);
        // (���� �߰��Ұ� ����)

        // ���� ��ġ ��������
        Vector3 pos = transform.position;

        // �¿� ��� ���� ����
        pos.x = Mathf.Clamp(pos.x, -limitX, limitX);

        // ���ѵ� ��ġ�� �ٽ� ����
        transform.position = pos;
    }

    // ������ �����ϸ�? -> �Ѿ��� ����
    public void Attack()
    {
        if (attackCooldown > 0f)
            return; // ��Ÿ�� ������ ���� �������� ����

        GameObject bulletObj = Instantiate(_bulletPrefab, _gunPoint.position, _gunPoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        Vector3 shootDirection = transform.up; // �Ѿ��� ���ư� ����

        HeroModel heroModel = _model as HeroModel;
        if (heroModel != null)
        {
            bullet.Initialize(heroModel.Damage, shootDirection); // �÷��̾��� ���ݷ°� �߻������ �Ѱ���
        }

        attackCooldown = attackSpan; // ��Ÿ�� �ʱ�ȭ
    }

    public void UseSkill1()
    {
        skill.Skill1();
    }
}
