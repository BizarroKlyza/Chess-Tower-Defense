using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Selector : MonoBehaviour {

	int layerMask = 1 << 2;
	int index = 0;

	[Header("Pieces")]
	public GameObject[] pieces;

	[Header("Holograms")]
	public GameObject[] holograms;

    int[] originalUnused = { 2, 2, 2, 2, 2 };
    int[] unused = { 2, 2, 2, 2, 2 };
    Vector3 unusedPos;

    // List in use. Not actually an unused list
    List<GameObject> unusedList = new List<GameObject>();

    void UpdateUnused() {

        foreach (GameObject piece in unusedList)
        {
            Destroy(piece);
        }

        unusedList.Clear();

        unusedPos = new Vector3(7f, -1f, -2f);
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < originalUnused[i]; j++)
            {
                if (j < unused[i]) {
                    unusedList.Add(Instantiate(pieces[i], unusedPos, Quaternion.identity));

                }

                if (unusedPos.x == 0)
                {
                    unusedPos.x = 7;
                    unusedPos.z -= 1;
                }
                else
                {
                    unusedPos.x -= 1;
                }
            }
        }
    }

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
                    unused[index] -= 1;
                    UpdateUnused();
				} else {
					holograms[index].SetActive(true);
					holograms[index].transform.position = p.transform.position;
				}
			}
		}
	}
}
