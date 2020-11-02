using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qball : MonoBehaviour
{
    Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (_rigidbody != null)
        {
            _rigidbody.AddForce(Physics.gravity * _rigidbody.mass);
        }
    }
}
