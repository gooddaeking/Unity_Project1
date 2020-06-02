using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public GameObject bulletFactory;        //총알 프리팹
    public GameObject firePoint;            //발사지점 좌표
    public GameObject[] tail;
    public float fireTime = 3.0f;
    float currTime = 0.0f;
  
    bool fireOn = false;
    bool birdOn = false;
    // 대신 사용할수 있는 함수 activeself
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += 1;
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        if (count % 60 == 0)
        {
            Fire();
        }
        Bird();
    }

    private void Fire()
    {
        //마우스 왼쪽버튼 or 왼쪽컨트롤 키
        //if (Input.GetButtonDown("Fire1"))
        {
            //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다

            //총알 게임오브젝트 생성
            GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트의 위치 지정
            bullet.transform.position = firePoint.transform.position;
        }
    }

    private void Bird()
    {
        //마우스 왼쪽버튼 or 왼쪽컨트롤 키
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!birdOn)
            {
                for (int i = 0; i < tail.Length; i++)
                {
                    tail[i].SetActive(true);
                    birdOn = true;
                }
            }
            else
            {
                for (int i = 0; i < tail.Length; i++)
                {
                    tail[i].SetActive(false);
                    birdOn = false;
                }
            }
            
        }

       
    }

    
}
