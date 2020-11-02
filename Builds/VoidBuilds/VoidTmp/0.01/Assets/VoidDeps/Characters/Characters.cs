using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static Character CreateCharacter(int id){
        Character character = new Character();
        character.id = id;
        character.name = "";
        return character;
    }

    public static Character CreateCharacter(int id, string name)
    {
        Character character = new Character();
        character.id = id;
        character.name = name;
        character.StatPool = 20;
        return character;
    }
    public static Character CreateCharacter(int id, string name, Stats stats)
    {
        Character character = new Character();
        character.stats = stats;
        character.id = id;
        character.name = name;
        return character;
    }



    public class Character
    {
        public int id;
        public string name;
        public int StatPool = 0;
        public float sanity = 100;
        public Stats stats = new Stats();
        public Movement movement = new Movement();
        public Move moveactual = new Move();
        public Controllers controllers = new Controllers();
    }

    public class Stats
    {
        public int strength;
        public int dexterity;
        public int constitution;
        public int willpower;
        public int inteligence;
        public int awareness;
        public int perception;
        public int agility;
        public int attunement;
    }
    public class Movement
    {
        public float move_accel = 1f;
        public float move_deccel = 1f;
        public float move_max = 5f;
        public float run_timer = 0f;
        public float run_timer_acc = 0;
        public float jump_strength;
        public float jump_time_min = 1f;
        public float jump_time_max = 1f;
        public float jump_gravity = 1f;
        public float jump_fall_gravity = 0.75f;
        public float jump_move_percent = 0.75f;
    }
    public class Controllers
    {
        public bool x_direction_right;  
        public bool can_jump = true;
        public bool jump_press;
        public bool jump_hold;
    }
    public class Move
    {
        public static float vert_move = 0f;
        public static float hor_move = 0f;
        public static int m_up = 0;
        public static int vert_mult = 0;
        public static int hor_mult = 0;
        public static int for_mult = 0;
    }
    public class Controls
    {
        public Move move = new Move();
        public Actions actions = new Actions();

        public class Move
        {
            //declare any movement involved controls
            public static KeyCode up = Defaults.Controls.Up;
            public static KeyCode down = Defaults.Controls.Down;
            public static KeyCode left = Defaults.Controls.Left;
            public static KeyCode right = Defaults.Controls.Right;
        }
        public class Actions
        {
            //declare any action involved contorls
            public static KeyCode jump = Defaults.Controls.Jump;
            public static KeyCode crouch = Defaults.Crouch.Key;
        }
    }

}
