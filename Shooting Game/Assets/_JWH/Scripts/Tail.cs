using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    // 꼬랑지가 플레이어를 따라다니려면
    // 플레이어의 위치를 알아야 한다
    public GameObject target;       //플레이어 오브젝트

    public float x;
    public float y;

    public float speed = 3.0f;      //따라가는 속도

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 dir = new Vector3(target.transform.position.x - transform.position.x - x, target.transform.position.y - transform.position.y - y,0);
        //dir.Normalize();
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
