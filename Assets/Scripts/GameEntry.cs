using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntry : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        UIManager.Instance.Init();

        UIManager.Instance.Push<UIScreenMainMenu>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
