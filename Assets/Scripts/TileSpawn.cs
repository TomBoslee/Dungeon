using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    public GameObject[] tiles;

    private void Start()
    {
        int rand = Random.Range(0,tiles.Length);
        GameObject instance = (GameObject)Instantiate(tiles[rand], transform.position, Quaternion.identity);
        instance.tag = "Wall";
        instance.transform.parent = transform;
    }
}
