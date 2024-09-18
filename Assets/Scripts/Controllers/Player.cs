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

        PlayerMovement();
        

    }

    public void PlayerMovement()
    {
        
        if (Input.GetKey("up"))
        {
            transform.position += Vector3.up * acceleration * Time.deltaTime;
            if ()

        }
        if (Input.GetKey("down"))
        {
            transform.position += Vector3.down * acceleration * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            transform.position += Vector3.left * acceleration * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            transform.position += Vector3.right * acceleration * Time.deltaTime;
        }
    }

}
