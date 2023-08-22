using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject DropItemPrefab;
    public List<loot> lootlist = new List<loot>();

    private loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<loot> PossibleItems = new List<loot>();
        foreach (loot item in lootlist) 
        {
            if (randomNumber <= item.dropChance) 
            { 
                PossibleItems.Add(item);
            }
        }
        if (PossibleItems.Count > 0 ) 
        { 
            loot droppedItem = PossibleItems[Random.Range(0, PossibleItems.Count)];
            return droppedItem;
        }
        return null;
    }

    public void InstatiateLoot(Vector3 spawnPosition) 
    { 
        loot DroppedItem = GetDroppedItem();
        if (DroppedItem != null)
        {
            GameObject lootGameObject = Instantiate(DropItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.name = DroppedItem.name;
            lootGameObject.GetComponent<DroppedLoot>().currentloot = DroppedItem;
            lootGameObject.GetComponent<SpriteRenderer>().sprite = DroppedItem.lootSprite;
        }
    }
}
