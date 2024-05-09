using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{ 
    public bool isCleared
    {
        get;
        set;
    }
    public string levelName { get; set; }

    

    public SaveData(bool cleared, string name)
    {
        isCleared = cleared;
        levelName = name;
    }
}
