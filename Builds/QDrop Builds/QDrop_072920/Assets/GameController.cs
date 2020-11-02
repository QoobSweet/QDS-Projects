using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public PegBoard GameBoard;

    public RawImage BoardDisplay;
    public RenderTexture BoardDisplay_texture;
    private Vector3[] _borderLocations = new Vector3[4];
    public Vector3[] GameBoard_BorderLocations
    {
        get
        {
            BoardDisplay.rectTransform.GetLocalCorners(_borderLocations);
            return _borderLocations;
        }
    }

    public Debug_Panel DebugPanel;
    


    // Start is called before the first frame update
    void Start()
    {
        

    }

    void Update()
    {
        DebugPanel.SetValue("MousePos", Input.mousePosition.ToString());



        BoardDisplay.rectTransform.GetWorldCorners(_borderLocations);

        int i = 0;
        foreach (var v in _borderLocations)
        {
            DebugPanel.SetValue("BoardCorner#" + i + " :", v.ToString());
            i++;
        }
        float _xSize = Mathf.Abs(_borderLocations[0].x) + Mathf.Abs(_borderLocations[2].x);
        float _ySize = Mathf.Abs(_borderLocations[0].y) + Mathf.Abs(_borderLocations[2].y);

        GameBoard.transform.localScale = new Vector3(_xSize, _ySize, GameBoard.transform.localScale.z);
        BoardDisplay_texture.width = Mathf.FloorToInt(_xSize);
        BoardDisplay_texture.height = Mathf.FloorToInt(_ySize);
    }
}
