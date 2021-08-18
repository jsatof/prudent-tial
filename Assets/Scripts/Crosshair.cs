using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Crosshair : MonoBehaviour {
    public Transform movePoint;
	public float moveSpeed = 4f;
	public Tile hoveredTile;

	void Start() {
    	transform.position = new Vector3(-1.5f, -1.5f, 0f);
		movePoint.parent = null;
    }

    void Update() {
    	transform.position = Vector3.MoveTowards(transform.position, movePoint.position, Time.deltaTime * moveSpeed);
		
		// Check Arrow Keys: Moves cursor
		if(Vector3.Distance(transform.position, movePoint.position) == 0f) {  // would call IsInMapBounds() here
			MoveLeftRight();
			MoveUpDown();
	 
		}

    }

	private void MoveLeftRight() {
		if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f && Mathf.Abs(Input.GetAxisRaw("Vertical")) != 1f) { // disables diagonal movement
			Vector3 moveFactor = new Vector3(1f, 0f, 0f);
			Vector3 move = moveFactor * Input.GetAxisRaw("Horizontal");
			movePoint.position += move;
		}
	}

	private void MoveUpDown() {
    	if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f && Mathf.Abs(Input.GetAxisRaw("Horizontal")) != 1f) {
			Vector3 moveFactor = new Vector3(0f, 1f, 0f);
			Vector3 move = moveFactor * Input.GetAxisRaw("Vertical");
			movePoint.position += move;
		}
	}

	// BUG: cursor would advance one space over bounds, then be locked in place
	private bool IsInMapBounds() {
		if(movePoint.position.x >= -11.5 && movePoint.position.x <= 11.5) {
			if(movePoint.position.y >= -6.5 && movePoint.position.y <= 4.5) {
				return true;
			}
		}
		return false;
	}
}
