using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecoins : MonoBehaviour
{
    public float speed = 0.6f;
    
    void Update()
    {
        this.gameObject.transform.Rotate(Vector3.right * speed);             //to rotate around object
    }
}
