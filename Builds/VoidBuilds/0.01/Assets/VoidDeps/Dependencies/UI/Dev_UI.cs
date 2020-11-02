using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Dev_UI : MonoBehaviour {
    
    private enum UpDown { Down = -1, Start = 0, Up = 1 };
    private Text text;
    private RectTransform textRT;
    private UpDown textChanged = UpDown.Start;
    private KeyCode console_key = Defaults.DEBUGKEY;
    private bool isDebug = false;
    private bool isConsole = false;
    public StringBuilder console_contents;
    private Dictionary<string, string> contents = new Dictionary<string, string>();
    private GameObject canvasGO;
    private Sprite defBkg;
    // Use this for initialization
    void Start () {
   
    }
    private void Awake()
    {
        
    }
    
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
                foreach (var k in contents)
                {
                    string key = k.Key;
                    string value = k.Value;
                    AppendLine(key + " : " + value);
                    text.text = console_contents.ToString();
                }
            }
        }
        else
        {
            if (isConsole)
            {
                OpenDebug(false);
            }
        }

        ///if () {
        //}
    }
    public void DebugEntry(string key, string value)
    {
        if (contents.ContainsKey(key))
        {
            contents[key] = value;
        }
        else
        {
            contents.Add(key, value);
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
            defBkg = Resources.Load("Resources/unity_builtin_extra/Background") as Sprite;
            RectTransform rectTransform;
            // Load the Arial font from the Unity Resources folder.
            Font arial;
            arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

            // Create Canvas GameObject.
            canvasGO = new GameObject();
            canvasGO.name = "Dev_Console";
            canvasGO.AddComponent<Canvas>();
            canvasGO.AddComponent<CanvasScaler>();
            canvasGO.AddComponent<GraphicRaycaster>();

            // Get canvas from the GameObject.
            Canvas canvas;
            canvas = canvasGO.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            GameObject panelGO = new GameObject();
            panelGO.transform.parent = canvasGO.transform;
            panelGO.name = "panelGO";
            rectTransform = panelGO.AddComponent<RectTransform>();
            Vector3 PanelLoc = rectTransform.localPosition = new Vector3(0, 0, 0);
            Vector2 PanelSize = rectTransform.sizeDelta = new Vector2(250, 200);
            panelGO.AddComponent<Image>();
            panelGO.GetComponent<Image>().sprite = defBkg;

            // Create the Text GameObject.
            GameObject textGO = new GameObject();
            textGO.transform.parent = panelGO.transform;
            textGO.name = "text";
            textGO.AddComponent<Text>();

            // Set Text component properties.
            text = textGO.GetComponent<Text>();
            text.font = arial;
            text.text = "no data";
            text.fontSize = 20;
            text.alignment = TextAnchor.UpperLeft;


            // Provide Text position and size using RectTransform.
            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localPosition = PanelLoc;
            rectTransform.sizeDelta = PanelSize;
            rectTransform.anchorMax.Set(1, 1);
            rectTransform.anchorMin.Set(0, 0);
            rectTransform.anchoredPosition.Set(0.5f, 0.5f);


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
