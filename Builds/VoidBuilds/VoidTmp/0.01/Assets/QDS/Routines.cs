using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routines {

    public class Vectors
    {
        public static Vector3 V2toV3(Vector2 v2)
        {
            Vector3 v3 = new Vector3();
            v3.x = v2.x;
            v3.y = v2.y;
            v3.z = 0;
            return v3;
        }
        public static Vector3 V2toV3(Vector2 v2, float z)
        {
            Vector3 v3 = new Vector3();
            v3.x = v2.x;
            v3.y = v2.y;
            v3.z = z;
            return v3;
        }
    }

}