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


    //Bomb Variables
    public Vector2 bombOffset;
    public int numberOfBombs;
    public float bombTrailSpacing;

    public float explosionDistance;
    public float bombSpeed;
    private List<GameObject> activeBombs = new List<GameObject>();

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
        
        if (Input.GetKeyDown("b"))
        {
            SpawnBombAtOffset(bombOffset);
        }

        if (Input.GetKeyDown("t"))
        {
            SpawnBombTrail(bombTrailSpacing, numberOfBombs);
        }

        if (Input.GetKeyDown("c"))
        {
            SpawnBombOnRandomCorner(0.5f);
        }


        FireBombs(explosionDistance);



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
            //Debug.Log("instantiated");
        }

        //create variable for powerup prefab
        //use a for loop to run as many times as there are powerups to be spawned
        //divide 360 by the number of powerups
        //turn that angle into a vector using the "P = (cos(), sin()) * radius" method
        //use that vector to offset the powerup position
        //increase the angle each time the for loop runs
    }

    
    //adding all the bomb methods from Week 2
    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        GameObject newBomb = Instantiate(bombPrefab, transform.position + inOffset, transform.rotation);
        activeBombs.Add(newBomb);
        newBomb.GetComponent<Bomb>().offset = inOffset;
        newBomb.GetComponent<Bomb>().ship = gameObject;
    }

    public void SpawnBombTrail(float inBombSpacing, int inNumberofBombs)
    {
        Vector3 bombPos = transform.position;

        for (int i = 0; i < inNumberofBombs; i++)
        {
            float maxSpacing = inBombSpacing * numberOfBombs;
            Vector2 trailOffset = new Vector2 (0, -maxSpacing - (-inBombSpacing * i));
            bombPos.y += trailOffset.y;

            GameObject newBomb = Instantiate(bombPrefab, bombPos, transform.rotation);
            activeBombs.Add(newBomb);
            newBomb.GetComponent<Bomb>().offset = trailOffset;
            newBomb.GetComponent<Bomb>().ship = gameObject;
        }
    }

    public void SpawnBombOnRandomCorner(float inDistance)
    {
        int corner = Random.Range(1, 5);
        Vector3 cornerOffset = Vector3.zero;

        if (corner == 1)
        {
            cornerOffset = new Vector3(inDistance, inDistance);
        }
        else if (corner == 2)
        {
            cornerOffset = new Vector3(inDistance, -inDistance);
        }
        else if (corner == 3)
        {
            cornerOffset = new Vector3(-inDistance, inDistance);
        }
        else if (corner == 4)
        {
            cornerOffset = new Vector3(-inDistance, -inDistance);
        }

        GameObject newBomb = Instantiate(bombPrefab, transform.position + cornerOffset, transform.rotation);
        activeBombs.Add(newBomb);
        newBomb.GetComponent<Bomb>().offset = cornerOffset;
        newBomb.GetComponent<Bomb>().ship = gameObject;
    }

    public void FireBombs(float explosionDistance)
    {

        if (Input.GetKeyDown("space"))
        {

            if (activeBombs.Count > 0)
            {
                activeBombs[0].GetComponent<Bomb>().StartMoving();
                activeBombs[0].GetComponent<Bomb>().explosionDistance = explosionDistance;
                activeBombs[0].GetComponent<Bomb>().speed = bombSpeed;
                activeBombs.RemoveAt(0);

            }
        }
    }


}




