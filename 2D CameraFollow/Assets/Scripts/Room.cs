using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //BoxCollider2D boundary = transform.parent.Find("RoomCameraBoundary").GetComponent<BoxCollider2D>();
            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FinalCameraScript>().refreshBoundary(boundary);
        }
    }
}
