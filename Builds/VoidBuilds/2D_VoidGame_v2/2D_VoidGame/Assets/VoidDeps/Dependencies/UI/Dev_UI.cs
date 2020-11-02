using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Dev_UI : MonoBehaviour {
    
    private string[] contents;
    private enum UpDown { Down = -1, Start = 0, Up = 1 };
    private Text text;
    private RectTransform textRT;
    private UpDown textChanged = UpDown.Start;
    private KeyCode console_key = KeyCode.F9;
    private bool isDebug = false;
    private bool isConsole = false;
    public StringBuilder console_contents;


    // Use this for initialization
    void Start () {
		
	}
    private void Awake()
    {

    }
    

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(console_key))
        {
            if (!isDebug)
            {
                isDebug = true;
            }
            else
            {
                isDebug = false;
            }
        }

        if (isDebug)
        {
            if (!isConsole)
            {
                OpenDebug(true);
            }
            else
            {
                resetsb();
                Vector2 move = Controls.GetMove();
                AppendLine("current move: " + move.ToString());
                text.text = console_contents.ToString();
            }
            
            // Press the space key to change the Text message.
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    if (textChanged != UpDown.Down)
            //    {
            //        text.text = "Text changed";
            //        textChanged = UpDown.Down;
            //    }
            //    else
            //    {
            //        text.text = "Text changed back";
            //        textChanged = UpDown.Up;
            //    }
            //}
        }
        else
        {
            if (isConsole)
            {
                OpenDebug(false);
            }
        }
    }
    private void AppendLine(string i)
    {
        if (console_contents.Length < 1)
        {
            console_contents.Append(i);
        }
        else
        {
            console_contents.AppendLine(i);
        }

    }
    private void resetsb()
    {
        StringBuilder i = new StringBuilder("");
        console_contents = i;
    }
    private void OpenDebug(bool open)
    {
        if (open)
        {
            // Load the Arial font from the Unity Resources folder.
            Font arial;
            arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

            // Create Canvas GameObject.
            GameObject canvasGO = new GameObject();
            canvasGO.name = "Dev_Console";
            canvasGO.AddComponent<Canvas>();
            canvasGO.AddComponent<CanvasScaler>();
            canvasGO.AddComponent<GraphicRaycaster>();

            // Get canvas from the GameObject.
            Canvas canvas;
            canvas = canvasGO.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;


            // Create the Text GameObject.
            GameObject textGO = new GameObject();
            textGO.transform.parent = canvasGO.transform;
            textGO.AddComponent<Text>();

            // Set Text component properties.
            text = textGO.GetComponent<Text>();
            text.font = arial;
            text.text = "no data";
            text.fontSize = 20;
            text.alignment = TextAnchor.UpperLeft;


            // Provide Text position and size using RectTransform.
            RectTransform rectTransform;
            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, 0, 0);
            rectTransform.sizeDelta = new Vector2(472, 377);

            isConsole = true;
        }
        else
        {
            if (GameObject.Find("Dev_Console"))
            {
                GameObject i = GameObject.Find("Dev_Console");
                Destroy(i);
                Debug.Log("Debug console closed");
            }
            isConsole = false;
        }

    }


}
