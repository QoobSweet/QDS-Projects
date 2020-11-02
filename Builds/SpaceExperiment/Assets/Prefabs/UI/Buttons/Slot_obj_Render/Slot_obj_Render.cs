using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot_obj_Render : MonoBehaviour
{
    public RenderTexture renderTexturePrefab;
    public RenderTexture renderTexture;
    public Camera renderCamera;
    public GameObject ObjSpawn;
    private GameObject CurrentRenderObject;
    private GameObject CurrentObjectPrefab;


    // Start is called before the first frame update
    void Start()
    {
        if (!renderTexture) { renderTexture = new RenderTexture(renderTexturePrefab); }
        if(!renderCamera) { renderCamera = transform.Find("Camera").GetComponent<Camera>(); }

        renderCamera.targetTexture = renderTexture;
    }

    // Update is called once per frame
    void Update()
    {
        if (!renderTexture) { renderTexture = new RenderTexture(renderTexturePrefab); }
        if (!renderCamera) { 
            renderCamera = transform.Find("Camera").GetComponent<Camera>();
            renderCamera.targetTexture = renderTexture;
        }
    }

    public void AssignObject(GameObject ObjectPrefab)
    {
        if (CurrentRenderObject) { Destroy(CurrentRenderObject); }

        CurrentObjectPrefab = ObjectPrefab;
        CurrentRenderObject = Instantiate(ObjectPrefab, ObjSpawn.transform.position, new Quaternion(), ObjSpawn.transform);
        CurrentRenderObject.layer = 5;
        CurrentRenderObject.AddComponent<Simple_Rotation>();
    }
}
;