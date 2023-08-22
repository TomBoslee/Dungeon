using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Monster[] AllMonsters;
    private float health;
    private GameObject player;
    private Sprite sprite;
    private float speed;
    private float radius;
    private float distance;
    private int damage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        Monster me = AllMonsters[Random.Range(0,AllMonsters.Count())];
        sprite = me.MonsterSprite;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        speed = me.MonsterSpeed;
        radius = me.MonsterRadius;
        damage = me.MonsterDamage;
        health = me.MonsterHp;
        gameObject.name = me.MonsterName;
    }

    public void TakeDamage(float d) {
        health = health - d;
    }

    public void Update()
    {
        if (health < 1) { GetComponent<LootBag>().InstatiateLoot(transform.position); Destroy(gameObject); }
        distance = Vector2.Distance(transform.position, player.transform.position);
        
        if (distance <= radius) {
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.x, direction.x) * Mathf.Rad2Deg;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag ==  "Player") {
            collision.gameObject.GetComponent<Player>().DecreaseHp(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
