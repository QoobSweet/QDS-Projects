using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour {
    private Transform self;
    private SliderBehavior[] sliders;
    private GameObject stpool;
    public Dictionary<string, SliderBehavior> listSliders = new Dictionary<string, SliderBehavior>();
    public Dictionary<string, float> StatValues = new Dictionary<string, float>();
    public float statPoolMax = Defaults.STATPOOL;
    public float statPool;
    private bool Loaded = false;
    // Use this for initialization
    private void Awake()
    {
        self = this.gameObject.transform;

    }
    void Start()
    {

        stpool = self.Find("StatPool").gameObject;

    }


    void Update()
    {
        if (Loaded)
        {
            foreach (var s in listSliders)
            {
                var slider = s.Value;
                slider.UpdateValue();
                string n = slider.GetName();
                float v = slider.GetValue();
                StatValues[n] = v;
            }
            UpdateStatPool();
        }
    }

    public void Register(string name, SliderBehavior slider)
    {
        listSliders.Add(name, slider);
        float v = slider.GetValue();
        StatValues.Add(name, v);
    }
    public float GetStatValue(string key)
    {
        return StatValues[key];
    }
    public void SetValue(string name, float value)
    {
        if (listSliders.ContainsKey(name))
        {
            SliderBehavior slider = listSliders[name];
            slider.SetValue(value);
        }
        else
        {
            //debug
        }
    }
    public void SetActive()
    {
        Loaded = true;
    }
    public Dictionary<string, float> GetSliderVal()
    {
        Dictionary<string, float> list = new Dictionary<string, float>();
        foreach(var v in listSliders)
        {
            list.Add(v.Key, v.Value.value);
        }
        return list;
    }
  
    private void UpdateStatPool()
    {
        float p = 0;
        foreach(var i in StatValues)
        {
            float v = i.Value;
            p = p + v;
        }
        statPool = statPoolMax - p;

        stpool.transform.Find("Value").GetComponent<Text>().text = statPool.ToString();
    }
    
  
}
