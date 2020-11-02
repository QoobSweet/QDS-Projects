using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Debug_Item : MonoBehaviour
{
    public TextMeshProUGUI Label;
    public TextMeshProUGUI Output;



    public void SetLabel(string Name)
    {
        Label.text = Name;
    }
    public void SetValue(string Value)
    {
        Output.text = Value;
    }
}
