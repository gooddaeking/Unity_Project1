using System.Collections;
using System.Collections.Generic;
using TreeEditor;
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

    //카메라 화면 밖으로 나가면 지워주는 함수

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
