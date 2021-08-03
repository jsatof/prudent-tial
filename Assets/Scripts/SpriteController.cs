using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Transform movePoint;

    void Start()
    {
        movePoint.parent = null; // move movePoint Transform to root of hierarchy
    }

    void Update()
    {
		// MoveSpeed args: (current pos, target pos, speed)
		this.transform.position = Vector3.MoveTowards(this.transform.position, this.movePoint.position, this.moveSpeed * Time.deltaTime);

        if(Mathf.Abs(Input.GetAxis("Horizontal")) == 1f) 
	    {
			movePoint.position = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f); // add horizontal input to x axis
	    }
    
        if(Mathf.Abs(Input.GetAxis("Vertical")) == 1f) 
	    {
			movePoint.position = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f); // add vertical input to y axis
	    }
	}
}
