using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerFire : MonoBehaviour
{
    public GameObject bulletFactory;        //총알 프리팹
    public GameObject firePoint;            //발사지점 좌표

    public AudioSource audio;
    public float lineWidth = 1.0f;
    Vector2 xy = new Vector2(0, 0);

    //오브젝트 풀링
    //오브젝트 풀링에 사용할 최대 총알개수
    int poolSize = 20;
    //1. 배열
    //GameObject[] bulletPool;
    //int fireIndex;
    //2. 리스트
    public List<GameObject> bulletPool;

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
        audio = GetComponent<AudioSource>();

        //오브젝트 풀링 초기화
        InitObjectPooling();

        //2. 리스트
        bulletPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {

        }
    }

    private void InitObjectPooling()
    {
        //1. 배열
        //bulletPool = new GameObject[poolSize];
        //for (int i = 0; i < poolSize; i++)
        //{
        //    GameObject bullet = Instantiate(bulletFactory);
        //    bullet.SetActive(false);
        //    bulletPool[i] = bullet;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //Fire();
        //FireRay();
        //레이저 보여주는 기능이 활성화되어있을 때만
        //레이져를 보여준다
        ShowRay();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            //1. 배열 오브젝트풀링으로 총알 발사
            
            //bulletPool[fireIndex].SetActive(true);
            //bulletPool[fireIndex].transform.position = firePoint.transform.position;
            //bulletPool[fireIndex].transform.up = firePoint.transform.up;
            //fireIndex++;
            //if(fireIndex >= poolSize)
            //{
            //    fireIndex = 0;
            //}

            //2. 리스트 오브젝트 풀링으로 총알발사 ( 진짜 오브젝트 풀링)
            if(bulletPool.Count >0)
            {
                GameObject bullet = bulletPool[0];
                bullet.SetActive(true);
                bullet.transform.position = firePoint.transform.position;
                bullet.transform.up = firePoint.transform.up;
                //오브젝트 풀에서 빼준다
                bulletPool.Remove(bullet);
            }
            else // 남은 총알이 없다, 고로 Instanciate으로 생성해준다
            {
                GameObject bullet = Instantiate(bulletFactory);
                bullet.SetActive(false);
                bulletPool.Add(bullet);
            }

            //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다

            //총알 게임오브젝트 생성
            //GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트의 위치 지정
            //bullet.transform.position = firePoint.transform.position;
        }
    }

    void ShowRay()
    {
        timer += Time.deltaTime;
        if(timer > rayTime)
        {
            lr.enabled = false;
            timer = 0.0f;
        }
    }

    public void FireRay()
    {

            //레이져 사운드 재생
            audio.Play();
            //라인렌더러 컴포넌트 활성화
            lr.enabled = true;
            //라인 시작점, 끝점
            Vector3 pos = transform.position;
            lr.SetPosition(0, pos + Vector3.up * 1);
            lr.SetPosition(1, transform.position + Vector3.up * 10);
            //오브젝트와 충돌지점이 끝점이다
            
            

            //Ray로 충돌처리
            Ray ray = new Ray(transform.position, Vector3.up);
            RaycastHit hitInfo; //Ray와 충돌된 오브젝트 정보를 담는다
            if (Physics.Raycast(ray, out hitInfo))
            {
                //lr.SetPosition(1, hitInfo.point);
                if(hitInfo.collider.name.Contains("Enemy") ||
                    hitInfo.collider.name.Contains("Bullet"))
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
            else
            {
                //충돌된 오브젝트가 없으니 끝점을 정해준다
                //lr.SetPosition(1, transform.position + Vector3.up * 10);
            }
        if(lr.enabled)
        {
            xy.y += Time.deltaTime * 5.0f;
            lr.material.mainTextureOffset = xy;
            //lineWidth -= 0.05f;
            //lr.SetWidth(lineWidth, lineWidth);
            //if(lineWidth < 0.0f)
            //{
            //    lineWidth = 0.0f;
            //}
            
        }
        else
        {
            lineWidth = 1.0f;
        }
    }
}
