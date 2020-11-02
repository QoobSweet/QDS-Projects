using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        SetMainCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if(MainCamera == null) { SetMainCamera(); }
    }

    public void SetMainCamera()
    {
        MainCamera = Camera.main;
    }
}
