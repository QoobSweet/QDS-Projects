using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour {
    private Transform objTitle;
    private Text txtTtitle;
    private Dictionary<string, cImage> Images = new Dictionary<string, cImage>();
    private Dictionary<string, GameObject> Windows = new Dictionary<string, GameObject>();
    private string CompiledContent;
    private GameObject self;
    private Transform BtnExpand;

	// Use this for initialization
	void Start () {
        self = this.gameObject;
        objTitle = self.transform.Find("Title");
        txtTtitle = objTitle.GetComponent<Text>();
        BtnExpand = objTitle.transform.Find("BtnExpand");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
public class cImage
{
    private static Image Name;
    private static Image Img;
    private static Vector2 Position;
    private static Vector2 Size;

    public static Image name
    {
        get
        {
            return Name;
        }

        set
        {
            Name = value;
        }
    }
    public static Image img
    {
        get
        {
            return Img;
        }
        set
        {
            Img = value;
        }
    }
    public static Vector2 position
    {
        get
        {
            return Position;
        }
        set
        {
            Position = value;
        }
    }
    public static Vector2 size
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
         
}
public class cContent
{
    
}


