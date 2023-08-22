using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private float Health = 2;

    public void TakeDamage(float d)
    {
        Health = Health - d;
    }

    public void Update()
    {
        if (Health < 1) {
            GetComponent<LootBag>().InstatiateLoot(transform.position);
            Destroy(gameObject); 
        }
    }

}
