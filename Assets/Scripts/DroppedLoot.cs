using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedLoot : MonoBehaviour
{
    public loot currentloot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (currentloot.name == "Heart")
            {
                Heart(collision.gameObject);
            }
            else if (currentloot.name == "Yellow Heart")
            {
                YellowHeart(collision.gameObject);
            }
            else if (currentloot.name == "Upgrade") {
                Upgrade(collision.gameObject);
            }
            Destroy(gameObject); 
        }    
    }

    private void Heart(GameObject player) { 
        player.GetComponent<Player>().IncreaseHp(20);
    }

    private void YellowHeart(GameObject player) {
        player.GetComponent <Player>().increaseMaxHp(20);
    }

    private void Upgrade(GameObject player) {
        player.GetComponent<Player>().IncreaseLevel();
    }
}
