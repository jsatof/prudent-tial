using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public bool enemyTurn;
    public SpriteController player;

    // Start is called before the first frame update
    void Start()
    {
        enemyTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTurn == true) {

            // handle decision tree here
            player.HandleTurnChange();
        }
    }
}