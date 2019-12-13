using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject hitParticle;

    PathFollow pathFollower;
    Rigidbody myRigidbody;


    void Awake()
    {
        pathFollower = this.GetComponent<PathFollow>();
        myRigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameMaster.GM.gameState == GameState.StPlaying)
        {
            if (Input.GetMouseButton(0))
                pathFollower.RunPath();
        }
        else if(GameMaster.GM.gameState == GameState.StHit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pathFollower.RestartPath();

            }
        }
    }

    public void GotHit()
    {
        GameMaster.GM.gameState = GameState.StHit;

        GameObject particle = Instantiate(hitParticle, this.transform.position, Quaternion.identity);
        Destroy(particle, 2f);
    }
}
