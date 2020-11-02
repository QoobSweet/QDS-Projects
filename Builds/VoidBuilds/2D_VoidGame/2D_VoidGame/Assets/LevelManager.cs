using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelManager : MonoBehaviour 
{

	[Header("Buffers")]
	public ushort UnlBuffer = 20;
	public ushort GenericBuffer = 20;
	public ushort SpriteBuffer = 30;
	public ushort VPSizeX = 30;
	public ushort VPSizeY = 25;

	[Header("World Size Limiters")]
	public ushort FMMaxTilesX = 4000;
	public ushort FMMaxTilesY = 4000;

	public static ushort LMMaxTilesX;
	public static ushort LMMaxTilesY;


	private static Dictionary<int, LevelManager> Level_Controls = new Dictionary<int, LevelManager>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}



