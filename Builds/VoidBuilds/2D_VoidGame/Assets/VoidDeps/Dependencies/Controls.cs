using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controls : MonoBehaviour {
    public int player_id;
    public static Vector2 move = Vector2.zero;
    public static Vector2 desmove = Vector2.zero;
    public static bool isJumping = false;
    public static bool jumpHeld = false;
    public static bool isCrouch = false;
    public static bool isGrounded = false;
    public static bool isCieled = false;
    public static bool isUse = false;
    public static bool isActionBlocked = false;
    public static bool isEnabled = false;
    private static bool CrouchIsToggle = Defaults.Crouch.Toggle;

    private static Dictionary<int, Controls> controls = new Dictionary<int, Controls>();
    // Use this for initialization

    void Start() {

    }
    private void Awake()
    {
        controls[player_id] = this;

    }
    // Update is called once per frame
    void Update()
    {
        #region moveUpdate
        move = Vector2.zero;
        //add catch for saved config
        if (Input.GetKey(Move.left))
            move += -Vector2.right;

        //add catch for saved config
        if (Input.GetKey(Move.right))
            move += Vector2.right;

        //add catch for saved config
        if (Input.GetKey(Move.up))
            move += Vector2.up;

        //add catch for saved config
        if (Input.GetKey(Move.down))
            move += -Vector2.up;

        float move_length = Mathf.Min(move.magnitude, 1f);
        move = move.normalized * move_length;
        desmove = move;

        #endregion

        #region JumpUpdate
        if (Input.GetKey(Actions.jump))
        {
            jumpHeld = true;
            
            Traveller.Jump();
        }
        else
        {
            jumpHeld = false;
        }
        #endregion

        #region CrouchUpdate
        if (Input.GetKey(Actions.crouch))
        {
            if (CrouchIsToggle)
            {
                if (isCrouch)
                {
                    isCrouch = false;
                }
                else
                {
                    isCrouch = true;
                }
            }
            else
            { 
                isCrouch = true;
            }
        }
        if (Input.GetKeyUp(Actions.crouch))
        {
            if (!CrouchIsToggle)
            {
                isCrouch = false;
            }
        }
        #endregion

        if (Input.GetKey(Actions.jump))
            Traveller.Jump();
        if (Input.GetKey(Actions.use))
            Traveller.Use();



    }
    class Move
    {
        //declare any movement involved controls
        public static KeyCode up = Defaults.Controls.Up;
        public static KeyCode down = Defaults.Controls.Down;
        public static KeyCode left = Defaults.Controls.Left;
        public static KeyCode right = Defaults.Controls.Right;
    }
    class Actions
    {
        //declare any action involved contorls
        public static KeyCode jump = Defaults.Controls.Jump;
        public static KeyCode crouch = Defaults.Crouch.Key;
        public static KeyCode use = Defaults.Controls.Use;
        public static KeyCode a1 = Defaults.Controls.Action;
        public static KeyCode a2 = Defaults.Controls.Secondary;
    }
    public static Controls Get(int player_id)
    {
        foreach (Controls control in GetAll())
        {
            if (control.player_id == player_id)
            {
                return control;
            }
        }
        return null;
    }
    public static Controls[] GetAll()
    {
        Controls[] list = new Controls[controls.Count];
        controls.Values.CopyTo(list, 0);
        return list;
    }
    public static Vector2 GetMove()
    { 
  
        return desmove;
    }
    public static bool GetJump()
    {
        return isJumping;
    }
    public static bool GetJumpHeld()
    {
        return jumpHeld;
    }
    public static bool GetCrouch()
    {
        return isCrouch;
    }
}


