using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class score_Keeper : MonoBehaviour
{
    private bool Initialized = false;
    public Image CurrencyIconDisplay;
    public TextMeshProUGUI CurrencyAmtDisplay;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Init(Vector3 Position, Sprite CurrencyIcon, int DisplayAmt)
    {
        if (!Initialized)
        {
            CurrencyIconDisplay.sprite = CurrencyIcon;
            CurrencyAmtDisplay.text = DisplayAmt.ToString();
            this.transform.position = Position;
            this.gameObject.SetActive(true);
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
