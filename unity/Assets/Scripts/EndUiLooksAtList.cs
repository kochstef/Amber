using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndUiLooksAtList : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro txt;

    public void SetText(string txt)
    {
        this.txt.text = txt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
