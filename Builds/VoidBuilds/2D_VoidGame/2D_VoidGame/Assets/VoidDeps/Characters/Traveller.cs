using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Traveller : MonoBehaviour {
    public int player_id;
    public static string char_name = "Traveller";
    public static int strength;
    public static int dexterity;
    public static int constitution;
    public static int willpower;
    public static int inteligence;
    public static int awareness;
    public static int perception;
    public static int agility;
    public static int attunement;
    public static int sanity;
    public static float vert_move = 0f;
    public static float hor_move = 0f;
    public static int m_up = 0;
    public static int vert_mult = 0;
    public static int hor_mult = 0;
    public static int for_mult = 0;
    public Vector2 move = new Vector2(0,0);
    private static Dictionary<int, Traveller> character_list = new Dictionary<int, Traveller>();

    // Use this for initialization
    void Start ()
    {
        char_name = Defaults.char_name;
        strength = Defaults.strength;
        dexterity = Defaults.dexterity;
        constitution = Defaults.constitution;
        willpower = Defaults.willpower;
        inteligence = Defaults.intelligence;
        awareness = Defaults.awareness;
        perception = Defaults.perception;
        agility = Defaults.agility;
        attunement = Defaults.attunement;
        sanity = Defaults.sanity;
        
	}

    // Update is called once per frame
    void Update()
    {
        Controls controls = Controls.Get(player_id);
        if (isDebug())
        {
            Debug.Log(player_id);
        }
       // move = controls.GetMove();


        
    }
    private bool isDebug()
    {
        if (Defaults.debug == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static Traveller Get(int player_id)
    {
        foreach (Traveller control in GetAll())
        {
            if (control.player_id == player_id)
            {
                return control;
            }
        }
        return null;
    }

    public static Traveller[] GetAll()
    {
        Traveller[] list = new Traveller[character_list.Count];
        character_list.Values.CopyTo(list, 0);
        return list;
    }
    private void Run()
    {

    }
    private void crouch()
    {

    }
    private void Interact()
    {

    }
    private void DoubleJump()
    {

    }
    private void DetectGrounded(bool detect_cieled)
    {

    }
    public static void Jump()
    {

    }
    public static void Use()
    {

    }
}
