using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    Color InitialColor;
    Material Mat;
    // Start is called before the first frame update
    void Start()
    {
        Mat = GetComponent<Renderer>().material;
        InitialColor = Mat.GetColor("_Color");
        Mat.SetFloat("_Thickness", 0f);
        Mat.SetColor("_Color", new Color(0,0,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        Mat.SetFloat("_Thickness", 0.01f);
        Mat.SetColor("_Color", InitialColor);
    }

    public void OnMouseExit()
    {
        Mat.SetFloat("_Thickness", 0f);
        Mat.SetColor("_Color", new Color(0, 0, 0, 0));
    }
}
