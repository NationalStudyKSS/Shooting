using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Play ���� �Ѱ��ϴ� ����
/// </summary>
public class PlayScene : MonoBehaviour
{
    [SerializeField] InputHandler _inputHandler;
    [SerializeField] Hero _hero;
    [SerializeField] EnemySpawner _enemySpawner;

    void Start()
    {
        _hero.Initialize(_inputHandler);
        // �̵� �Է� �̺�Ʈ ����
        _inputHandler.OnMoveInput += OnMoveInput;
    }

    /// <summary>
    /// �̵� �Է��� ������ �� �����ϴ� �Լ�
    /// </summary>
    /// <param name="inputVec"></param>
    public void OnMoveInput(Vector2 inputVec)
    {
        _hero.Move(inputVec);
    }
}
