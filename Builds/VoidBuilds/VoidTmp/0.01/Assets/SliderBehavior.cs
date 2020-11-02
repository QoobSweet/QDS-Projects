using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehavior : MonoBehaviour {
    public Transform slInner;
    private float val;
    public GameObject ObjStat;
    public GameObject ObjName;
    public Slider objSlider;
    public float value = 0;
    public string label = "";
    // Use this for initialization

    public void Start()
    {
        slInner = this.gameObject.transform.GetChild(0).transform;
        ObjStat = GetObjStat();
        ObjName = GetObjName();
        objSlider = GetSlider();
        label = GetObjName().GetComponent<Text>().text;
        value = GetSlider().value;
        var parent = this.gameObject.transform.GetComponentInParent<StatController>();
        parent.Register(label, this);
    }




    public float GetValue()
    {
        return this.val;
    }
    public string GetName()
    {
        return this.label;
    }
    public void UpdateValue()
    {
        val = GetSlider().value;
        GetObjStat().GetComponent<Text>().text = val.ToString();
    }
    public void SetValue(float v)
    {
        GetSlider().value = v;
    }


    private GameObject GetObjStat()
    {
        return slInner.Find("Stat").gameObject;
    }
    private GameObject GetObjName()
    {
        return slInner.Find("Name").gameObject;
    }
    private Slider GetSlider()
    {
        return slInner.gameObject.transform.Find("Slider").gameObject.GetComponent<Slider>();
    }
}
