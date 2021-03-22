using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DrawRay : MonoBehaviour
{
  
    public int maxReflectionCount = 5;
    public float maxStepDistance = 200;
    public Transform firepoint;
    public LineRenderer lr;
    private Vector3[] points = new Vector3[5];
    private void Start()
    {
      lr= this.gameObject.GetComponent<LineRenderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            DrawPredictionReflectionPattern(firepoint.position, firepoint.forward, maxReflectionCount);
        if(Input.GetKeyDown(KeyCode.R))
            ResetLine();
    }

    private void ResetLine()
    {
        for (int i = 0; i < 5; i++) {
            points[i] =new  Vector3(0f, 0f, 0f);
            lr.SetPosition(i,points[i]);
        }
     
    }
    void DrawPredictionReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        for (int i = 0; i < reflectionsRemaining; i++)
        {

            Vector3 startingPosition = position;
            lr.SetPosition(reflectionsRemaining - i+1, startingPosition);

            Ray ray = new Ray(position, direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxStepDistance))
            {
                direction =Vector3.Reflect(ray.direction, hit.normal);
                //float rot = 90 - Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
          
                position = hit.point;
            }
            else
            {
                position += direction * maxStepDistance;
            }
        }

    }
}



