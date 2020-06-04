using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //보스 총알 발사 (총알패턴)
    // 1. 플레이어를 향해서 총알발사
    // 2. 회전총알 발사


    public GameObject bulletFactory;        //총알 프리팹
    public GameObject target;
    public float fireTime = 1.0f;
    float currTime;
    public float fireTime1 = 1.5f;
    float currTime1;
    public int bulletMax = 10;

    // Update is called once per frame
    void Update()
    {
        
        AutoFire1();
        AutoFire2();
    }

    private void AutoFire1()
    {
        if (target != null)
        {
            currTime += Time.deltaTime;
            if (currTime > fireTime)
            {
                //총알공장에서 총알생성
                GameObject bullet = Instantiate(bulletFactory);
                bullet.transform.position = transform.position;
                //플레이어 방향 구하기
                Vector3 dir = target.transform.position - transform.position;
                dir.Normalize();
                //총구의 방향도 맞춰준다(이게 중요함)
                bullet.transform.up = dir;
                currTime = 0.0f;
            }
        }
    }

    private void AutoFire2()
    {
        if (target != null)
        {
            currTime1 += Time.deltaTime;
            if (currTime1 > fireTime1)
            {
                for (int i = 0; i < bulletMax; i++)
                {
                    GameObject bullet = Instantiate(bulletFactory);
                    bullet.transform.position = transform.position;
                    //360도 방향으로 총알발사
                    float angle = 360.0f / bulletMax;
                    //총구의 방향도 맞춰준다(이게 중요함)
                    bullet.transform.eulerAngles = new Vector3(0, 0, i * angle);
                }
                currTime1 = 0.0f;
            }
        }
    }

    

}
