using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    
    //General Velocity
    public float maxSpeed;
    private Vector3 currentVelocity;

    //Acceleration
    public float accelerationTime;
    private float acceleration;

    //Deceleration
    public float decelerationTime;
    private float deceleration;


    //Radar Variables
    private float circleAngle;
    private Vector3 firstPoint;
    private Vector3 nextPoint;
    private Color radarColour;

    public float radarRadius;
    public int radarPoints;


    //Powerup Variables
    public GameObject powerupPrefab;
    private Vector3 powerupTransform;
    private float powerupAngle;
    private Vector3 powerupOffset;

    public float powerupRadius;
    public int powerupNumber;


    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
    }

    void Update()
    {

        PlayerMovement();

        EnemyRader(radarRadius, radarPoints);

        if (Input.GetKeyDown("p"))
        {
            SpawnPowerups(powerupRadius, powerupNumber);
        }


    }

    public void PlayerMovement()
    {
        Vector2 currentInput = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentInput += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentInput += Vector2.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentInput += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentInput += Vector2.down;
        }
        
        if (currentInput.magnitude > 0)
        {
            //our character is accelerating
            currentVelocity += acceleration * Time.deltaTime * (Vector3)currentInput.normalized;
            if (currentVelocity.magnitude > maxSpeed)
            {
                currentVelocity = currentVelocity.normalized * maxSpeed;
            }
        } else
        {
            //Our character is decelerating
            Vector3 velocityDelta = (Vector3)currentVelocity.normalized * deceleration * Time.deltaTime;
            if(velocityDelta.magnitude > currentVelocity.magnitude)
            {
                currentVelocity = Vector3.zero;
            }
            else
            {
                currentVelocity -= velocityDelta;
            }
        }
        transform.position += currentVelocity * Time.deltaTime;


    }


    public void EnemyRader(float radius, int circlePoints)
    {
        circleAngle = 360 / circlePoints;
        
        for (int i = 0; i < circlePoints; i++)
        {
            firstPoint = new Vector3(Mathf.Cos((circleAngle * i) * Mathf.Deg2Rad), (Mathf.Sin((circleAngle * i) * Mathf.Deg2Rad))) * radius + transform.position;
            nextPoint = new Vector3(Mathf.Cos((circleAngle * (i + 1)) * Mathf.Deg2Rad), (Mathf.Sin((circleAngle * (i + 1)) * Mathf.Deg2Rad))) * radius + transform.position;
            Debug.DrawLine(firstPoint, nextPoint, radarColour);
        }

        Vector3 enemyDistance = transform.position - enemyTransform.position;

        if (enemyDistance.magnitude < radius)
        {
            radarColour = Color.red;
        } else
        {
            radarColour = Color.green;
        }


        //divide 360 by circle points
        //first point should have an angle of of (360 divided by circle points) and each point after should have an angle of that plus that again
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        powerupAngle = 360 / numberOfPowerups;
        
        for (int i = 0; i <= numberOfPowerups; i++)
        {
            powerupOffset = new Vector3(Mathf.Cos((powerupAngle * i) * Mathf.Deg2Rad), (Mathf.Sin((powerupAngle * i) * Mathf.Deg2Rad))) * radius;
            powerupTransform = transform.position + powerupOffset;
            Instantiate(powerupPrefab, powerupTransform, transform.rotation);
            Debug.Log("instantiated");
        }

        //create variable for powerup prefab
        //use a for loop to run as many times as there are powerups to be spawned
        //divide 360 by the number of powerups
        //turn that angle into a vector using the "P = (cos(), sin()) * radius" method
        //use that vector to offset the powerup position
        //increase the angle each time the for loop runs
    }

}




