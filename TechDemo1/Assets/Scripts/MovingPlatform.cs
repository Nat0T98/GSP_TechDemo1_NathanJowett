using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 LocationA;
    private Vector3 LocationB;
    private Vector3 NextLocation;


    [SerializeField] private Transform platform;
    [SerializeField] private Transform MovingToLocation;


    public float speed = 1.5f;

    private void Start()
    {
        LocationA = platform.localPosition;
        LocationB = MovingToLocation.localPosition;
        NextLocation = LocationB;
    }

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        platform.localPosition = Vector3.MoveTowards(platform.localPosition, NextLocation, speed *Time.deltaTime);

        if(Vector3.Distance(platform.localPosition,NextLocation) <= 0.1)
        {
            changePos();
        }    
    }

    private void changePos()
    {
        NextLocation = NextLocation != LocationA ? LocationA : LocationB;
    }
    

}

    