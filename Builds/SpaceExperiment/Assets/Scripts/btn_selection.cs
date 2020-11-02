using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class btn_selection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image Highlight;
    public Image ActiveLayer;
    public RawImage Obj_Display;
    public Slot_obj_Render slot_Obj_Render;
    public GameObject TempPrefab;
    private GameObject CurrentAssignedObj;
    public bool ActiveButton = false;


    public delegate void SetThisActive(GameObject AssignedObj, btn_selection Button);
    public event SetThisActive OnSetActive;



    // Start is called before the first frame update
    void Start()
    {
        if(!Highlight) { transform.Find("Hightlight"); }

        Highlight.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Highlight.enabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Highlight.enabled = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        AssignObject(TempPrefab);
        SetActive(CurrentAssignedObj);
    }

    public void AssignObject(GameObject Prefab)
    {
        slot_Obj_Render.AssignObject(TempPrefab);
        Obj_Display.texture = slot_Obj_Render.renderTexture;
        CurrentAssignedObj = TempPrefab;
    }

    public void SetActive(GameObject AssignedObj)
    {
        if(OnSetActive != null)
        {
            OnSetActive(AssignedObj, this);
        }
        ActiveLayer.enabled = true;
    }

    public void Deactivate()
    {
        ActiveLayer.enabled = false;
    }

    public GameObject GetActiveObject() { return CurrentAssignedObj; }
}
