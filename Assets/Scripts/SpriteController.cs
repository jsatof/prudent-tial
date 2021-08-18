using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpriteController : MonoBehaviour {
	public float moveSpeed = 5f;
	public Transform movePoint;

	MouseInput mouseInput;
	private Vector3 destination;
	public Tilemap map;

	public bool playerTurn;
	public EnemyController currentEnemy;

	private void Awake() {
		mouseInput = new MouseInput();
	}

	private void OnEnable() {
		mouseInput.Enable();
	}

	private void OnDisable() {
		mouseInput.Disable();
	}

    void Start() {
        movePoint.parent = null; // move movePoint Transform to root of hierarchy
		mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
		destination = transform.position;
		playerTurn = true;
    }

	private void MouseClick() {
		if (playerTurn) {
			Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>();
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			
			Vector3Int gridPosition = map.WorldToCell(mousePosition);

			if (Vector3.Distance(transform.position, map.GetCellCenterWorld(gridPosition)) < 1.7) {
				if (map.HasTile(gridPosition)) {
					destination = map.GetCellCenterWorld(gridPosition);
				}
			}
		}
	}

    void Update() {
		// MoveSpeed args: (current pos, target pos, speed)
		/*transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
		
		if (Vector3.Distance(transform.position, movePoint.position) <= -0.05f) {
        	if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
				movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f); // add horizontal input to x axis
	    	}
    
        	if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
				movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f); // add vertical input to y axis
	    	}
		}*/
		if (Vector3.Distance(transform.position, destination) > 0.1f)
			transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
	}

	public void HandleTurnChange() {
		if (playerTurn) {
			playerTurn = false;
			currentEnemy.enemyTurn = true;
		} else {
			playerTurn = true;
			currentEnemy.enemyTurn = false;
		}
	}
}
