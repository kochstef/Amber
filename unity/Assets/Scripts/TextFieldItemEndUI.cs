using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFieldItemEndUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro txt;
    public GameObject checkMark;
    public GameObject crossMark;

    public void SetText(string str)
    {
        txt.text = str;
    }

    public void SetWrongRight(bool right)
    {
        checkMark.active = right;
        crossMark.active = !right;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
