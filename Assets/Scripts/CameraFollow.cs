using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform mainCamera;
    public Transform target;

    public float cameraFollowSpeed = 2.5f;
    public float cameraTurningSpeed = 50f;

    Vector3 targetPosition;
    Quaternion targetRotation;
    Vector3 offSetValue;

    int triggerCounter;

    bool follow = true;


	void Start ()
    {
        mainCamera = Camera.main.transform;

        targetRotation = Quaternion.Euler(Vector3.zero);

        offSetValue = mainCamera.transform.position - target.transform.position;
    }
	
	void Update ()
    {
        if (follow)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, target.position, cameraFollowSpeed * Time.deltaTime);
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, cameraTurningSpeed * Time.deltaTime);
        }
    }

    public void SetNewAngle(Vector3 _newAngle)
    {
        targetRotation = Quaternion.Euler(_newAngle);
    }

    public void SetNewPosition(Vector3 _pos)
    {
        targetPosition = _pos;
    }

    public void FollowTarget(bool _value)
    {
        follow = _value;
    }
}
