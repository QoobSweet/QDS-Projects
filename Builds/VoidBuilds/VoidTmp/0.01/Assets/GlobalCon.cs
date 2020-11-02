using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalCon {
    private static Dictionary<int, string> Windows = new Dictionary<int, string>();
    private static bool found = false;


    public static int RegisterWindow(string name)
    {
        int i = 0;
        found = false;
        while (!found)
        {
            if (Windows.ContainsKey(i))
            {
                if (Windows[i] == "")
                {
                    Windows[i] = name;
                    found = true;
                }
                else
                {
                    i++;
                }
            }
            else
            {
                Windows.Add(i, name);
                found = true;
            }
        }
        return i;

    }
    public static void RemoveWindow(int id)
    {
        if (Windows.ContainsKey(id))
        {

            Windows[id] = "";
        }
    }
}

