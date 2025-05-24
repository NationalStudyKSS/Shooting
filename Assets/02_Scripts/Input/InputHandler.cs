using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ������� �Է��� �޾� �˸��� ����
/// </summary>
public abstract class InputHandler : MonoBehaviour
{
    // �̵� �Է� �̺�Ʈ ����
    public abstract event UnityAction<Vector2> OnMoveInput;
    public abstract event UnityAction OnAttackInput;
    public abstract event UnityAction OnSkill1Input;
}
