using UnityEngine;
using System.Collections;

public class FindBadGuyGift : MonoBehaviour {

	RaycastHit hit;

	public GameObject[] explosionPrefabs = new GameObject[5];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * 1, Color.green);

		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward) * 1, out hit)) {
			if (hit.transform.gameObject.tag == ("Friend")) {
				if (Input.GetButton ("Fire1")) {
					OperationBoomBoom ();
				}
			} else if (hit.transform.gameObject.tag == ("BadGuy")) {
				if (Input.GetButton ("Fire1")) {
					transform.GetComponent<AudioSource> ().Play ();

				}
			}
		} else {
			
		}
	}

	void OperationBoomBoom(){
		foreach(GameObject explosion in explosionPrefabs){
			explosion.GetComponent<Detonator>().enabled = true;
		}

	}
}
