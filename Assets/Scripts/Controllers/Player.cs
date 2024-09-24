﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public Vector3 velocity = Vector3.zero;

    public float acceleration;

    private float maxSpeed = 5f;

    private float accelerationTime = 2f;

    private float decelerationTime = 5f;

    private bool decelerateUp = false;
    private bool decelerateDown = false;
    private bool decelerateLeft = false;
    private bool decelerateRight = false;

    private void Start()
    {
    }

    void Update()
    {

        PlayerMovement(accelerationTime);


    }

    public void PlayerMovement(float timeToReachSpeed)
    {
        transform.position += velocity * Time.deltaTime;

        if (Input.GetKey("up"))
        {
            acceleration = maxSpeed / timeToReachSpeed;
            if (velocity.magnitude < maxSpeed)
            {
                velocity += acceleration * Vector3.up * Time.deltaTime;
            }
        }
        if (Input.GetKey("down"))
        {
            acceleration = maxSpeed / timeToReachSpeed;
            if (velocity.magnitude < maxSpeed)
            {
                velocity += acceleration * Vector3.down * Time.deltaTime;
            }
        }
        if (Input.GetKey("left"))
        {
            acceleration = maxSpeed / timeToReachSpeed;
            if (velocity.magnitude < maxSpeed)
            {
                velocity += acceleration * Vector3.left * Time.deltaTime;
            }
        }
        if (Input.GetKey("right"))
        {
            acceleration = maxSpeed / timeToReachSpeed;
            if (velocity.magnitude < maxSpeed)
            {
                velocity += acceleration * Vector3.right * Time.deltaTime;
            }
            
        }

        if (Input.GetKeyUp("up"))
        {
            decelerateUp = true;
        }

        if (Input.GetKeyUp("down"))
        {
            decelerateDown = true;
        }

        if (Input.GetKeyUp("right"))
        {

            decelerateRight = true;
        }

        if (Input.GetKeyUp("left"))
        {

            decelerateLeft = true;
        }


        if (decelerateUp == true)
        {
            if (velocity.magnitude > 0.01)
            {
                acceleration = 10f / decelerationTime;
                velocity -= acceleration * Vector3.up * Time.deltaTime;
            }
            if ((velocity.magnitude < 0.01)){
                velocity = Vector3.zero;
                decelerateUp = false;
            }
        }
        if (decelerateDown == true)
        {
            if (velocity.magnitude > 0.01)
            {
                acceleration = 10f / decelerationTime;
                velocity -= acceleration * Vector3.down * Time.deltaTime;
            }
            if ((velocity.magnitude < 0.01))
            {
                velocity = Vector3.zero;
                decelerateDown = false;
            }
        }
        if (decelerateRight == true)
        {
            if (velocity.magnitude > 0.01)
            {
                acceleration = 10f / decelerationTime;
                velocity -= acceleration * Vector3.right * Time.deltaTime;
            }
            if ((velocity.magnitude < 0.01))
            {
                velocity = Vector3.zero;
                decelerateRight = false;
            }
        }
        if (decelerateLeft == true)
        {
            if (velocity.magnitude > 0.01)
            {
                acceleration = 10f / decelerationTime;
                velocity -= acceleration * Vector3.left * Time.deltaTime;
            }
            if ((velocity.magnitude < 0.01))
            {
                velocity = Vector3.zero;
                decelerateLeft = false;
            }
        }


    }






























}




