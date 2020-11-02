using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QPeg : MonoBehaviour
{
    private PegBoard ControlBoard;



    private void OnCollisionEnter(Collision collision)
    {
        if(ControlBoard == null)
        {
            while (ControlBoard == null)
            {
                ControlBoard = GameObject.Find("PegBoard").GetComponent<PegBoard>();
            }
        }

        AddCoins(1);
    }

    private void AddCoins(int Amount)
    {
        ControlBoard.ProcessCoinIncrease(Amount);
    }

}
