using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneMgr.Instance.LoadScene("GameScene");
    }

    public void OnReStartButtonClick()
    {
        SceneMgr.Instance.LoadScene("StartScene");
    }

    public void OnMenuButtonClick()
    {

    }

    public void OnOptionButtonClick()
    {

    }
}
