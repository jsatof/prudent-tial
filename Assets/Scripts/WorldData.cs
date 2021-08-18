using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {
	public bool isCollidable;
	public string name;
	public Vector3 pos;

	public Tile(bool isCollidable, string name, Vector3 pos) {
		this.isCollidable = isCollidable;
		this.name = name;
		this.pos = pos;
	}
}

public class WorldData : MonoBehaviour {
	private Tile[,] worldTiles;
	//private 


	void Start() {
	//	worldTiles = fillTiles();
		
	}

// If you need to go thrugh all the tiles,
// simply iterate through all the coordinates on the grid
// beginning from the tilemap.origin up to tilemap.origin + tilemap.size.

	private void fillTiles() {
		Tile[,] tiles = new Tile[20, 13];

		tiles[0, 0] = new Tile(false, "Grass", new Vector3(-1.5f, -1.5f, 0f));



	}

}

