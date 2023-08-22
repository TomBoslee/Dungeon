using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firepoint;
    private float fireForce = 20;
    public void fire() { 
        GameObject projectile = Instantiate(bullet, firepoint.position,firepoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firepoint.up * fireForce, ForceMode2D.Impulse);
    }
}
