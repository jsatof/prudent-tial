using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    public Transform movePoint;
	public float moveSpeed = 4f;

	void Start() {
    	transform.position = new Vector3(-1.5f, -1.5f, 0f);
		movePoint.parent = null;
    }

    void Update() {
    	transform.position = Vector3.MoveTowards(transform.position, movePoint.position, Time.deltaTime * moveSpeed);

		if(Vector3.Distance(transform.position, movePoint.position) <= 0.5f) {

			if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
				Vector3 moveFactor = new Vector3(1f, 0f, 0f);
				Vector3 move = moveFactor * Input.GetAxisRaw("Horizontal");
				movePoint.position += move;
			}

	 
    		if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
				Vector3 moveFactor = new Vector3(0f, 1f, 0f);
				Vector3 move = moveFactor * Input.GetAxisRaw("Vertical");
				movePoint.position += move;
			}
		}
    }
}
