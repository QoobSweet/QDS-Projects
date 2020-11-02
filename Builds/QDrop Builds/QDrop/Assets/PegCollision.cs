using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegCollision : MonoBehaviour
{
    public delegate void DamageTaken(Collision _collision);
    public event DamageTaken TakeDamage;
    public void OnDamageTaken(Collision _collision)
    {
        if(TakeDamage != null)
        {
            TakeDamage(_collision);
        }
    }

    private void OnCollisionEnter(Collision _collision)
    {
        OnDamageTaken(_collision);
    }
}
