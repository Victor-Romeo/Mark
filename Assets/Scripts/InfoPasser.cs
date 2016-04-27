using UnityEngine;
using System.Collections;

public class InfoPasser : MonoBehaviour {

	public bool didNotProfile;
	public bool foundCorrectPerson;

	// Use this for initialization
	void Start () {
		didNotProfile = false;
		foundCorrectPerson = false;

		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
