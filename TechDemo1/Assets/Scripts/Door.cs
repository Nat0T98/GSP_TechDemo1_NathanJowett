using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform NextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x && collision.transform.position.y < transform.position.y) 
                cam.MoveToNewZone(NextRoom);
            else
                cam.MoveToNewZone(previousRoom);
        }
    }


}
