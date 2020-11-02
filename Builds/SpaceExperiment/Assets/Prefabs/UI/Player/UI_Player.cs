using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Player : MonoBehaviour
{
    public UI_HotBar HotBar;


    // Start is called before the first frame update
    void Start()
    {
        if (!HotBar)
        {
            HotBar = this.GetComponentInChildren<UI_HotBar>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject GetActiveBuildBlock()
    {
        return HotBar.BlockSelection.CurrentActiveObject;
    }
}
