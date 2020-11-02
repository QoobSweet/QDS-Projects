using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_Rotation : MonoBehaviour
{
    public float xRotationSpeed = 0.1f;
    public float yRotationSpeed = 0.1f;
    public float zRotationSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRotationSpeed, yRotationSpeed, zRotationSpeed);
    }
}
