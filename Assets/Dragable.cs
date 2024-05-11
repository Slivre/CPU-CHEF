using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public GameObject parent;
    Vector3 MousePos;
    Vector3 MousePosOnClick;

    Vector3 ClickPosOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Input.mousePosition;
    }

    public void InitializeDrag()
    {
        MousePosOnClick = MousePos;
        Debug.Log($"InitialMousePos {MousePosOnClick}");
        ClickPosOffset = parent.transform.position - MousePosOnClick;
    }

    public void Drag()
    {
        parent.transform.position = MousePos + ClickPosOffset;
    }
}
