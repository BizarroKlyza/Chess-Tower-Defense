using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	/*public enum Pieces {
		None,
		Pawn,
		Bishop,
		Knight,
		Rook,
		Queen
	}*/

	int layerMask = 1 << 2;

	[Header("Pieces")]
	public GameObject[] pieces;
	int pieceIndex = 0;

	[Header("Enemies")]
	public GameObject[] enemies;
	int enemyIndex = 0;

	[Header("Holograms")]
	GameObject[] holograms;

	GameObject clone;

	void SpawnEnemy() {
		Instantiate(enemies[enemyIndex], new Vector3(7f, 1f, Mathf.Round(Random.Range(0f, 5f))), Quaternion.identity);
	}

	void Start() {
		for (int i = 0; i < pieces.Length; i++) {
			//holograms[i] = Instantiate(towers[i], new Vector3(0f, 50f, 0f), Quaternion.identity);
			//holograms[i].GetComponent<MeshRenderer>().material = hologramMaterial;
		}
		InvokeRepeating("SpawnEnemy", 1f, 3f);
	}

	void Update() {
		if (clone) {
			Destroy(clone);
			clone = null;
		}
	}

	void LateUpdate() {
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, layerMask)) {
			Placeable p = hit.transform.GetComponent<Placeable>();
			if (p) {
				if (Input.GetMouseButtonDown(0)) {
					Instantiate(pieces[pieceIndex], hit.transform.position + Vector3.up, Quaternion.identity);
					Destroy(p);
				} else {
					clone = Instantiate(pieces[pieceIndex], hit.transform.position + Vector3.up, Quaternion.identity);
					//clone.GetComponent<Renderer>().material.color = Color.black;
				}
			}
		}
	}

}
