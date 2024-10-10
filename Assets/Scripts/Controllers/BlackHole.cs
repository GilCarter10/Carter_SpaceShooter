using Codice.Client.BaseCommands;
using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BlackHole : MonoBehaviour
{
    public float radius;
    public GameObject ship;
    Vector3 holeToShip;
    bool activate;
    public float angle;

    public float toCenterSpeed;

    private Vector3 spiralOffset;


    float orbitRadius;
    public float orbitSpeed = 60;



    // Start is called before the first frame update
    void Start()
    {
        orbitRadius = radius;
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

        holeToShip = ship.transform.position - transform.position;
        //spiralOffset = new Vector3(Mathf.Cos(startingAngle * Mathf.Deg2Rad), (Mathf.Sin(startingAngle * Mathf.Deg2Rad))) * orbitRadius;

        if (holeToShip.magnitude <= radius)
        {
            activate = true;
        }

        if (activate)
        {
            ////Vector3 toCenter = holeToShip.normalized * toCenterSpeed;
            ////ship.transform.position += toCenter * Time.deltaTime;
            //startingAngle += Time.deltaTime * orbitSpeed;
            //ship.transform.position += spiralOffset;



            spiralOffset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), (Mathf.Sin(angle * Mathf.Deg2Rad))) * orbitRadius;

            ship.transform.position = transform.position + spiralOffset;
            angle += Time.deltaTime * orbitSpeed;
            
            orbitRadius -= Time.deltaTime * toCenterSpeed;
            if (orbitRadius <= 0)
            {
                orbitRadius = 0;
            }

        } else
        {
            angle = Mathf.Atan2(holeToShip.y, holeToShip.x ) * Mathf.Rad2Deg;
            activate = false;
        }

    }

}
