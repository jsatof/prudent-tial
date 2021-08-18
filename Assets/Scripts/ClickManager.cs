using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickManager : MonoBehaviour {
	private GameObject cursor;
	private GameObject protag;
	private GameObject enemy1;
	private List<GameObject> sprites;

	public GameObject selected;

	void Start() {
		cursor = GameObject.Find("Crosshair");
		selected = null;

		protag = GameObject.Find("ProtagSprite");
		sprites.Add(protag);

		enemy1 = GameObject.Find("EnemySprite");
		sprites.Add(enemy1);
    }

    void Update() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			GameObject match = checkCursorAndSpritePos();
			if(match) {
				selected = match;
			}
		}

    }
	

	private GameObject checkCursorAndSpritePos() {
		foreach(GameObject sprite in sprites) {
			if(sprite.transform.position == cursor.transform.position) {
				return sprite;
			}
		}
		return null;
	}
}
