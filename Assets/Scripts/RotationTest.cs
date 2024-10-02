using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float angularSpeed;
    private float targetAngle;
    Vector2 lineCoords;

    public Transform targetTransform;
    Vector2 toTargetVector;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(transform.position, targetTransform.position, Color.blue);

        toTargetVector = targetTransform.position - transform.position;

        targetAngle = Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg;


        if (transform.eulerAngles.z < targetAngle)
        {
            //We have not yet arrived at our target, so we still need to rotate more
            transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
        }

        //If we have now overshot the angle
        if (transform.eulerAngles.z > targetAngle)
        {
            //We snap back to the correct target angle because it's too high
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                                                transform.eulerAngles.y,
                                                targetAngle);
        }

        lineCoords = (transform.position + (transform.up * 3));

        Debug.DrawLine(transform.position, lineCoords);

    }

    public float StandardizeAngle(float inAngle)
    {
        inAngle = inAngle % 360;

        inAngle = (inAngle + 360) % 360;

        if(inAngle > 180)
        {
            inAngle -= 360;
        }

        return inAngle;
    }



}
