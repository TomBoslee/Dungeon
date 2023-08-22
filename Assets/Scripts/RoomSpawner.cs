using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 --> bottom door
    //2 --> top door
    //3 --> left door
    //4 --> right door
    private RoomTemplates templates;
    private int ran;
    private bool spawned = false;
    private int CurrentSeed;
    private int Limit = 10;

    private float waitTime = 10f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        if (WorldInfo.GetSeed() == "") 
        {
            string seed = "";
            for (int i = 0; i < 10; i++)
            {
                char ran = (char)Random.Range('a','z');
                seed = seed + ran;
            }
            WorldInfo.SetSeed(seed);
        }
        CurrentSeed = WorldInfo.GetSeed().GetHashCode();
        Random.InitState(CurrentSeed); 
        Invoke("Spawn",0.1f);
        if (WorldInfo.GetDifficulty() == 0) { Limit = 15; }
        else if (WorldInfo.GetDifficulty() == 1) { Limit = 30; }
        else if (WorldInfo.GetDifficulty() == 2) { Limit = 60; }

    }

    private void Spawn()
    {
        GameObject room = null;
        if (spawned == false) {
            //if at limit generate a closed wall to stop dungeon from growing in size
            if (AddRoom.AmountOfRooms >= Limit) { Instantiate(templates.closedRoom, transform.position, Quaternion.identity); }
            else if (openingDirection == 1) {
                //Add room with top opening
                ran = Random.Range(0, templates.topRooms.Length);
                room = Instantiate(templates.topRooms[ran], transform.position, templates.topRooms[ran].transform.rotation);
                
            } else if (openingDirection == 2)
            {
                //Add room with bottom opening
                ran = Random.Range(0, templates.bottomRooms.Length);
                room =Instantiate(templates.bottomRooms[ran], transform.position, templates.bottomRooms[ran].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //Add room with right opening
                ran = Random.Range(0, templates.rightRooms.Length);
                room = Instantiate(templates.rightRooms[ran], transform.position, templates.rightRooms[ran].transform.rotation);
            } else if (openingDirection == 4) {
                //Add room with left opening
                ran = Random.Range(0, templates.leftRooms.Length);
                room =Instantiate(templates.leftRooms[ran], transform.position, templates.leftRooms[ran].transform.rotation);
            }
           StartCoroutine(SpawnRoomContent(room));
            spawned= true;
        };
    }

     IEnumerator SpawnRoomContent(GameObject room) {
        yield return new WaitForSeconds(1);
        try { 
            if (room.transform != null) {
               ran = Random.Range(0, templates.TypeOfRoom.Length);
               GameObject roomType = Instantiate(templates.TypeOfRoom[ran], transform.position, templates.TypeOfRoom[ran].transform.rotation);
               roomType.transform.SetParent(room.transform);
            }    
        } catch { }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if (collision.CompareTag("Camera")) { Destroy(gameObject);Debug.Log("Impact"); }
            if (collision.GetComponent<RoomSpawner>().spawned == false && spawned == false) {
                templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
                Instantiate(templates.closedRoom,transform.position,Quaternion.identity);
                Destroy(gameObject);
            }
            spawned= true;
        }
    }
}
