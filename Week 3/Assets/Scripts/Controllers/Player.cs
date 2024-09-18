using Codice.Client.BaseCommands.CheckIn.Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //private Vector3 velocity = Vector3.zero;

    public float speed = 5f;

    private float timetoReachSpeed = 3f;

    private float targetSpeed = 2f;

    private float acceleration;

    private float maxSpeed;

    private void Start()
    {
        acceleration = targetSpeed / timetoReachSpeed;
    }

    void Update()
    {
        //velocity += acceleration * transform.up * Time.deltaTime;


        if (Input.GetKey("up"))
        {
            PlayerMovement(Vector3.up, speed);
        }
        if (Input.GetKey("down"))
        {
            PlayerMovement(Vector3.down, speed);
        }
        if (Input.GetKey("left"))
        {
            PlayerMovement(Vector3.left, speed);
        }
        if (Input.GetKey("right"))
        {
            PlayerMovement(Vector3.right, speed);
        }
    }

    public void PlayerMovement(Vector3 velocity, float speedValue)
    {
        velocity += acceleration * velocity * Time.deltaTime;
        transform.position += transform.up * speedValue * Time.deltaTime;

    }

}
