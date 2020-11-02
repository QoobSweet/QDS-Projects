using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class BrushController : MonoBehaviour {
    private float BrushSize = 1;
    private static int BrushID = 1;
    private float BrushStrength = 1;
    private static int Resolution = 10;
    private static Dictionary<int, Editor.vertices> VertBuffer = new Dictionary<int, Editor.vertices>();
    private static Dictionary<int, Editor.VerticesGroup> VertGroups = new Dictionary<int, Editor.VerticesGroup>();
    public static Sprite UIBrushPoint;
    private bool BrushActive = false;
    private bool BrushPacked = false;
    private bool CursorActive = false;
    public Canvas UserInterface;
    public Sprite UIDot;
    public GameObject BrushObj;

    // Use this for initialization
    PackedVerts PackedBrush = new PackedVerts();

    void Start () {
        VertBuffer.Clear();
        VertGroups.Clear();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 Position = GetMousePos();
        Position.z = 10;
        Position = Camera.main.ScreenToWorldPoint(Position);
        Vector2 Pos = Position;
        //Pos.z = (camera distance)
        Vector2 PosInt = new Vector2((Mathf.FloorToInt(Pos.x)), (Mathf.FloorToInt(Pos.y)));
        Vector2 PosDec = Pos - PosInt;
        Brush brush = new Brush();
        if (!BrushActive && MouseScreenCheck())
        {
            BrushObj = new GameObject();
            BrushObj.name = "Brush";

            //BrushActive = true;
            BrushObj.transform.position = Editor.GetClosestAvailablePoint(PosDec, Resolution);
        }
        if (MouseScreenCheck())
        {
            //Buffer Brush while mouse is on screen
            PosDec = Editor.GetClosestAvailablePoint(PosDec, Resolution);
            Pos = PosDec + PosInt;
            PackedBrush = Pack(Pos, BrushID);
            int verts = PackedBrush.Buffer.Count;
            if (BrushActive)
            {
                
            }
            else
            {
                GameObject Brush = BrushObj;
                Brush.transform.SetParent(UserInterface.transform);
                //build brush
                foreach (var pv in PackedBrush.Buffer)
                {
                    GameObject bristle = new GameObject();
                    bristle.transform.SetParent(Brush.transform);
                    bristle.AddComponent<Image>();
                    Image test = bristle.GetComponent<Image>();
                    test.sprite = UIDot;
                    bristle.name = pv.Key.ToString();
                    Vector3 pos = bristle.transform.position;
                    pos.x = pv.Value.x;
                    pos.y = pv.Value.y;
                    BrushActive = true;
                }

                BrushActive = true;
            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //if mouse is clicked
            Debug.Log(PackedBrush.Buffer.Count);
        }
    }


    public bool MouseScreenCheck()
    {
        if (Input.mousePosition.x == 0 || Input.mousePosition.y == 0 || Input.mousePosition.x >= Handles.GetMainGameViewSize().x - 1 || Input.mousePosition.y >= Handles.GetMainGameViewSize().y - 1)
        {
            return false;
        }
        if (Input.mousePosition.x == 0 || Input.mousePosition.y == 0 || Input.mousePosition.x >= Screen.width - 1 || Input.mousePosition.y >= Screen.height - 1) {
            return false;
        }
        else
        {
            return true;
        }
    }

    private PackedVerts Pack(Vector2 Center, int BrushID)
    {
        PackedVerts i = new PackedVerts();
        i.BufferVertices(Center, BrushID);
        return i;
    }

    private class Brush
    {
        private Dictionary<int, BrushCursor> Cursors = new Dictionary<int, BrushCursor>();
        public void add(int id, BrushCursor b)
        {
            if (!Cursors.ContainsKey(id) || !Cursors.ContainsValue(b))
            {
                Cursors.Add(id, b);
            }
        }
        public void remove(int id)
        {
            Cursors.Remove(id);
        }
    }

    private class BrushCursor
    {
        private static Vector2 Position;
        private static Sprite Image = UIBrushPoint;
        private static int ID;

        public static Sprite Image1
        {
            get
            {
                return Image;
            }

            set
            {
                Image = value;
            }
        }

        public void Pos(Vector2 pos)
        {
            Position = pos;
        }
        public void UpdateImage(Sprite sp)
        {
            Image1 = sp;
        }
        public void Update(Vector2 pos, Sprite sp)
        {
            Position = pos;
            Image1 = sp;
        }
        public void Initialize(int id, Vector2 pos, Sprite sp)
        {
            ID = id;
            Position = pos;
            Image1 = sp;
        }

    }

    private BrushCursor Create(int ID, Vector2 pos)
    {
        BrushCursor i = new BrushCursor();
        i.Initialize(ID, pos, UIBrushPoint);
        return new BrushCursor();
    }

    private class PackedVerts
    {
        public Dictionary<int,Vector2> Buffer = new Dictionary<int, Vector2>();

        public void BufferVertices(Vector2 center, int BrushID)
        {
            if (BrushID == 1) //square brush
            {
                float radSteps = (float)Resolution / 2f;
                float steps = 1f / (float)Resolution;

                Vector2 start = new Vector2(-radSteps * steps, radSteps * steps);
                float stop = radSteps;
                Dictionary<int,Vector2> positions = new Dictionary<int, Vector2>();
                float xstep = -radSteps;
                float ystep = radSteps;

                int i = 0;
                Vector2 coord = start;

                while (ystep >= -stop)
                {
                    positions.Add(i, coord);
                    i++;
                    while (xstep <= stop)
                    {
                        xstep++;
                        if (xstep <= stop)
                        {
                            coord.x = coord.x + steps;
                            positions.Add(i, coord);
                            i++;
                        }
                    }
                    coord.x = start.x;
                    coord.y = coord.y - steps;
                    xstep = -radSteps;
                    ystep--;
                }
                Buffer = positions;
            }
            else
            {
                Debug.Log("Invalid Brush!");
                Buffer = null;

            }
        }
       
    }
    private void CheckForExistingVerts(Dictionary<int,Vector2> positions)
    {

    }



    public Square Create(int resolution, float size)
    {
        Square b = new Square();
        b.resolution = resolution;
        b.size = size;
        b.UpdatePositions();
        return b;
    }


    public class Square
    {
        private int Resolution;
        private float Size;
        private Dictionary<int, Vector2> positions = new Dictionary<int, Vector2>();

        public int resolution
        {
            get
            {
                return Resolution;
            }

            set
            {
                Resolution = value;
            }
        }

        public float size
        {
            get
            {
                return Size;
            }

            set
            {
                Size = value;
            }
        }

        public void UpdatePositions()
        {
            positions.Clear();
            float res = Resolution;
            int stepsFromCenter = Mathf.FloorToInt(Size / (1 / res));



            int i = 0;
            int count = 0;
            while (i < stepsFromCenter)
            {
                Vector2 start;
                start.x = -stepsFromCenter * res;
                start.y = -stepsFromCenter * res;
                Vector2 steps = start;
                int Rowsleft;
                int Colleft;
                Rowsleft = Colleft = stepsFromCenter * 2;
                while (Rowsleft > 0)
                {
                    while (Colleft > 0)
                    {
                        positions.Add(count, steps);
                        count++;
                        steps.x = steps.x + res;
                        Colleft--;
                    }
                    Colleft = stepsFromCenter * 2;
                    steps.y = steps.y + res;
                    Rowsleft--;
                }
            }
        }
        public Dictionary<int, Vector2> GetPaintPositions()
        {
            return positions;
        }
    }




    public static int GetResolution()
    {
        return Resolution;
    }
    public void Draw()
    {
        
    }










    public Vector3 GetMousePos()
    {

        var v3 = Input.mousePosition;
        Camera m_camera = Camera.main;
        v3.z = -(m_camera.gameObject.transform.position.z);
        v3 = m_camera.ScreenToWorldPoint(v3);
        return v3;
    }
    public void SetBrushSize(float size)
    {
        BrushSize = size;
    }
}
