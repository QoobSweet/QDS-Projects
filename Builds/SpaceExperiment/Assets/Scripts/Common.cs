using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : MonoBehaviour
{
    public class Distance
    {
        public float distance;
        public int index;

        public Distance(float distance, int index)
        {
            this.distance = distance;
            this.index = index;
        }
    }
}
