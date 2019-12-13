using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    public Transform path;
    private Transform[] paths;
    [Space]

    public float speed = 1f;

    int currentPath;
    Vector3[] bezierPoints;
    float pathValue;


    void Start()
    {
        paths = new Transform[path.childCount];
        
        for (int i = 0; i < path.childCount; ++i)
        {
            paths[i] = path.GetChild(i);
        }

        currentPath = 0;

        AssingPath();
    }

    public void RunPath()
    {
        if (pathValue < 1)
        {
            pathValue += speed * Time.deltaTime;

            this.transform.position = 
            
            Mathf.Pow(1 - pathValue, 3) * bezierPoints[0] + 
            3 * Mathf.Pow(1 - pathValue, 2) * pathValue * bezierPoints[1] +
            3 * (1 - pathValue) * Mathf.Pow (pathValue, 2) * bezierPoints[2] +
            Mathf.Pow(pathValue, 3) * bezierPoints[3];    
        }

        else if(pathValue >= 1)
            AssingPath();
    }

    public void AssingPath()
    {
        if (currentPath < paths.Length)
        {
            bezierPoints = new Vector3[paths[currentPath].childCount];

            for (int i = 0; i < paths[currentPath].childCount; ++i)
            {
                bezierPoints[i] = paths[currentPath].GetChild(i).position;
            }

            currentPath++;
            pathValue = 0;
        }
    }

    public void RestartPath()
    {
        pathValue = 0;

        GameMaster.GM.gameState = GameState.StPlaying;
    }
}
