using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public partial class PegBoard : MonoBehaviour
{


    private int PointScore = 0;
    public TextMeshProUGUI PointScore_Out;

    //dynamically link class to any PegBoard Object that invokes it
    //never cached....could work to prevent cheating??
    internal _BPositions BorderPositions { get { return new _BPositions(this); } }
    internal class _BPositions
    {
        PegBoard parent;

        public float _xOffset { get { return parent.transform.localScale.x / 2; } }
        public float _yOffset { get { return parent.transform.localScale.y / 2; } }

        public float _xLeftBorderPos { get { return parent.transform.position.x - _xOffset; } }
        public float _xRightBorderPos { get { return parent.transform.position.x + _xOffset; } }

        public float _yTopBorderPos { get { return parent.transform.position.y + _yOffset; } }
        public float _yBottomBorderPos { get { return parent.transform.position.y - _yOffset; } }

        internal _BPositions(PegBoard parent)
        {
            this.parent = parent;
        }
    }

    


    public delegate void CoinUpdate(int Count);
    public event CoinUpdate UpdateCoins;
    public void OnCoinUpdate(int Amount)
    {
        if (UpdateCoins != null)
        {
            UpdateCoins(Amount);
        }
    }
    public void ProcessCoinIncrease(int Amount)
    {
        PointScore += Amount;
        PointScore_Out.text = PointScore.ToString();
        OnCoinUpdate(Amount);
    }

    public void Update()
    {
        UpdateBoard();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnBall();
        }
    }

    public void Start()
    {
        ResetBoard();
    }


    public Dictionary<int, PegRow> PegRows = new Dictionary<int, PegRow>();
    public GameObject PegTemplate;
    public GameObject Puck;
    public Peg GetPeg(int RowIndex, int ColIndex)
    { return PegRows[RowIndex].GetPeg(ColIndex); }

    public PegRow GetRow(int RowIndex)
    {
        return PegRows[RowIndex];
    }

    public void ResetBoard()
    {
        foreach(var _pr in PegRows)
        {
            _pr.Value.DestroyRow();
        }
        PegRows = new Dictionary<int, PegRow>();
    }

    public void UpdateBoard()
    {

    }


    public void SpawnBall()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        Vector3 SpawnPosition = hit.point;

        SpawnPosition.z = this.transform.position.z - 0.5f; //half size of ball;
        int _heightOffset = 10;
        SpawnPosition.y = BorderPositions._yTopBorderPos - _heightOffset;

        Mathf.Clamp
            (SpawnPosition.x, 
            BorderPositions._xRightBorderPos, 
            BorderPositions._xLeftBorderPos);

        GameObject _instantiatedObject = Instantiate(Puck);
        _instantiatedObject.transform.position = SpawnPosition;

    }

}