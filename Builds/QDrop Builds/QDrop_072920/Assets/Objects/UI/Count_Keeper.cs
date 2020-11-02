using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Count_Keeper : MonoBehaviour
{
    private bool Initialized = false;
    public Image CurrencyIconDisplay;
    public TextMeshProUGUI CurrencyAmtDisplay;

    public string text { get { return CurrencyAmtDisplay.text; } set { CurrencyAmtDisplay.text = value; } }


    private void Start()
    {
        //this.gameObject.SetActive(false);
    }

    public void Init(Sprite CurrencyIcon, int DisplayAmt)
    {
        if (!Initialized)
        {
            CurrencyIconDisplay.sprite = CurrencyIcon;
            CurrencyAmtDisplay.text = DisplayAmt.ToString();
            //this.gameObject.SetActive(true);
            Initialized = true;
        }
        else
        {
            Debug.Log("Object already Initialized");
        }
    }

    public void SetCount(int DisplayAmt)
    {
        CurrencyAmtDisplay.text = DisplayAmt.ToString();
    }
}
