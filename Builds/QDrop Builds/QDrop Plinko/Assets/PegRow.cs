using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PegRow
{
    private Dictionary<int, Peg> Pegs = new Dictionary<int, Peg>();
    private Vector3 _RootPosition;
    public Vector3 RootPosition { get { return _RootPosition; } }
    public PegBoard Controller;
    public void DestroyPeg(int PegRowIndex)
    {
        Pegs[PegRowIndex].DestroyPeg();
        Pegs[PegRowIndex] = null;
    }

    public void DestroyRow()
    {
        int i = 0;
        while (true)
        {
            if(Pegs.ContainsKey(i) && Pegs[i] != null)
            {
                Pegs[i].DestroyPeg();
                Pegs[i] = null;
                i++;
            }
            else
            {
                return;
            }
        }
    }

    public Peg GetPeg(int PegRowIndex)
    {
        return Pegs[PegRowIndex];
    }

    public bool PegExists(int PegRowIndex)
    {
        return (Pegs[PegRowIndex] != null);
    }

    public void RowUpdate()
    {
        //temp
    }

    public void SetPeg(int PegRowIndex, Peg Peg)
    {
        if (Pegs[PegRowIndex] != null)
        {
            DestroyPeg(PegRowIndex);
        }

        Pegs[PegRowIndex] = Peg;
    }

    public void UpdateRow(Vector3 RootPositiom, int PegCount, float Spacing, bool doubleSpaced)
    {
        this._RootPosition = RootPosition;
        int _lastIndex = 0;
        int _pegCountActual = PegCount;
        for (int i = 0; i < _pegCountActual; i++)
        {
            float _xOffset = Spacing * i;
            if (doubleSpaced) { _xOffset += Spacing/2; _pegCountActual = PegCount - 1; }
            Vector3 _pegPosition = new Vector3(RootPosition.x + _xOffset, RootPosition.y, RootPosition.z);

            if (this.Pegs.ContainsKey(i) && this.Pegs[i] != null)
            {
                Pegs[i].SetPosition(_pegPosition);
            }
            else
            {
                this.Pegs[i] = new Peg(this.Controller, _pegPosition);
            }
            _lastIndex = i;
        }
        
        //destroy any extra existing pegs
        _lastIndex++;
        while (Pegs.ContainsKey(_lastIndex) && Pegs[_lastIndex] != null)
        {
            Pegs[_lastIndex].DestroyPeg();
            Pegs[_lastIndex] = null;
            _lastIndex++;
        }
    }


    public PegRow(PegBoard Controller, Vector3 RootPosition, int PegCount, float Spacing, bool doubleSpaced)
    {
        this._RootPosition = RootPosition;
        for(int i = 0; i < PegCount; i++)
        {
            float _xOffset = Spacing * i;
            if (doubleSpaced) { _xOffset += Spacing; }
            Vector3 _pegPosition = new Vector3(RootPosition.x + _xOffset, RootPosition.y, RootPosition.z);
            this.Controller = Controller;
            this.Pegs[i] = new Peg(this.Controller, _pegPosition);
        }
    }
}
