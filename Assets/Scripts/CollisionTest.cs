using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag.Equals("Player"))
            Debug.Log("TEST");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag.Equals("Player"))
            Debug.Log("TRIGGER");
    }
}
