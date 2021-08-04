using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    public Transform movePoint;


	void Start() {
    	transform.position = new Vector3(-1.5f, -1.5f, 0f);
		movePoint.parent = null;
    }

    void Update() {
    	if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
			Vector3 moveFactor = new Vector3(1.5f, 0f, 0f);
			Vector3 move = moveFactor * Input.GetAxisRaw("Horizontal");
			transform.position += move;
		}

	 
    	if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
			Vector3 moveFactor = new Vector3(0f, 1.5f, 0f);
			Vector3 move = moveFactor * Input.GetAxisRaw("Vertical");
			transform.position += move;
		}
    }
}
