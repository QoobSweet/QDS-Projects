using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharCreationController : MonoBehaviour {
    private Dictionary<string, SliderBehavior> listStats = new Dictionary<string, SliderBehavior>();
    private Dictionary<string, float> defStats = new Dictionary<string, float>();
    private Dictionary<string, bool> StatRegSet = new Dictionary<string, bool>();
    private bool Loaded = false;
    private static bool ControllerLoaded = false;
    private static Transform self;
    private static StatController StController;
    public Sprite DefUIbkg;

    // Use this for initialization
    void Start()
    {
        Dev_UI DevConsole = this.gameObject.AddComponent<Dev_UI>();
        self = this.transform;
        defStats = Defaults.Dict_Stats();
        foreach (string kname in defStats.Keys)
        {
            if (!StatRegSet.ContainsKey(kname))
            {
                StatRegSet.Add(kname, false);
            }
        }
        //tempsets
        StatRegSet["Attunement"] = true;
        StatRegSet["Sanity"] = true;
        StatRegSet["Willpower"] = true;

    }

	void Update () {
        if (!Loaded) {
            LoadStatController();
            listStats = this.transform.Find("Stats").GetComponent<StatController>().listSliders;
            foreach (string kname in defStats.Keys)
            {
                if (listStats.ContainsKey(kname))
                {
                    StatRegSet[kname] = true;
                }
            }
            int stat_check = 0;
            if (stat_check < StatRegSet.Keys.Count)
            {
                foreach (var v in StatRegSet)
                {
                    if (v.Value)
                    {
                        stat_check++;
                    }
                }
                SetSlidersValues();
                if (stat_check == StatRegSet.Count)
                {
                    Loaded = true;
                    StController.SetActive();
                }
            }
        }

    }

    public static void CreateEmtpyObj(GameObject parent, string name, Vector2 pos)
    {

    }


    public static void LoadStatController()
    {
        StController = self.Find("Stats").GetComponent<StatController>();
        ControllerLoaded = true;
    }
    private void SetSlidersValues()
    {
        if (ControllerLoaded)
        {
            foreach (var keyVal in StatRegSet)
            {
                if (keyVal.Value)
                {
                    StController.SetValue(keyVal.Key, defStats[keyVal.Key]);
                    
                }
            }
        }
    }
}
