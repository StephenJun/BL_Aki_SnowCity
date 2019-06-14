using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntry : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIManager.Instance.Init();
        UIManager.Instance.Push<UIScreenDialogue>(false, 1001);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
