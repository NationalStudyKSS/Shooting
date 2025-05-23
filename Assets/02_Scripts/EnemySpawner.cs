using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // �� ������
    public float spawnSpan = 2f;         // �� ���� ����
    public float spawnRangeX = 2.5f;      // X�� ���� ����
    public float spawnNum = 5;              // x�� ���� ��
    public int spawnNumMin;                // ������ ���� �ּ� ��
    public int spawnNumMax;                // ������ ���� �ִ� ��
    //public float moveX;
    //public float limitX;

    //private float timer = 0f;

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnSpan); // 2�� ���
        }
    }

    //private void Update()
    //{
    //    transform.Translate(moveX, 0, 0);

    //    if (transform.position.x > limitX)
    //    {
    //        moveX = -moveX;
    //    }

    //    if (transform.position.x < -limitX)
    //    {
    //        moveX = -moveX;
    //    }
    //}

    void SpawnEnemy()
    {
        //List<float> spawnPosX = new List<float>();
        //for (int i = 0; i < spawnNum; i++)
        //{
        //    float x = Mathf.Lerp(-spawnRangeX, spawnRangeX, i / (float)(spawnNum - 1));
        //    spawnPosX.Add(x);
        //}
        List<float> spawnPosX = new List<float> { -2.5f, -1.25f, 0, 1.25f, 2.5f };

        // ����
        for (int i = 0; i < spawnPosX.Count; i++)
        {
            // ���� ���� ����
            float temp;
            int randomIndex = Random.Range(i, spawnPosX.Count);
            temp = spawnPosX[i];
            spawnPosX[i] = spawnPosX[randomIndex];
            spawnPosX[randomIndex] = temp;
        }

        // List�� ������� {0f, 2.5f, -1.25f, 1.25f, -2.5f} �� �Ǿ�����

        // ��� ������ �ּ� min"�̻�" max"����" �������� ������
        // Random.Range�� �̻�-�̸� �̹Ƿ� +1 ���ٰ�
        int count = Random.Range(spawnNumMin, spawnNumMax+1);

        // �� �����ϱ�(������ ��� ������ �������Ƿ� �׸�ŭ �ݺ�)
        for (int i = 0; i < count; i++)
        {
            // ���� ������ ��ġ Vector3�� �ٽ� ����
            Vector3 spawnPos = new Vector3(spawnPosX[i], transform.position.y, 0);
            // �� ����
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
