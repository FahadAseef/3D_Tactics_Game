using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class characterController : MonoBehaviour
{
    private GameObject selectedCube;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private float speed = 5f; 

    public float gridSize = 1f; 

    
    public string obstacleTag = "obstacle";

    
    void Start()
    {

    }

    
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)&&!isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

               
                if (clickedObject.CompareTag("cube") && !clickedObject.CompareTag(obstacleTag))
                { 
                    // move the player
                    selectedCube = clickedObject;
                    targetPosition = selectedCube.transform.position;
                    isMoving = true;
                }
            }
        }
        
        if (isMoving)
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
      
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        
        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            isMoving = false;
        }
    }

   
}
