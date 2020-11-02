using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ScoreKeeper_Template;
    public GameObject Button_BuyPanel_Template;


    public Dictionary<int, Item> ItemCollection = new Dictionary<int, Item>();
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public class Item
    {
        private int _CollectionKey;
        private int _level;
        private string _name;
        private string _description;



    }
}
