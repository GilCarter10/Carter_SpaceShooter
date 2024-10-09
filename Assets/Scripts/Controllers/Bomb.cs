using Codice.Client.BaseCommands.CheckIn.Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Vector3 offset;
    public bool attached = true;
    public GameObject ship;
    public Vector3 shipTransform;
    public Vector3 bombDist;
    Vector3 bombDirection;
    
    public float speed;
    public float explosionDistance;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attached)
        {
            //Debug.Log("attached");
            transform.position = ship.transform.position + offset;
        } else
        {
            //Debug.Log("MOVING");
            transform.position += bombDirection * speed * Time.deltaTime;
            bombDist = shipTransform - transform.position;
            if (bombDist.magnitude > explosionDistance)
            {
                Destroy(gameObject);

            }
        }
    }

    public void StartMoving()
    {
        shipTransform = ship.transform.position;
        bombDirection = offset.normalized;
        attached = false;
    }

}
