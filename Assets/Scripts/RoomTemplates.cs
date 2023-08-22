using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject[] TypeOfRoom;

    public GameObject closedRoom;
    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedExit;
    public GameObject Exit;
    public GameObject startRoom;
    public Vector3 furthestRoom;

    private void Update()
    {
        if (waitTime <= 0 && spawnedExit == false)
        {
            foreach (GameObject n in rooms)
            {
                if (Vector3.Distance(n.transform.position, startRoom.transform.position) > Vector3.Distance(furthestRoom, startRoom.transform.position))
                {
                    furthestRoom = n.transform.position;
                }

            }
            Instantiate(Exit, furthestRoom, Quaternion.identity);
            spawnedExit = true;
        }else{waitTime -= Time.deltaTime;}
        
    }
}