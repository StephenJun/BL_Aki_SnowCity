using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonInteraction : MonoBehaviour {

    public float maxSearchDis = 5.0f;

    private InteractableObj interactableObj;

    private Camera m_camera;

    private void Start()
    {
        m_camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UIManager.Instance.Push<UIScreenDialogue>(UIDepthConst.MiddleDepth, false, 10001);
            interactableObj = SearchInteractableObj();
            if (interactableObj)
            {
                print("交互");
                
            }
        }
    }

    public InteractableObj SearchInteractableObj()
    {
        Ray ray = m_camera.ScreenPointToRay(new Vector2(Screen.width, Screen.height)/2);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxSearchDis))
        {
            InteractableObj obj = hit.collider.GetComponentInChildren<InteractableObj>();
            if(obj != null)
            {
                return obj;
            }
        }
        return null;
    }

}
