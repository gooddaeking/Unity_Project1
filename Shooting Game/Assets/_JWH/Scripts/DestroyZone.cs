using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    //트리거 감지 후 해당 오브젝트 삭제
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        //이곳에서 트리거에 감지된 오브젝트 제거하기 ( 총알, 에너미)
        //Destroy(collider.gameObject);

        //if(other.gameObject.name.Contains("Bullet"))
        //{
        //    other.gameObject.SetActive(false);
        //}

        //레이어로 충돌체 찾기
        if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            other.gameObject.SetActive(false);
            //플레이어 오브젝트의 컴포넌트에 접근해서 처리한다
            playerFire pf = GameObject.Find("Player").GetComponent<playerFire>();
            pf.bulletPool.Add(other.gameObject);
        }
    }
}
