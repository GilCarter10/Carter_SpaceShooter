using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCircle : MonoBehaviour
{

    public List<float> angles;

    private int currentAngle = 0;
    private Vector3 currentPoint;

    public float radius = 4; 
    public Vector3 circlePos = Vector3.zero;

    private float durationTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        durationTimer += Time.deltaTime;
        
        currentPoint = new Vector3(Mathf.Cos(angles[currentAngle] * Mathf.Deg2Rad), (Mathf.Sin(angles[currentAngle] * Mathf.Deg2Rad))) * radius;

        Debug.DrawLine(circlePos, currentPoint + circlePos);

        if (durationTimer > 1)
        {
            currentAngle++;
            durationTimer = 0;
        }
        if (currentAngle > 9)
        {
            currentAngle = 0;
        }
    }
}
