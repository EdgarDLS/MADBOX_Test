using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            Debug.Log("Hit");
            player.GetComponent<Player>().GotHit();
        }
    }
}
