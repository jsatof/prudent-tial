using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class SpriteController : MonoBehaviour {
	public float moveSpeed = 5f;
	public Crosshair crosshair;

	private Vector3 destination;
	public Tilemap map;

	public bool playerTurn;
	public EnemyController currentEnemy;

	public TextMeshProUGUI textMesh;

	private GameObject[] blueSquares;
	private GameObject[] redSquares;

	public GameObject menu;

	public bool MenuIsOpen = false;
	private bool HasMovedThisTurn;

    void Start() {
		destination = transform.position;
		playerTurn = true;
		HasMovedThisTurn = false;

		blueSquares = GameObject.FindGameObjectsWithTag("BlueSquare");
		foreach (GameObject s in blueSquares) {
			s.SetActive(false);
		}

		redSquares = GameObject.FindGameObjectsWithTag("RedSquare");
		foreach (GameObject s in redSquares) {
			s.SetActive(false);
		}
    }

    void Update() {
		if (Input.GetKeyDown("space")) {
			if (playerTurn) {
				if (GetGridPositionFromCrosshair().z != 1000f) {
					if (!MenuIsOpen) {
						OpenMenu();
						ShowSquares();
					} 
				}
			}
		}
	}

	public void OpenMenu() {
		MenuIsOpen = true;

		menu.SetActive(true);
	}

	public void CloseMenu() {
		MenuIsOpen = false;
		menu.SetActive(false);
	}

	private Vector3 GetGridPositionFromCrosshair() {
		Vector2 chPosition = Camera.main.WorldToScreenPoint(crosshair.GetPosition());
		chPosition = Camera.main.ScreenToWorldPoint(chPosition);

		Vector3Int gridPosition = map.WorldToCell(chPosition);

		if (map.HasTile(gridPosition)) {
			return map.GetCellCenterWorld(gridPosition);
		}

		return new Vector3(0f, 0f, 1000f);
	}

	public void MovePlayerToCrosshair() {
		if (!HasMovedThisTurn) {
			destination = GetGridPositionFromCrosshair();

			if (Vector3.Distance(transform.position, destination) < 4.5 && Vector3.Distance(transform.position, destination) != 4)
				if (Vector3.Distance(transform.position, destination) > 0.1f) {
					while (transform.position != destination)
						transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

					HasMovedThisTurn = true;
				}
		}
	}

	public void HandleTurnChange() {
		if (playerTurn) {
			CloseMenu();
			HideSquares();
			playerTurn = false;
			currentEnemy.enemyTurn = true;
			textMesh.SetText("ENEMY TURN");
		} else {
			playerTurn = true;
			HasMovedThisTurn = false;
			currentEnemy.enemyTurn = false;
			textMesh.SetText("PLAYER TURN");
		}
	}

	private void HideSquares() {
		foreach (GameObject s in blueSquares) {
			s.SetActive(false);
		}
		foreach (GameObject s in redSquares) {
			s.SetActive(false);
		}
	}

	private void ShowSquares() {

		float[] values = new float[] {3f, 2f, 1f, 0f};
		int currentSquare = 0;

		// first column

		for (int i = 0; i < 4; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.left * 3f;
			square.transform.position += Vector3.up * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		for (int i = 0; i < 3; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.left * 3f;
			square.transform.position += Vector3.down * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		// second column

		for (int i = 0; i < 4; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.left * 2f;
			square.transform.position += Vector3.up * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		for (int i = 0; i < 3; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.left * 2f;
			square.transform.position += Vector3.down * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		// third column

		for (int i = 0; i < 4; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.left * 1f;
			square.transform.position += Vector3.up * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		for (int i = 0; i < 3; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.left * 1f;
			square.transform.position += Vector3.down * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		// middle column

		for (int i = 0; i < 3; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.up * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		for (int i = 0; i < 3; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.down * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		// fifth column

		for (int i = 0; i < 4; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.right * 1f;
			square.transform.position += Vector3.up * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		for (int i = 0; i < 3; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.right * 1f;
			square.transform.position += Vector3.down * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		// sixth column
		for (int i = 0; i < 4; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.right * 2f;
			square.transform.position += Vector3.up * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		for (int i = 0; i < 3; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.right * 2f;
			square.transform.position += Vector3.down * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		// seventh column
		for (int i = 0; i < 4; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.right * 3f;
			square.transform.position += Vector3.up * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		for (int i = 0; i < 3; i++) {
			GameObject square = blueSquares[currentSquare];
			square.transform.position = transform.position;
			square.transform.position += Vector3.right * 3f;
			square.transform.position += Vector3.down * values[i];

			square.SetActive(true);
			currentSquare++;
		}
		
		// red squares

		currentSquare = 0;

		// top row
		for (int i = 0; i < 4; i++) {
			GameObject square = redSquares[currentSquare];

			square.transform.position = transform.position;
			square.transform.position += Vector3.up * 4f;
			square.transform.position += Vector3.left * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		for (int i = 0; i < 3; i++) {
			GameObject square = redSquares[currentSquare];

			square.transform.position = transform.position;
			square.transform.position += Vector3.up * 4f;
			square.transform.position += Vector3.right * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		// left column

		for (int i = 0; i < 4; i++) {
			GameObject square = redSquares[currentSquare];

			square.transform.position = transform.position;
			square.transform.position += Vector3.left * 4f;
			square.transform.position += Vector3.up * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		for (int i = 0; i < 3; i++) {
			GameObject square = redSquares[currentSquare];

			square.transform.position = transform.position;
			square.transform.position += Vector3.left * 4f;
			square.transform.position += Vector3.down * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		// bottom row

		for (int i = 0; i < 4; i++) {
			GameObject square = redSquares[currentSquare];

			square.transform.position = transform.position;
			square.transform.position += Vector3.down * 4f;
			square.transform.position += Vector3.left * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		for (int i = 0; i < 3; i++) {
			GameObject square = redSquares[currentSquare];

			square.transform.position = transform.position;
			square.transform.position += Vector3.down * 4f;
			square.transform.position += Vector3.right * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		// right column

		for (int i = 0; i < 4; i++) {
			GameObject square = redSquares[currentSquare];

			square.transform.position = transform.position;
			square.transform.position += Vector3.right * 4f;
			square.transform.position += Vector3.up * values[i];

			square.SetActive(true);
			currentSquare++;
		}

		for (int i = 0; i < 3; i++) {
			GameObject square = redSquares[currentSquare];

			square.transform.position = transform.position;
			square.transform.position += Vector3.right * 4f;
			square.transform.position += Vector3.down * values[i];

			square.SetActive(true);
			currentSquare++;
		}

	}
}