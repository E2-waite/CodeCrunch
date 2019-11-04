using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    bool target_set = false;
    GameObject target;
    Vector3 target_pos;
    public float shot_speed;
    Vector3 point0, point1, point2;
    int current_target = 0;
    private int num_points = 100;
    private Vector3[] positions;

    void Start()
    {
        positions = new Vector3[num_points];
    }

    public void SetTarget(GameObject robot)
    {
        target = robot;
        point0 = transform.position;             
        target_set = true;    
    }

    void Update()
    {          
        if (target_set)
        {
            point2 = target.transform.position;
            Vector3 difference = point2 - point0;
            Vector3 center = point0 + difference * 0.5f;
            point1 = new Vector3(center.x, target.transform.position.y + 6, center.z);

            DrawQuadraticCurve();
            target_pos = positions[current_target];
            transform.LookAt(target_pos);        
            transform.position = Vector3.MoveTowards(transform.position, target_pos ,shot_speed * Time.deltaTime); 
            if (transform.position == target_pos  && current_target < num_points)
            {
                current_target++;
            }

            if (transform.position == target.transform.position)
            {              
                if (target.tag == "Robot")
                {
                    RobotMovement robot_scr = target.GetComponent<RobotMovement>();
                    robot_scr.Respawn();
                    Destroy(this.gameObject);
                }
                // Explode                
            }
        }
    }

    private void DrawQuadraticCurve()
    {
        for (int i = 1; i < num_points + 1; i++)
        {
            float t = i / (float)num_points;
            positions[i - 1] = CalculateQuadraticBezierPoint(t, point0, point1, point2);
        }
    }

    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }
}
