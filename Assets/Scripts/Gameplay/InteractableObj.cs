using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour {

    public InteractiveLayer layer;
    public Transform focusOn;
}

public enum InteractiveLayer
{
    NPC,
    Props,
    Other
}