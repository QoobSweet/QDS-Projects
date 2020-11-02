using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[ExecuteInEditMode]
public class sel_BuildBlocks : MonoBehaviour
{

    private int ButtonCount = 0;
    public int WantedButtonCount = 0;
    public GameObject SelectionButtonPrefab;
    public RectTransform rectTransform;
    public List<GameObject> Buttons;
    public int ActiveButtonIndex = 0;

    public btn_selection ActiveButton;
    public GameObject CurrentActiveObject;

    [Header("Positional")]
    public float xOffset = 1;
    public float xSpacing = 1;



    // Start is called before the first frame update
    void Start()
    {
        ClearTrash();
    }

    // Update is called once per frame
    void Update()
    {
        if(WantedButtonCount < 0) { WantedButtonCount = 0; }
        rectTransform = SelectionButtonPrefab.GetComponent<RectTransform>();

  

        if (ButtonCount != WantedButtonCount)
        {
            int diff = WantedButtonCount - ButtonCount;
            if (diff > 0)
            {
                int _sIndex = Buttons.Count;
                for(int i = diff; i > 0; i--)
                {
                    GameObject _goc;
                    if (Application.isEditor)
                    {
                        _goc = (GameObject)PrefabUtility.InstantiatePrefab(SelectionButtonPrefab, transform);
                    }
                    else
                    {
                        _goc = Instantiate(SelectionButtonPrefab, transform);
                    }
                    _goc.GetComponent<btn_selection>().OnSetActive += UpdateActiveButton;
                    Buttons.Add(_goc);
                }
            }
            else
            {
                for (int i = diff; i < 0; i++)
                {
                    int index = Buttons.Count - 1;
                    if (index >= 0)
                    {
                        GameObject tempCache = Buttons[index];
                        Buttons.Remove(tempCache);
                        SafeDestroy(tempCache);
                    }
                }
            }
            ButtonCount = Buttons.Count;
        }
        UpdatePositions();
    }

    public void ClearTrash()
    {
        Transform[] childs = transform.GetComponentsInChildren<Transform>();
        foreach(Transform _t in childs)
        {
            if (_t != this.transform)
            {
                if (!Buttons.Contains(_t.gameObject)) { SafeDestroy(_t.gameObject); }
            }
        }

    }

    public void SafeDestroy(GameObject go)
    {
        if (Application.isEditor)
        {
            DestroyImmediate(go);
        }
        else
        {
            Destroy(go);
        }
    }


    public void UpdateActiveButton(GameObject AssignedObj, btn_selection Button)
    {
        if (ActiveButton)
        {
            ActiveButton.Deactivate();
        }

        ActiveButton = Button;
        CurrentActiveObject = AssignedObj;
    }


    public void UpdatePositions()
    {
        if (Buttons.Count > 0)
        {
            for (int i = 0; i < Buttons.Count; i++)
            {
                if (Buttons[i])
                {
                    rectTransform = Buttons[i].GetComponent<RectTransform>();
                    rectTransform.position = this.transform.position + new Vector3(xSpacing * i, 0, 0);

                }
                else
                {
                    GameObject _goc;
                    if (Application.isEditor)
                    {
                        _goc = (GameObject)PrefabUtility.InstantiatePrefab(SelectionButtonPrefab, transform);
                    }
                    else
                    {
                        _goc = Instantiate(SelectionButtonPrefab, transform);
                    }
                    _goc.GetComponent<btn_selection>().OnSetActive += UpdateActiveButton;
                    Buttons[i] = _goc;
                    ClearTrash();
                }
            }
        }
    }
}
