using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            GameMaster.GM.FinishGame();
        }
    }
}
