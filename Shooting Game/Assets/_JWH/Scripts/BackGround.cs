using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    Renderer bg;
    float speed = 0.5f;
    Vector2 xy = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        bg = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //캐스팅해줘야한다
        //xy.Set(0, xy.y + (speed * Time.deltaTime));
        xy.y += Time.deltaTime * speed;
        
        bg.material.mainTextureOffset = xy;
    }
}
