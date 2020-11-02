using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.PlayerLoop;

[Serializable]
public class Peg
{
    public PegBoard _Controller;
    public GameObject _instantiatedObject;
    private GameObject _Template;
    private MeshCollider _collider;

    public Peg(PegBoard Controller, UnityEngine.Vector3 Position)
    {
        _Template = Controller.PegTemplate;
        _instantiatedObject = PegBoard.Instantiate(_Template);
        _instantiatedObject.transform.position = Position;
        _instantiatedObject.transform.Rotate(new UnityEngine.Vector3(0, 0, -180));
        PegCollision _pegCollision = _instantiatedObject.AddComponent<PegCollision>();
        _collider = _instantiatedObject.GetComponent<MeshCollider>();
    }

    public bool HasObject { get { return (_instantiatedObject != null); } }

    public GameObject PegObject { get { return _instantiatedObject; } }
    public UnityEngine.Vector3 position { get { return _instantiatedObject.transform.position; } internal set { _instantiatedObject.transform.position = value; } }
    public float yPosition { set { _instantiatedObject.transform.position = _instantiatedObject.transform.position; } }

    public delegate void PegUpdate();
    public event PegUpdate UpdatePeg;
    public void ProcessPegUpdate()
    {
        OnPegUpdate();
    }
    public void OnPegUpdate()
    {
        if (UpdatePeg != null)
        {
            UpdatePeg();
        }
    }

    public void DestroyPeg()
    { 
        PegBoard.Destroy(_instantiatedObject);
        ProcessPegUpdate();
    }

    public void HidePeg()
    { 
        _instantiatedObject.SetActive(false);
        ProcessPegUpdate();
    }

    public void SetPosition(UnityEngine.Vector3 newPosition)
    { 
        position = newPosition;
        ProcessPegUpdate();
    }

    public void ShowPeg()
    { 
        _instantiatedObject.SetActive(true);
        ProcessPegUpdate();
    }
}