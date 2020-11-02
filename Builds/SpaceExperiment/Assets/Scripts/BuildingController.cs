using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BuildingBlocks;

public class BuildingController : MonoBehaviour
{
    public UI_Player PlayerUI;
    public GameObject BlockPrefab;
    public GameObject MouseCursor;
    public Vector3 CurrentSnapPoint;
    public Vector3 NewBlockOffset;
    public TextMeshProUGUI sts_BuildMode;


    public bool inBuildMode = false;

    public bool MouseOnBlock = false;
    public GameObject ActiveBlock_GO;
    public Block ActiveBlock;
    public Vector3[] SnapPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            inBuildMode = !inBuildMode;
         
            //if buildMode is off, reset variables
            if (!inBuildMode)
            {
                    ResetMouseActives();
            }
            
        }
        sts_BuildMode.text = "BuildMode: " + (inBuildMode ? "Active" : "Inactive");

        if (inBuildMode)
        {
            RaycastHit hit;

            if (Physics.Raycast(GameControl.MainCamera.ScreenPointToRay(Input.mousePosition), out hit) && hit.transform.GetComponent<Block>() != null)
            { 
                ActiveBlock_GO = hit.transform.gameObject;
                ActiveBlock = ActiveBlock_GO.GetComponent<Block>();
                UpdateMouseHit(hit);
                
                if (MouseOnBlock)
                {
                    UpdateCursorPosition(hit);
                    UpdateNewBlockOffset();
                    if (Input.GetMouseButtonDown(0))
                    {
                        var _newBlock = Instantiate(PlayerUI.GetActiveBuildBlock(), NewBlockOffset, Quaternion.identity, ActiveBlock_GO.transform);
                    }

                    if (Input.GetMouseButtonDown(1))
                    {
                        Destroy(ActiveBlock_GO);
                    }

                } else { ResetMouseActives(); }
            } else { ResetMouseActives(); }

        }


    }



    public void ResetMouseActives()
    {
        MouseOnBlock = false;
        ActiveBlock = null;
        ActiveBlock_GO = null;
        MouseCursor.SetActive(false);
        CurrentSnapPoint = new Vector3(0,0,0);
    }

    public void UpdateMouseHit(RaycastHit hit)
    {
        MouseOnBlock = true;
        ActiveBlock.TriggerRayHit(hit);
        SnapPoints = ActiveBlock.SnapPointsOut;
    }

    public void UpdateCursorPosition(RaycastHit hit)
    {//hit.point
        Vector3 _origin = hit.point;

        List<Common.Distance> _distanceList = new List<Common.Distance>();

        for(int i = 0; i < SnapPoints.Length; i++)
        {
            float _distance = Vector3.Distance(_origin, SnapPoints[i]);
            _distanceList.Add(new Common.Distance(_distance, i));        
        }

        //sort distances
        _distanceList.Sort(delegate (Common.Distance t1, Common.Distance t2) { 
            return (t1.distance.CompareTo(t2.distance)); 
        });



        MouseCursor.transform.position = SnapPoints[_distanceList[0].index];
        CurrentSnapPoint = SnapPoints[_distanceList[0].index];
        MouseCursor.SetActive(true);
    }

    public void UpdateNewBlockOffset()
    {
        Vector3 _offset = MouseCursor.transform.position - ActiveBlock_GO.transform.position;


        NewBlockOffset = (_offset * 2) + ActiveBlock_GO.transform.position;
    }

}
