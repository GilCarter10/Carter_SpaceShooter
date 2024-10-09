using System.Collections;
using System.Collections.Generic;
using UnityEditor.Graphs;
using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public float redAngle = 45;
    public float blueAngle = 60;

    Vector3 redVector;
    Vector3 blueVector;

    float dotProduct;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        redVector = new Vector2(Mathf.Cos(redAngle * Mathf.Deg2Rad), Mathf.Sin(redAngle * Mathf.Deg2Rad)) * 1;
        blueVector = new Vector2(Mathf.Cos(blueAngle * Mathf.Deg2Rad), Mathf.Sin(blueAngle * Mathf.Deg2Rad)) * 1;

        Debug.DrawLine(Vector2.zero, redVector, Color.red);
        Debug.DrawLine(Vector2.zero, blueVector, Color.blue);

        if (Input.GetKeyDown("space"))
        {
            dotProduct = Vector3.Dot(redVector, blueVector);
            Debug.Log(dotProduct); 
        } 



    }
}
