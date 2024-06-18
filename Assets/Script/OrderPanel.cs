using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class OrderPanel : MonoBehaviour
{
    Animator ac;
    public bool expanded = true;

    public TMP_Text OrderNumberText;
    public TMP_Text CustomerNameText;
    public TMP_Text TimeText;
    public TMP_Text SteakCookLevelText;

    public Image SteakImage;

    public int currentOrderNumber = 2234;
    public List<string> CustomerNames;
    public Sprite[] CookStateSprite;

    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExpandCollapse()
    {
        string Clip = expanded ? "OrderPanelCollapse" : "OrderPanelExpand";
        ac.Play(Clip);
        expanded = !expanded;
    }

    public void NewOrder(SteakState.SteakCookState targetCookState)
    {
        OrderNumberText.text = currentOrderNumber++.ToString();
        CustomerNameText.text = CustomerNames[Random.Range(0, CustomerNames.Count)];
        SteakCookLevelText.text = targetCookState.ToString();
        SteakImage.sprite = CookStateSprite[(int)targetCookState];
    }

    public void BlankOrder()
    {
        OrderNumberText.text = "0000";
        CustomerNameText.text = " ";
        SteakCookLevelText.text = "Null";
        SteakImage.sprite = CookStateSprite[5];
    }
}
