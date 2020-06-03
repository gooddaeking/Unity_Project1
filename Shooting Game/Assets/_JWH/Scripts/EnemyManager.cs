//using System; //이놈이 있으면 Random함수를 사용 불가
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemyManager : MonoBehaviour
{
    //에너미매니저 역할
    //에너미들을 공장에서 찍어낸다 (에너미 프리팹)
    //에너미 스폰타임, 에너미 스폰위치

    public GameObject enemyFactory;         //에너미 공장 (에너미 프리팹)
    public GameObject spawnPoint;           //에너미 스폰위치
    float spawnTime = 1.0f;                        //에너미 스폰타임 (몇초에 한번씩)
    float currTime;                         //누적타임

    // Update is called once per frame
    void Update()
    {
        //에너미 생성
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        //몇초에 한번씩 이벤트 발동
        //시간 누적타임으로 계산한다
        //게임에서 정말 자주 사용함

        currTime += Time.deltaTime;
        if(currTime > spawnTime)
        {
            //누적된 타임 초기화(반드시 필요하다)
            currTime = 0.0f;
            //스폰타임을 랜덤으로
            spawnTime = Random.Range(0.5f, 2.0f);

            //에너미 생성
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = spawnPoint.transform.position + Vector3.right * Random.Range(-2.5f,2.5f);
        }
    }
}
