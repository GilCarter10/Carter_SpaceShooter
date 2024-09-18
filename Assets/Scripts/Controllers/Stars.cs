using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {
        for (int i = 0; i < starTransforms.Count; i++)
        {
            Debug.DrawLine(starTransforms[i].transform.position, starTransforms[i + 1].transform.position, Color.blue);
        }
    }
}


