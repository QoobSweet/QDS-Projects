using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Editor : MonoBehaviour {
    private Mesh mesh;
    // Use this for initialization
    void Start () {
        mesh = new Mesh();
	}

    // Update is called once per frame
    void Update()
    {

    }
    private static int GetResolution()
    {
        return BrushController.GetResolution();
    }
    private bool least(float x, float y)
    {
        if (x < y) { return true; } else { return false; }
    }
    public static Vector2 GetClosestAvailablePoint(Vector2 input, int Resolution)
    {
        float res = Resolution;
        float steps = (float)(1/res);
        int i = 0;
        bool x = false;
        bool y = false;
        while (i <= Resolution)
        {
            if ((input.x > (float)i* steps) && (input.x < ((float)i+ (float)1) * steps))
            {
                float Min = (float)i* steps;
                float Max = ((float)i+ 1) * steps;
                if ((input.x - Min) < Mathf.Abs(input.x - Max))
                {
                    input.x = (float)i* steps;
                }
                else
                {
                    input.x = ((float)i + 1) * steps;
                }
                x = true;
            }
            if ((input.y > (float)i * steps) && (input.y < ((float)i+ 1) * steps))
            {
                if ((input.y - ((float)i * steps)) < (-1*(input.y - (((float)i+ 1) * steps))))
                {
                    input.y = (float)i * steps;
                }
                else
                {
                    input.y = ((float)i + 1) * steps;
                }
                y = true;
            }
            if (x && y)
            {
                return input;
            }
            else
            {
                i++;
            }
        }
        //return 0, 0 if no viable values found
        return new Vector2(0, 0);
    }
    public class vertices
    {
        private Vector3 Position;
        #region Constructors
        public Vector3 position
        {
            get { return Position; }

            set { Position = value; }
        }
        public float X
        {
            get
            { return Position.x; }
            set
            { Position.x = value; }
        }
        public float Y
        {
            get
            { return Position.y; }
            set
            { Position.y = value; }
        }
        public float Z
        {
            get
            { return Position.z; }
            set
            { Position.z = value; }
        }
        #endregion

        public Vector2 Get2DCoord()
        {
            Vector2 v2;
            v2.x = X;
            v2.y = Y;
            return v2;
        }
        public void Set2DCoord(float x, float y)
        {
            X = x;
            Y = y;
        }
        public Vector3 Get3DCoord()
        {
            Vector3 v3;
            v3.x = X;
            v3.y = Y;
            v3.z = Z;
            return v3;
        }
        public void Set3DCoord(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class VerticesGroup
    {
        Dictionary<int,vertices> Vertices = new Dictionary<int,vertices>();
        public Dictionary<int, float> VertLayers = new Dictionary<int, float>();
        public Dictionary<int, float> HoriLayers = new Dictionary<int, float>();
        Dictionary<int, float> positions = new Dictionary<int, float>();
        public void Add(vertices v)
        {
            int i = 1;
            while (Vertices.ContainsKey(i)) { i++; }
            
            Vertices.Add(i, v);
        }
        public void Remove(vertices v)
        {
            foreach (var i in Vertices)
            {
                if (i.Value == v)
                {
                    Vertices.Remove(i.Key);

                }
            }            
        }
        public void UpdateLayers()
        {
            foreach (vertices v in Vertices.Values)
            {
                bool xTest = false;
                bool yTest = false;

                //check if layers exist
                foreach (float f in HoriLayers.Values)
                {
                    if (v.X == f)
                    {
                        xTest = true;
                        break;
                    }
                }

                foreach (float f in VertLayers.Values)
                {
                    if (v.Y == f)
                    {
                        yTest = true;
                        break;
                    }
                }

                //add new layer if not found
                if (xTest)
                {
                    int i = 0;
                    while (HoriLayers.ContainsKey(i)) { i++; }
                    HoriLayers.Add(i, v.X);
                }
                if (yTest)
                {

                }
            }
        }


        public void UpdateVertResolution()
        {
            int Resolution = GetResolution();
            float i = 1 / Resolution;
            foreach (int key in positions.Keys)
            {
                positions[key] = key * i;
            }
            foreach (var v in Vertices)
            {
                vertices vert = v.Value;

                int t = 0;
                float xInt = Mathf.Floor(vert.X);
                float xDbl = vert.X - xInt;
                while (xDbl <= positions[t])
                {
                    t++;
                }
                float max = positions[t - 1];
                float min = positions[t - 2];

                if ((Mathf.Abs(xDbl - min)) > (Mathf.Abs(xDbl - max)))
                {
                    xDbl = min;
                }
                else
                {
                    xDbl = max;
                }
                vert.X = xInt + xDbl;


                t = 0;
                float yInt = Mathf.Floor(vert.Y);
                float yDbl = vert.Y - yInt;
                while (yDbl <= positions[t])
                {
                    t++;
                }
                max = positions[t - 1];
                min = positions[t - 2];

                if ((Mathf.Abs(yDbl - min)) > (Mathf.Abs(yDbl - max)))
                {
                    yDbl = min;
                }
                else
                {
                    yDbl = max;
                }

                vert.Y = yInt + yDbl;

                Vertices[v.Key] = vert;
            }
        }
        private void UpdatePositions()
        {

        }
        //need to figure out method for sorting verts so that normals and textures can be applied in a way that makes sense
        public void Sort()
        {

        }
    }


    #region Vertices Constructors

    public vertices Vertices(float x, float y, float z)
    {
        Editor.vertices vert = new vertices();
        vert.X = x;
        vert.Y = y;
        vert.Z = z;
        return vert;
    }
    public vertices Vertices(int DictionaryID, float x, float y, float z)
    {
        Editor.vertices vert = new vertices();
        vert.X = x;
        vert.Y = y;
        vert.Z = z;
        return vert;
    }
    public vertices Vertices(Vector3 v3)
    {
        Editor.vertices vert = new vertices();
        vert.X = v3.x;
        vert.Y = v3.y;
        vert.Z = v3.z;
        return vert;
    }
    public vertices Vertices(int DictionaryID, Vector3 v3)
    {
        Editor.vertices vert = new vertices();
        vert.X = v3.x;
        vert.Y = v3.y;
        vert.Z = v3.z;
        return vert;
    }
    #endregion

}

