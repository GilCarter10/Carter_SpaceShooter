using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public Vector3 randVector;

    public bool randomize = true;

    private Vector3 oldLocation;

    private Vector3 desiredLocation;

    private Vector3 distanceToGo;

    private void Update()
    {

        EnemyMovement(5f, 10f);

    }

    public void EnemyMovement(float speed, float maxComponent)
    {

        if (randomize)
        {
            randVector.x = Random.Range(-maxComponent, maxComponent);
            randVector.y = Random.Range(-maxComponent, maxComponent);
            oldLocation = transform.position;
            randomize = false;
        }

        desiredLocation = oldLocation + randVector;

        transform.position += randVector.normalized * speed * Time.deltaTime;

        distanceToGo = transform.position - desiredLocation;

        if (distanceToGo.magnitude < 0.01) {
            randomize = true;
        }

        if (transform.position.x > 21.5 || transform.position.x < -21.5 || transform.position.y > 10.5 || transform.position.y < -10.5)
        {
            randomize = true;
        }

    }

}
