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

    public Vector3 velocity = Vector3.zero;

    public float acceleration;

    private float maxSpeed = 5f;

    private float accelerationTime = 2f;

    private float decelerationTime = 5f;

    private bool decelerateUp = false;
    private bool decelerateDown = false;
    private bool decelerateLeft = false;
    private bool decelerateRight = false;

    private float circleAngle;
    private Vector3 firstPoint;
    private Vector3 nextPoint;
    private Color radarColour;

    public float radarRadius;
    public int radarPoints;

    private void Start()
    {
    }

    void Update()
    {

        PlayerMovement(accelerationTime);

        EnemyRader(radarRadius, radarPoints);


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


    public void EnemyRader(float radius, int circlePoints)
    {
        circleAngle = 360 / circlePoints;
        
        for (int i = 0; i < circlePoints; i++)
        {
            firstPoint = new Vector3(Mathf.Cos(circleAngle + (circleAngle * i) * Mathf.Deg2Rad), (Mathf.Sin(circleAngle + (circleAngle * i) * Mathf.Deg2Rad))) * radius + transform.position;
            nextPoint = new Vector3(Mathf.Cos(circleAngle + (circleAngle * (i + 1)) * Mathf.Deg2Rad), (Mathf.Sin(circleAngle + (circleAngle * (i + 1)) * Mathf.Deg2Rad))) * radius + transform.position;
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


}




