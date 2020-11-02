using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class btn_BuyPanel : MonoBehaviour
{
    private bool Initialized = false;

    public TextMeshProUGUI ItemTitle;
    public TextMeshProUGUI CostAmount;
    public Image CurrencyIcon;
    public TextMeshProUGUI ItemDescription;



    private void Start()
    {
        this.gameObject.SetActive(false);
        Initialized = false;
    }

    public void Init(string ItemTitle, string ItemDescription, int CostAmount, Sprite CurrencyIcon)
    {
        if (!Initialized)
        {
            this.ItemTitle.text = ItemTitle;
            this.CostAmount.text = CostAmount.ToString();
            this.CurrencyIcon.sprite = CurrencyIcon;
            this.ItemDescription.text = ItemDescription;

            this.gameObject.SetActive(true);
            Initialized = true;
        }
        else
        {
            Debug.Log("Object is Already Initialized");
        }
    }

    public void UpdateTitle(string NewItemTitle)
    {
        if (Initialized)
        {
            this.ItemTitle.text = NewItemTitle;
        }
        else
        {
            Debug.Log("Object is not Initialized. Please Use <object>.Init(<params>)");
        }
    }

    public void UpdateCost(int NewCostAmount)
    {
        if (Initialized)
        {
            this.CostAmount.text = NewCostAmount.ToString();
        }
        else
        {
            Debug.Log("Object is not Initialized. Please Use <object>.Init(<params>)");
        }
    }

    public void UpdateDescription(string NewItemDescription) 
    {
        if (Initialized)
        {
            this.ItemDescription.text = NewItemDescription;
        }
        else
        {
            Debug.Log("Object is not Initialized. Please Use <object>.Init(<params>)");
        }
    }
}
