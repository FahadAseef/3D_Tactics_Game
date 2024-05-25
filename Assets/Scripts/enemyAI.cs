using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public GameObject playerUnit;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private float speed = 3f; 
    private Vector3 lastPlayerPosition;
    private Vector3 lastPlayerVelocity;
    public float stopDistance = 1.0f; 

   
    void Start()
    {
      
        playerUnit = GameObject.FindGameObjectWithTag("Player");
        lastPlayerPosition = playerUnit.transform.position;
        lastPlayerVelocity = Vector3.zero;
    }

    
    void Update()
    {
        
        Vector3 playerVelocity = (playerUnit.transform.position - lastPlayerPosition) / Time.deltaTime;

       
        if (playerVelocity == Vector3.zero && lastPlayerVelocity != Vector3.zero)
        {
            targetPosition = playerUnit.transform.position;
            isMoving = true;
        }
        else if (playerVelocity != Vector3.zero)
        {
            isMoving = false; 
        }

        
        lastPlayerPosition = playerUnit.transform.position;
        lastPlayerVelocity = playerVelocity;

        
        if (isMoving)
        {
            MoveToTarget(targetPosition);
        }
    }

    void MoveToTarget(Vector3 targetPosition)
    {
       
        float step = speed * Time.deltaTime;
        float distanceToPlayer = Vector3.Distance(transform.position, playerUnit.transform.position);

        
        if (distanceToPlayer > stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        else
        {
            isMoving = false;
        }
    }
}
