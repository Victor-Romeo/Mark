using UnityEngine;
using System.Collections;

public class LookAtFolders : MonoBehaviour {

	RaycastHit hit;

	public bool orangeFolder;
	public bool yellowFolder;
	public bool purpleFolder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		//Stare at folders
		Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * 100000, Color.green);

		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward) * 100000, out hit)) {
			if (hit.transform.gameObject.tag == ("Folder")) {
				if (hit.transform.gameObject.name == "OrangeCollider") {
					orangeFolder = true;
					yellowFolder = false;
					purpleFolder = false;
				} else if (hit.transform.gameObject.name == "YellowCollider") {
					yellowFolder = true;
					orangeFolder = false;
					purpleFolder = false;
				} else if (hit.transform.gameObject.name == "PurpleCollider") {
					purpleFolder = true;
					orangeFolder = false;
					yellowFolder = false;
				} 
				Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * 100000, Color.red);
			} else {
				orangeFolder = false;
				yellowFolder = false;
				purpleFolder = false;
			}
		} else {
			orangeFolder = false;
			yellowFolder = false;
			purpleFolder = false;
		}
	}
}
