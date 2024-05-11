using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetFloat("_Thickness", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        GetComponent<Renderer>().material.SetFloat("_Thickness", 0.01f);
    }

    public void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetFloat("_Thickness", 0f);
    }
}
