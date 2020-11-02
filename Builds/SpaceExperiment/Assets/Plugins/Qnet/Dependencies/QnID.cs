using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qnet
{
    [Serializable]
    public class QnID : MonoBehaviour
    {
        private int _QnetUID;

        //accesors
        public int QnetID { get { return _QnetUID; } }

        //constructors
        public QnID()
        {
            _QnetUID = -1;
        }
        public QnID(int ID)
        {
            if (ID > 0)
            {
                this._QnetUID = ID;
            }
            else
            {
                this._QnetUID = -1;
                Debug.Log("Invallid input of " + ID + " to set ID");
            }
        }
    }
}