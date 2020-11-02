using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Defaults : MonoBehaviour {
    private static Dictionary<string, float> D_Stats = new Dictionary<string, float>();
    [Header("Dev Tools")]
    public bool DEBUG_MODE = false;

    public static bool debug;

    [Header("Controls")]
    public KeyCode MOVE_UP = KeyCode.W;
    public KeyCode MOVE_DOWN = KeyCode.S;
    public KeyCode MOVE_LEFT = KeyCode.A;
    public KeyCode MOVE_RIGHT = KeyCode.D;
    public KeyCode INVENTORY = KeyCode.Tab;
    public KeyCode CROUCH = KeyCode.LeftControl;
    public KeyCode JUMP = KeyCode.Space;
    public KeyCode USE = KeyCode.F;
    public KeyCode ACTION = KeyCode.Mouse0;
    public KeyCode SECONDARY = KeyCode.Mouse1;
    public static KeyCode DEBUGKEY = KeyCode.F9;

    private static KeyCode move_up;
    private static KeyCode move_down;
    private static KeyCode move_left;
    private static KeyCode move_right;
    private static KeyCode inventory;
    private static KeyCode crouch;
    private static KeyCode jump;
    private static KeyCode use;
    private static KeyCode action;
    private static KeyCode secondary;

    [Header("Base Stats")]
    public string CHAR_NAME = "Traveller";
    public static int STRENGTH = 5;
    public static int DEXTERITY = 5;
    public static int CONSTITUTION = 3;
    public static int WILLPOWER = 2;
    public static int SANITY = 100;
    public static int INTELLIGENCE = 5;
    public static int AWARENESS = 5;
    public static int PERCEPTION = 2;
    public static int AGILITY = 2;
    public static int ATTUNEMENT = 1;
    public static int STATPOOL = 30;

    public static string char_name;
    public static int strength; //effectiveness of held weapons
    public static int dexterity; //how fast you can change direction/stop
    public static int constitution; //how effectively you can withstand dmg taken
    public static int willpower;
    /// <summary>
    /// will determine how well stats will be applied, less then 50 will have negative consequences
    /// more then 50 will have positive effects.
    /// willpower will have no cap
    /// </summary>
    public static int sanity;
    public static int intelligence;
    /// <summary>
    /// how much knowledge you know about items and cards and how to use them
    /// with low intelligence some cards higher abilities wont be shown or used and will show (hidden)
    /// tag without showing how much int* you need to reveal
    /// </summary>
    public static int awareness;
    /// <summary>
    /// how well you can notice hidden things such as hidden doors/stealthed creatures/insignias/hidden buttons/etc
    /// </summary>
    public static int perception;
    /// <summary>
    /// how well you can see the area around you
    /// how well you can remember places you've been and where things are
    /// </summary>
    public static int agility; //how fast you move
    public static int attunement; //effects how many cards you are able to slot to your character

    //damage resistances
    [Header("Resistances")]
    public int PHYS_RESIST = 0;
    public int MAGIC_RESIST = 0;
    public int FIRE_RESIST = 0;
    public int LIGHTNING_RESIST = 0;

    public static int phys_resist;
    public static int magic_resist; //how effective spell reflection is
    public static int fire_resist;
    public static int lightning_resist;




    void Awake()
    { 
        debug = this.DEBUG_MODE;
        //assign values of D_Stats

    #region set builders with provided values
    move_up = this.MOVE_UP;
         move_down = this.MOVE_DOWN;
         move_left = this.MOVE_LEFT;
         move_right = this.MOVE_RIGHT;
         inventory = this.INVENTORY;
         crouch = this.CROUCH;
         jump = this.JUMP;
         action = this.ACTION;
         secondary = this.SECONDARY;
        
         char_name = this.CHAR_NAME;
         strength = STRENGTH;
         dexterity = DEXTERITY;
         constitution = CONSTITUTION;
         willpower = WILLPOWER;
         sanity = SANITY;
         intelligence = INTELLIGENCE;
         awareness = AWARENESS;
         perception = PERCEPTION;
         agility = AGILITY;
         attunement = ATTUNEMENT;

         phys_resist = this.PHYS_RESIST;
         magic_resist = this.MAGIC_RESIST;
         fire_resist = this.FIRE_RESIST;
         lightning_resist = this.LIGHTNING_RESIST;
        #endregion

    }
    public class Crouch
    {
        public static bool Toggle = false;
        public static KeyCode Key = crouch;
    }
    public class Controls
    {
        public static KeyCode Up = move_up;
        public static KeyCode Down = move_down;
        public static KeyCode Left = move_left;
        public static KeyCode Right = move_right;
        public static KeyCode Inventory = inventory;
        public static KeyCode Crouch = crouch;
        public static KeyCode Jump = jump;
        public static KeyCode Use = use;
        public static KeyCode Action = action;
        public static KeyCode Secondary = secondary;
    }
    public class Attributes
    {
        public static string Name = char_name;
    }
    public static Dictionary<string, float> Dict_Stats()
    {
        BuildD_Stats();
        return D_Stats;
    }
    private static void BuildD_Stats()
    {
        D_Stats.Add("Strength", STRENGTH);
        D_Stats.Add("Dexterity", DEXTERITY);
        D_Stats.Add("Constitution", CONSTITUTION);
        D_Stats.Add("Willpower", WILLPOWER);
        D_Stats.Add("Sanity", SANITY);
        D_Stats.Add("Intelligence", INTELLIGENCE);
        D_Stats.Add("Awareness", AWARENESS);
        D_Stats.Add("Perception", PERCEPTION);
        D_Stats.Add("Agility", AGILITY);
        D_Stats.Add("Attunement", ATTUNEMENT);
    }
}
