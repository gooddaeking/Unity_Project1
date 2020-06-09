using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            BgmMgr.Instance.PlayBgm("bgm1");
        }
        if (Input.GetKeyDown("2"))
        {
            BgmMgr.Instance.PlayBgm("bgm2");
        }
        if (Input.GetKeyDown("3"))
        {
            BgmMgr.Instance.CrossFadeBgm("bgm1", 3.0f);
        }
        if (Input.GetKeyDown("4"))
        {
            BgmMgr.Instance.CrossFadeBgm("bgm2", 3.0f);
        }
    }
}
