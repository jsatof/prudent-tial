using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickManager : MonoBehaviour {
	private GameObject cursor;
	private Tilemap tilemap;

	void Start() {
		cursor = GameObject.Find("Crosshair");
    }

    void Update() {
		Ray castPoint = Camera.main.ScreenPointToRay(cursor.transform.position);
		RaycastHit hit;
		if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))  {
		//	objectToMove.transform.position = hit.point;
        }
	//	Debug.Log(cursor.transform.position);
		//Vector3Int gPos = grid.WorldToCell(cursor.transform.position);
		//Debug.Log("name: " + tilemap.GetTile(gPos).name + "\nPosition: " + gPos);
    }

}
