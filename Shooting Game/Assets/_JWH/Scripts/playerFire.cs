using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerFire : MonoBehaviour
{
    public GameObject bulletFactory;        //총알 프리팹
    public GameObject firePoint;            //발사지점 좌표
    

    //레이저를 발사하기 위해서는 라인렌더러가 필요하다
    //선은 최소 2개의 점이 필요하다(시작점, 끝점)
    LineRenderer lr;        //라인렌더러 컴포넌트
    
    //일정시간만 레이져 보여주기
    public float rayTime = 0.3f;
    float timer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        //라인렌더러 컴포넌트 추가
        lr = GetComponent<LineRenderer>();
        //중요!!!
        //게임오브젝트는 활성화 비활성화 => SetActive() 함수 사용
        //컴포넌트는 enabled 속성 사용
    }

    // Update is called once per frame
    void Update()
    {
        FireRay();
        //레이저 보여주는 기능이 활성화되어있을 때만
        //레이져를 보여준다
        if (lr.enabled) ShowRay();
    }

    private void ShowRay()
    {
        timer += Time.deltaTime;
        if(timer > rayTime)
        {
            lr.enabled = false;
            timer = 0.0f;
        }
    }

    private void FireRay()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            //라인렌더러 컴포넌트 활성화
            lr.enabled = true;
            //라인 시작점, 끝점
            Vector3 pos = transform.position;
            lr.SetPosition(0, pos);
            //lr.SetPosition(1, transform.position + Vector3.up * 10);
            //오브젝트와 충돌지점이 끝점이다

            //Ray로 충돌처리
            Ray ray = new Ray(transform.position, Vector3.up);
            RaycastHit hitInfo; //Ray와 충돌된 오브젝트 정보를 담는다
            if (Physics.Raycast(ray, out hitInfo))
            {
                lr.SetPosition(1, hitInfo.point);
                if(hitInfo.collider.name.Contains("Enemy") ||
                    hitInfo.collider.name.Contains("Bullet"))
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
            else
            {
                //충돌된 오브젝트가 없으니 끝점을 정해준다
                lr.SetPosition(1, transform.position + Vector3.up * 10);
            }
        }
    }
}
