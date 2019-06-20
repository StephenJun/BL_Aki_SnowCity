using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{

    public Dictionary<Type, UIScreen> screenDic;
    private Stack<UIScreen> screenStacks;  //栈
    private Transform uiRoot;
    private List<int> res = new List<int>();
    private Stack<int> stack = new Stack<int>();

    //非静态的字段，变量，属性不能用于静态的函数下
    public void Init()
    {
        screenDic = new Dictionary<Type, UIScreen>();
        screenStacks = new Stack<UIScreen>();
        uiRoot = GameObject.Find("Canvas").transform;
        UIScreen[] screens = ResourceLoader.Instance.LoadAll<UIScreen>("UIScreens");
        for (int i = 0; i < screens.Length; i++)
        {
            screenDic.Add(screens[i].GetType(), screens[i]);
        }
    }

    //重载， 泛型， where用于约束泛型
    public T Push<T>(bool hidePrevious = true, params object[] data) where T : UIScreen
    {
        return (T)Push(typeof(T), hidePrevious, data);
    }

    //打开一个新的窗口，并选择是否叠在前一个窗口上
    public UIScreen Push(Type screenType, bool hidePrevious = true, params object[] data)
    {
        if (!screenDic.ContainsKey(screenType))
        {
            Debug.LogWarning("You are trying to open a screen not included in the folder");
            return null;
        }

        if (hidePrevious && screenStacks.Count > 0)
        {
            screenStacks.Peek().gameObject.SetActive(false);
            screenStacks.Peek().OnHide();
        }
        UIScreen screenToPush = UnityEngine.Object.Instantiate(screenDic[screenType], uiRoot);
        screenToPush.OnInit(data);
        screenToPush.OnShow();
        screenToPush.gameObject.name = screenType.Name;
        screenStacks.Push(screenToPush);
        return screenToPush;
    }

    //关闭当前打开的窗口，并打开前一个窗口
    public UIScreen Pop(bool destroy = true)
    {
        UIScreen screenToPop = screenStacks.Pop();
        if (destroy)
        {
            UnityEngine.Object.Destroy(screenToPop.gameObject);
        }
        else
        {
            screenToPop.gameObject.SetActive(false);
        }
        screenStacks.Peek().gameObject.SetActive(true);
        screenStacks.Peek().OnShow();
        return screenToPop;
    }
}
