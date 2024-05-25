using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
  
    public Vector3 tilePos;

    private void Start()
    {
         tilePos=transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {

            this.gameObject.tag = "obstacle";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        this.gameObject.tag = "cube";
    }

}
