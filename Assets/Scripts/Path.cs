using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform[] bezierPoints = new Transform[4];
    [Space]

    [Range (0.01f, 0.5f)] public float distanceBetween = 0.1f;
    [Space]

    public bool showPoints = true;
    public bool showLines = true;
    public bool showPath = true;


    Vector3 pointsPosition;


    // Since im using gizmos to draw the path, having a Start function its useless, becasue the script is not running at the moment the gizmos are trying to be drawn
    // void Start()
    // {
    //     Transform[] bezierPoints = new Transform[4];

    //     for(int i = 0; i < this.transform.childCount; ++i)
    //     {
    //         bezierPoints[i] = this.transform.GetChild(i);
    //     }
    // }


    private void OnDrawGizmos()
    {
        if (showPath)
        {
            Gizmos.color = Color.yellow;

            for (float t = 0; t <= 1; t+= distanceBetween)
            {
                pointsPosition = 
                
                Mathf.Pow(1 - t, 3) * bezierPoints[0].position + 
                3 * Mathf.Pow(1 - t, 2) * t * bezierPoints[1].position +
                3 * (1 - t) * Mathf.Pow (t, 2) * bezierPoints[2].position +
                Mathf.Pow(t, 3) * bezierPoints[3].position;

                Gizmos.DrawSphere(pointsPosition, 0.2f);
            }
        }
        
        if (showPoints)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(bezierPoints[0].position, 0.4f);
            Gizmos.DrawSphere(bezierPoints[3].position, 0.4f);

            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(bezierPoints[1].position, 0.3f);
            Gizmos.DrawSphere(bezierPoints[2].position, 0.3f);
        }
        

        if (showLines)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(bezierPoints[0].position, bezierPoints[1].position);
            Gizmos.DrawLine(bezierPoints[3].position, bezierPoints[2].position);
        }  
    }
}
