using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ����Ƽ InputManager�� ����� �Է��� �޾� �˸��� ���� (�¿� �̵� + ���� + ��ų1)
/// </summary>
public class InputManagerHandler : InputHandler
{
    public override event UnityAction<Vector2> OnMoveInput;
    public override event UnityAction OnAttackInput;
    public override event UnityAction OnSkill1Input;
    
    Vector2 _inputVector = Vector2.zero;

    private void Update()
    {
        // �¿� �̵��� ó�� (�¿� ����Ű �Ǵ� A/D Ű ����)
        _inputVector.x = Input.GetAxisRaw("Horizontal");

        if (_inputVector.x != 0)
        {
            OnMoveInput?.Invoke(_inputVector);
        }

        // �����̽��� �Է� �� �Ϲ� ����
        if (Input.GetKey(KeyCode.Space))
        {
            OnAttackInput?.Invoke();
        }

        // Q Ű �Է� �� ��ų1 �ߵ�
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnSkill1Input?.Invoke();
        }
    }
}