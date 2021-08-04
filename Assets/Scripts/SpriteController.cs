using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {
	public float moveSpeed = 5f;
	public Transform movePoint;

    void Start() {
        movePoint.parent = null; // move movePoint Transform to root of hierarchy
    }

    void Update() {
		// MoveSpeed args: (current pos, target pos, speed)
		transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
		
		if (Vector3.Distance(transform.position, movePoint.position) <= -0.05f) {
        	if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
				movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f); // add horizontal input to x axis
	    	}
    
        	if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
				movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f); // add vertical input to y axis
	    	}
		}
	}
}
