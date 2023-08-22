using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Monster : ScriptableObject
{
    public Sprite MonsterSprite;
    public string MonsterName;
    public int MonsterHp;
    public float MonsterSpeed;
    public float MonsterRadius;
    public int MonsterDamage;

    public Monster(string monsterName, int monsterHp, float monsterSpeed, float monsterRadius, int monsterDamage)
    {
        MonsterName = monsterName;
        MonsterHp = monsterHp;
        MonsterSpeed = monsterSpeed;
        MonsterRadius = monsterRadius;
        MonsterDamage = monsterDamage;
    }

    public Monster(string monsterName) {
        MonsterName =monsterName;
        MonsterHp = Random.Range(1,20);
        MonsterSpeed = Random.Range(1f,3f);
        MonsterRadius = Random.Range(1f,5f);
        MonsterDamage = Random.Range(1,20);
    }
}
