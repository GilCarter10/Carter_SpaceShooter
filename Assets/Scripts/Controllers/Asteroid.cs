using PlasticPipe.PlasticProtocol.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 100;
    public float arrivalDistance = 2;
    public float maxFloatDistance = 0.5f;

    public Vector3 movement;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        movement.x = Random.Range(-maxFloatDistance, maxFloatDistance);
        movement.y = Random.Range(-maxFloatDistance, maxFloatDistance);
        target = transform.position + movement;
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {

        transform.position += movement.normalized * moveSpeed * Time.deltaTime;

        if ((target - transform.position).magnitude < arrivalDistance)
        {
            movement.x = Random.Range(-maxFloatDistance, maxFloatDistance);
            movement.y = Random.Range(-maxFloatDistance, maxFloatDistance);
            target = transform.position + movement;
        }

    }
}
