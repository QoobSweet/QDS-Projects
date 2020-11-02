using System;
using System.Collections.Generic;
using UnityEngine;

public partial class PegBoard : MonoBehaviour
{
    public interface iQBallDestroyer
    {
        PegBoard Controller { set; }
    }

    public Camera BoardCamera;

    public GameObject PegTemplate;
    public GameObject Puck;
    public GameObject PuckSpawnLocation;

    //Libraries
    private List<QBall> QBalls = new List<QBall>();

    //ScoreKeepers
    private int CoinScore = 1;

    public Count_Keeper PointKeeper_Out;

    //CostKeepers
    private int BallCost
    {
        get
        {
            //InitialCost at 1 ball existing
            double a = 1;
            //rate of increase %
            double r = 10;
            double cost = Math.Pow((a * (1 + r / 100)), QBalls.Count);

            return Mathf.FloorToInt(Convert.ToSingle(cost));
        }
    }

    public Count_Keeper BallCost_Out;

    //dynamically link class to any PegBoard Object that invokes it
    //never cached....could work to prevent cheating??
    internal _BPositions BorderPositions { get { return new _BPositions(this); } }

    internal class _BPositions
    {
        private PegBoard parent;

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

    private List<Peg> RegisteredPegs = new List<Peg>();

    public delegate void CoinUpdate(int Count);

    public event CoinUpdate UpdateCoins;

    public void OnCoinUpdate(int Amount)
    {
        if (UpdateCoins != null)
        {
            UpdateCoins(Amount);
        }
    }

    //ProccessingEvents
    public void ProcessQBallDestroy(QBall QBallToDestroy)
    {
        Debug.Log("Removing QBall #" + QBalls.Count);
        QBalls.Remove(QBallToDestroy);
        Destroy(QBallToDestroy.gameObject);
    }

    public void ProcessCoinChange(int Amount)
    {
        CoinScore += Amount;
        PointKeeper_Out.text = CoinScore.ToString();
        OnCoinUpdate(Amount);
    }

    public void Update()
    {
        BoardCamera.transform.localScale = new Vector3(1, 1, 1);
    }

    public void Start()
    {
        BallCost_Out.text = BallCost.ToString();
        PointKeeper_Out.text = CoinScore.ToString();

        GameObject[] Pegs = GameObject.FindGameObjectsWithTag("QPeg");
        GameObject[] WasteBins = GameObject.FindGameObjectsWithTag("WasteBins");

        foreach (var p in Pegs)
        {
            if (p.gameObject.GetComponent<PegCollision>() == null)
            {
                bool registered = false;
                foreach (var _peg in RegisteredPegs)
                {
                    if (_peg._instantiatedObject != null && _peg._instantiatedObject == p)
                    {
                        registered = true;
                    }
                }

                if (!registered)
                {
                    Peg _newPeg = new Peg(this, p.gameObject);
                    RegisteredPegs.Add(_newPeg);
                }
            }
        }
        foreach (var wb in WasteBins)
        {
            WasteBinBarrier wbr = wb.GetComponent<WasteBinBarrier>();
            wbr.Controller = this;


        }
    }

    public void SpawnPeg(Vector2 position)
    {
        Vector3 SpawnPos = new Vector3(position.x, position.y, PuckSpawnLocation.transform.position.z);
        GameObject _instantiatedObject = Instantiate(PegTemplate);
        _instantiatedObject.transform.position = SpawnPos;
    }

    public void SpawnBall()
    {
        if (CoinScore >= BallCost)
        {
            ProcessCoinChange(-BallCost);
            BallCost_Out.text = BallCost.ToString();
            GameObject _instantiatedObject = Instantiate(Puck);

            //Add to collections for Registration and Clean Object Removal
            Debug.Log("Adding QBall #" + (QBalls.Count + 1));
            QBalls.Add(_instantiatedObject.GetComponent<QBall>());

            _instantiatedObject.transform.position = PuckSpawnLocation.transform.position;
            float Velocity = UnityEngine.Random.Range(175, 1000);
            _instantiatedObject.GetComponent<Rigidbody>().velocity = new Vector3(0, Velocity, 0);
        }
    }
}