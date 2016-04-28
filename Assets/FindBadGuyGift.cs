using UnityEngine;
using System.Collections;

public class FindBadGuyGift : MonoBehaviour {

	RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * 1, Color.green);

		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward) * 1, out hit)) {
			if (hit.transform.gameObject.tag == ("Friend")) {
				if (Input.GetButton ("Fire1")) {
					//Call explosion
				}
			} else if (hit.transform.gameObject.tag == ("BadGuys")) {
				if (Input.GetButton ("Fire1")) {
					//Call success
				}
			}
		} else {
			
		}
	}
}
