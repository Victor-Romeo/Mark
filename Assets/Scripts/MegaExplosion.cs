using UnityEngine;
using System.Collections;

public class MegaExplosion : MonoBehaviour {

	public GameObject[] explosionPrefabs = new GameObject[5];

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OperationBoomBoom(){
		foreach(GameObject explosion in explosionPrefabs){
			explosion.GetComponent<Detonator>().enabled = true;
		}

	}
}
