using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeColorText : MonoBehaviour
{
    public Color startColor;
    public Color mouseOverColor;
    public string startText;
    private bool mouseOver = false;
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }
    void OnMouseEnter()
    {
        mouseOver = true;
        text.text = "<color=#FFB70000>" + startText + "</color>";
        //text.color = mouseOverColor;
        //GetComponent<Renderer>().material.SetColor("MouseOver",mouseOverColor);
    }
    void OnMouseExit()
    {
        mouseOver = false;
        text.text = "<color=#FFFFFF00>" + startText + "</color>";
        //text.color = startColor;
        //GetComponent<Renderer>().material.SetColor("MouseExit", startColor);

    }
}
