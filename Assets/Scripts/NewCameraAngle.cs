using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraAngle : MonoBehaviour
{
    [Space]
    public Vector3 inAngle;
    public Vector3 outAngle;

    public bool cameraPos;
    public Vector3 newCameraPos;

    CameraFollow mainCamera;

    void Start()
    {
        mainCamera = Camera.main.transform.parent.GetComponent<CameraFollow>();
    }

    public void SetNewCamera(Vector3 _angle)
    {
        mainCamera.SetNewAngle(_angle);

        if (cameraPos)
            mainCamera.SetNewPosition(newCameraPos);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            Debug.Log("ENTER");
            SetNewCamera(inAngle);
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
            SetNewCamera(outAngle);
    }
}
