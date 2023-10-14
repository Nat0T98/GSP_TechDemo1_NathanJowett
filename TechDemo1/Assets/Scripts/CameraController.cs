using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPosX;
    private float currentPosY;
    private Vector3 velocity = Vector3.zero;


    private void Start()
    {
        currentPosX = transform.position.x;
        currentPosY = transform.position.y;
    }

    private void Update()
    {
       transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, currentPosY, transform.position.z),
           ref velocity, speed);
        
    }

    public void MoveToNewZone(Transform _NewRoom)
    {
        currentPosX = _NewRoom.position.x;
        currentPosY = _NewRoom.position.y;
    }
}
