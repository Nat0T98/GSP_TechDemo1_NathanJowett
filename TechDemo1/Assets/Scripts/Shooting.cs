using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shooting : MonoBehaviour
{

    public Transform shootingPoint;
    public GameObject BoomerangPrefab;
  
    void Update()
    {
        if(Keyboard.current.bKey.wasPressedThisFrame) 
        {
            Instantiate(BoomerangPrefab, shootingPoint.position, transform.rotation);

        }
    }
}
