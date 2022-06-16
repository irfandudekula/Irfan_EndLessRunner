using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerPos;
    private Vector3 offsetValue;
    void Start()
    {
        offsetValue = transform.position - PlayerPos.position;              //taking offset position value for camera
    }

   
    void Update()
    {
        Vector3 Final_pos = new Vector3(transform.position.x, transform.position.y, offsetValue.z + PlayerPos.position.z);          //updating new  final position for camera
        transform.position = Final_pos;
    }
}
