using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 유니티 InputManager를 사용해 입력을 받아 알리는 역할 (좌우 이동 + 공격 + 스킬1)
/// </summary>
public class InputManagerHandler : InputHandler
{
    public override event UnityAction<Vector2> OnMoveInput;
    public override event UnityAction OnAttackInput;
    public override event UnityAction OnSkill1Input;
    
    Vector2 _inputVector = Vector2.zero;

    private void Update()
    {
        // 좌우 이동만 처리 (좌우 방향키 또는 A/D 키 가능)
        _inputVector.x = Input.GetAxisRaw("Horizontal");

        if (_inputVector.x != 0)
        {
            OnMoveInput?.Invoke(_inputVector);
        }

        // 스페이스바 입력 → 일반 공격
        if (Input.GetKey(KeyCode.Space))
        {
            OnAttackInput?.Invoke();
        }

        // Q 키 입력 → 스킬1 발동
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnSkill1Input?.Invoke();
        }
    }
}