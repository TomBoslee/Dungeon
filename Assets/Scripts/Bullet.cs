using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private GameObject Player;
    private float Damage = 2f;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Damage = Player.GetComponent<Player>().GetDamage();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag) {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Enemy":
                collision.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
                Destroy (gameObject);
                break;
            case "Chest":
                collision.gameObject.GetComponent<Chest>().TakeDamage(Damage);
                Destroy(gameObject);
                break;
        }
    }
}
