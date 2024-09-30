using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitRadius;
    public float orbitSpeed;

    public float moonAngle;
    private Vector3 moonOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(orbitRadius, orbitSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {

        moonOffset = new Vector3(Mathf.Cos(moonAngle * Mathf.Deg2Rad), (Mathf.Sin(moonAngle * Mathf.Deg2Rad))) * radius;

        transform.position = target.position + moonOffset;

        moonAngle += Time.deltaTime * speed;

        //Create a variable for the angle of the moon
        //Have this variable increase over time with a timer function
        //That is where we will apply the speed variable
        //Use the same method of turning an angle into a vector offset
        //Make the moon transform always equal to the target transform plus the vector offset
    }
}
