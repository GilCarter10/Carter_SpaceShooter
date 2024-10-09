using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    float currentTimeDrawing = 0f;
    private int currentStarIndex = 0;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {
        currentTimeDrawing += Time.deltaTime;
        float ratio = currentTimeDrawing / drawingTime;

        Vector3 startPoint = starTransforms[currentStarIndex].position;
        Vector3 endPoint = starTransforms[currentStarIndex + 1].position;

        Vector3 currentPosition = Vector3.Lerp(startPoint, endPoint, ratio);

        Debug.DrawLine(startPoint, currentPosition, Color.white);

        if (ratio >= 1)
        {
            currentStarIndex++;
            currentTimeDrawing = 0f;
            if (currentStarIndex + 1 >= starTransforms.Count)
            {
                currentStarIndex = 0;
            }
        }

    }
}


