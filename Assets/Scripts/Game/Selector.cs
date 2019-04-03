using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Selector : MonoBehaviour {

	int layerMask = 1 << 2;
	int index = 1;
	float timer = 0f;

	[Header("Pieces")]
	public GameObject[] pieces;

	[Header("Holograms")]
	public GameObject[] holograms;

	public Transform piecesParent;

	void Update() {

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			index = (index + pieces.Length - 1) % pieces.Length;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			index = (index + 1) % pieces.Length;
		}

		// Disable all holograms
		foreach (var h in holograms) {
			h.SetActive(false);
		}

		// Cast a ray from the camera
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(mouseRay, out hit, 250f, layerMask)) {
			Placeable p = hit.transform.GetComponent<Placeable>();
			if (p && p.enabled) {
				if (Input.GetMouseButtonDown(0)) {
					Instantiate(pieces[index], hit.transform.position, Quaternion.identity, hit.transform);
					p.enabled = false;
				} else {
					holograms[index].SetActive(true);
					holograms[index].transform.position = p.transform.position;
				}
			}
		}
	}
}
