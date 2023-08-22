using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class loot :ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;

    public loot(string lootName, int dropChance) 
    { 
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
