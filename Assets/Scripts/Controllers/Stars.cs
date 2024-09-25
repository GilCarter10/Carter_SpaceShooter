using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    float timer;
    Vector3 nextPoint;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {
        timer += Time.deltaTime;
        nextPoint = starTransforms[0].transform.position + (starTransforms[1].transform.position - starTransforms[0].transform.position).normalized * timer;

        Debug.DrawLine(starTransforms[0].transform.position, nextPoint);
        
    }
}


