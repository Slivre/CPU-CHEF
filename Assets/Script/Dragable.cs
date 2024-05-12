using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public GameObject parent;
    Vector3 MousePos;
    Vector3 MousePosOnClick;

    Vector3 ClickPosOffset = Vector3.zero;

    public bool isUI;

    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Input.mousePosition;
    }

    public void InitializeDrag()
    {
        MousePosOnClick = MousePos;
        ClickPosOffset = parent.transform.position - MousePosOnClick;

        ClickPosOffset = Camera.main.ScreenToWorldPoint(MousePos) - parent.transform.position;
        collider.isTrigger = true;
    }

    public void Drag()
    {
       //parent.transform.position = MousePos + ClickPosOffset;

        parent.transform.position = Camera.main.ScreenToWorldPoint(MousePos) - ClickPosOffset;
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0;
        }
    }

    public void EndDrag()
    {
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 3;
        }
        collider.isTrigger =false;
    }
}
