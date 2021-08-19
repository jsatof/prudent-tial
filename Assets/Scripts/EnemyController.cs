using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public bool enemyTurn;
    public SpriteController player;
	private List<Vector3> movePoints;

    // Start is called before the first frame update
    void Start()
    {
        enemyTurn = false;
		movePoints = GetValidPositions();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTurn) {
			
			MoveToRandomTile(movePoints);
			movePoints = GetValidPositions();
			

            // handle decision tree here
            player.HandleTurnChange();
        }
    }

	private void MoveToRandomTile(List<Vector3> points) {
		var rand = new System.Random();
			
		List<float> distances = new List<float>();
		// get distance for every valid move point
		foreach(Vector3 pos in points) {
			float distance = (float) Math.Sqrt(Math.Pow(pos.x, 2f) - Math.Pow(pos.y, 2f));
			distances.Add(distance);
		}

		float minDistance = distances.Min();
		int minIndex = distances.IndexOf(minDistance);

		
		transform.position = points.ElementAt(minIndex);
		
		
	}


	private List<Vector3> GetValidPositions() {
		List<Vector3> points = new List<Vector3>();

		points.Add(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z));
		points.Add(new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z));
		points.Add(new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z));
		points.Add(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z));
		points.Add(new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z));
		points.Add(new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z));

		points.Add(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
		points.Add(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z));
		points.Add(new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z));
		points.Add(new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z));
		points.Add(new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z));
		points.Add(new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z));

		points.Add(new Vector3(transform.position.x + 1f, transform.position.y + 1f, transform.position.z));
		points.Add(new Vector3(transform.position.x + 2f, transform.position.y + 1f, transform.position.z));
		points.Add(new Vector3(transform.position.x + 3f, transform.position.y + 1f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 1f, transform.position.y + 1f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 2f, transform.position.y + 1f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 3f, transform.position.y + 1f, transform.position.z));

		points.Add(new Vector3(transform.position.x + 1f, transform.position.y + 2f, transform.position.z));
		points.Add(new Vector3(transform.position.x + 2f, transform.position.y + 2f, transform.position.z));
		points.Add(new Vector3(transform.position.x + 3f, transform.position.y + 2f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 1f, transform.position.y + 2f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 2f, transform.position.y + 2f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 3f, transform.position.y + 2f, transform.position.z));

		points.Add(new Vector3(transform.position.x + 1f, transform.position.y + 3f, transform.position.z));
		points.Add(new Vector3(transform.position.x + 2f, transform.position.y + 3f, transform.position.z));
		points.Add(new Vector3(transform.position.x + 3f, transform.position.y + 3f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 1f, transform.position.y + 3f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 2f, transform.position.y + 3f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 3f, transform.position.y + 3f, transform.position.z));

		points.Add(new Vector3(transform.position.x + 1f, transform.position.y - 1f, transform.position.z));
		points.Add(new Vector3(transform.position.x + 2f, transform.position.y - 1f, transform.position.z));
		points.Add(new Vector3(transform.position.x + 3f, transform.position.y - 1f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 1f, transform.position.y - 1f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 2f, transform.position.y - 1f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 3f, transform.position.y - 1f, transform.position.z));

		points.Add(new Vector3(transform.position.x + 1f, transform.position.y - 2f, transform.position.z));
		points.Add(new Vector3(transform.position.x + 2f, transform.position.y - 2f, transform.position.z));
		points.Add(new Vector3(transform.position.x + 3f, transform.position.y - 2f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 1f, transform.position.y - 2f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 2f, transform.position.y - 2f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 3f, transform.position.y - 2f, transform.position.z));

		points.Add(new Vector3(transform.position.x + 1f, transform.position.y - 3f, transform.position.z));
		points.Add(new Vector3(transform.position.x + 2f, transform.position.y - 3f, transform.position.z));
		points.Add(new Vector3(transform.position.x + 3f, transform.position.y - 3f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 1f, transform.position.y - 3f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 2f, transform.position.y - 3f, transform.position.z));
		points.Add(new Vector3(transform.position.x - 3f, transform.position.y - 3f, transform.position.z));

		return points;
	}

}
