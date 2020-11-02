using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Debug_Panel : MonoBehaviour
{
    public bool Active = false;
    public float spacing;
    public float xOffset;
    public float yOffset;


    public GameObject Debug_Item_Template;
    private Dictionary<string, string> DataStorage = new Dictionary<string, string>();
    private Debug_Item[] OutputObjects = new Debug_Item[20];

    public void SetValue(string DebugID, string Value)
    {
        DataStorage[DebugID] = Value;
    }


    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.SetActive(Active);
        int _itemIndex = 0;
        if (DataStorage != null)
        {

            Vector3[] corners = new Vector3[4];
            this.GetComponent<RectTransform>().GetLocalCorners(corners);

            Vector3 _TLCorner = corners[1];



            foreach (var item in DataStorage)
            {
                Vector3 _position = _TLCorner + new Vector3(xOffset, yOffset + (spacing + 1) * _itemIndex, 0);

                if (OutputObjects[_itemIndex] == null)
                {
                    GameObject newItem = Instantiate(Debug_Item_Template, this.transform);

                    
                    newItem.transform.localPosition = _position;
                    OutputObjects[_itemIndex] = newItem.GetComponent<Debug_Item>();
                }
                else
                {
                    OutputObjects[_itemIndex].transform.localPosition = _position;
               
                }

                OutputObjects[_itemIndex].SetLabel(item.Key);
                OutputObjects[_itemIndex].SetValue(item.Value);
                _itemIndex++;
            }
        }
    }
}
