using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform Player;

    private void LateUpdate()
    {
        Vector3 newPosition = Player.position;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
