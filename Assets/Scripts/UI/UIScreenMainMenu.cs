using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScreenMainMenu : UIScreen
{


    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("InGame");
        UIManager.Instance.Push<UIScreenHUD>();
    }

    public override void OnClose()
    {

    }

    public override void OnHide()
    {

    }

    public override void OnShow()
    {

    }
}
