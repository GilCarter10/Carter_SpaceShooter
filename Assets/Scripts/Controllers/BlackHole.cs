using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float radius;
    public GameObject ship;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //draw radius
        float circleAngle = 360 / 20;

        for (int i = 0; i < 20; i++)
        {
            Vector3 firstPoint = new Vector3(Mathf.Cos((circleAngle * i) * Mathf.Deg2Rad), (Mathf.Sin((circleAngle * i) * Mathf.Deg2Rad))) * radius + transform.position;
            Vector3 nextPoint = new Vector3(Mathf.Cos((circleAngle * (i + 1)) * Mathf.Deg2Rad), (Mathf.Sin((circleAngle * (i + 1)) * Mathf.Deg2Rad))) * radius + transform.position;
            Debug.DrawLine(firstPoint, nextPoint, Color.white);
        }



    }
}
