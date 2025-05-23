using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // 적 프리팹
    public float spawnSpan = 2f;         // 적 생성 간격
    public float spawnRangeX = 2.5f;      // X축 생성 범위
    public float spawnNum = 5;              // x축 생성 수
    public int spawnNumMin;                // 생성할 적의 최소 수
    public int spawnNumMax;                // 생성할 적의 최대 수
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
            yield return new WaitForSeconds(spawnSpan); // 2초 대기
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

        // 셔플
        for (int i = 0; i < spawnPosX.Count; i++)
        {
            // 랜덤 숫자 생성
            float temp;
            int randomIndex = Random.Range(i, spawnPosX.Count);
            temp = spawnPosX[i];
            spawnPosX[i] = spawnPosX[randomIndex];
            spawnPosX[randomIndex] = temp;
        }

        // List는 예를들어 {0f, 2.5f, -1.25f, 1.25f, -2.5f} 가 되어있음

        // 몇개를 뽑을지 최소 min"이상" max"이하" 랜덤으로 정하자
        // Random.Range는 이상-미만 이므로 +1 해줄것
        int count = Random.Range(spawnNumMin, spawnNumMax+1);

        // 적 생성하기(위에서 몇개를 뽑을지 정했으므로 그만큼 반복)
        for (int i = 0; i < count; i++)
        {
            // 적이 생성될 위치 Vector3로 다시 정의
            Vector3 spawnPos = new Vector3(spawnPosX[i], transform.position.y, 0);
            // 적 생성
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
