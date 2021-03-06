﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알클래스 하는일
    //플레이어가 발사 버튼을 누르면
    //총알이 생성된 후 발사하고싶은 방향(위)으로 움직인다

    public float speed = 10.0f;



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //자기자신도 없애고 충돌된 오브젝트도 없앤다
        // Destroy(gameObject, 1.0f); 1초 후에 없앤다
        Destroy(gameObject);
        if (collision.collider.name.Contains("Player"))
            {
                Destroy(collision.gameObject);
            } 
        Score.score += 10;

        ShowEffect();
    }

    private void ShowEffect()
    {
        
    }


    ////카메라 화면 밖으로 나가면 지워주는 함수
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}

}
