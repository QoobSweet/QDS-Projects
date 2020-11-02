using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteBinBarrier : MonoBehaviour, PegBoard.iQBallDestroyer
{
    private PegBoard _controller;
    public PegBoard Controller
    {
        get { return _controller; }
        set { _controller = value; }
    }


    public void ProcessObject(GameObject target)
    {
        //set inactive to remove from scene
        target.SetActive(false);
        QBall qb = target.GetComponent<QBall>();
        if (qb != null)
        {
            Controller.ProcessQBallDestroy(qb);
        }
    }



    public void OnCollisionEnter(Collision collision)
    {
        ProcessObject(collision.collider.gameObject);
    }
}
