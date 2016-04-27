using UnityEngine;
using System.Collections;

public class LookAtFolders : MonoBehaviour {

	RaycastHit hit;

	public bool orangeFolder;
	public bool yellowFolder;
	public bool purpleFolder;

	public Animator orangeAnimator;
	public Animator yellowAnimator;
	public Animator purpleAnimator;

	public AudioClip[] audios;
	public int badGuyIndex;
	public float badGuyAudioLength;

	// Use this for initialization
	void Start () {

		badGuyAudioLength = audios [1].length;

		for (int t = 0; t < audios.Length; t++ )
		{
			AudioClip tmp = audios[t];
			int r = Random.Range(t, audios.Length);
			audios[t] = audios[r];
			audios[r] = tmp;
		}

		for (int i = 0; i < audios.Length; i++ )
		{
			if(badGuyAudioLength == audios [i].length){
				badGuyIndex = i;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		//Stare at folders
		Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * 100000, Color.green);

		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward) * 100000, out hit)) {
			if (hit.transform.gameObject.tag == ("Folder")) {
				if (hit.transform.gameObject.name == "OrangeCollider") {

					if(transform.GetComponent<AudioSource> ().isPlaying){
						transform.GetComponent<AudioSource> ().clip = audios [2];
					}

					orangeFolder = true;
					yellowFolder = false;
					purpleFolder = false;
					orangeAnimator.SetBool ("Animate", true);
					purpleAnimator.SetBool ("Animate", false);
					yellowAnimator.SetBool ("Animate", false);
				} else if (hit.transform.gameObject.name == "YellowCollider") {

					if (transform.GetComponent<AudioSource> ().isPlaying) {
						transform.GetComponent<AudioSource> ().clip = audios [1];
					}

					yellowFolder = true;
					orangeFolder = false;
					purpleFolder = false;
					yellowAnimator.SetBool ("Animate", true);
					purpleAnimator.SetBool ("Animate", false);
					orangeAnimator.SetBool ("Animate", false);
				} else if (hit.transform.gameObject.name == "PurpleCollider") {

					if (transform.GetComponent<AudioSource> ().isPlaying) {
						transform.GetComponent<AudioSource> ().clip = audios [0];
					}

					purpleFolder = true;
					orangeFolder = false;
					yellowFolder = false;
					purpleAnimator.SetBool ("Animate", true);
					yellowAnimator.SetBool ("Animate", false);
					orangeAnimator.SetBool ("Animate", false);
				} 
				Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * 100000, Color.red);
			} else {
				orangeFolder = false;
				yellowFolder = false;
				purpleFolder = false;
				purpleAnimator.SetBool ("Animate", false);
				yellowAnimator.SetBool ("Animate", false);
				orangeAnimator.SetBool ("Animate", false);
			}
		} else {
			orangeFolder = false;
			yellowFolder = false;
			purpleFolder = false;
			purpleAnimator.SetBool ("Animate", false);
			yellowAnimator.SetBool ("Animate", false);
			orangeAnimator.SetBool ("Animate", false);
		}


		if (Input.GetButton ("Fire1")) {
			if (orangeFolder) {
				if (badGuyIndex == 2) {
					GameObject.Find ("InfoPasser").GetComponent<InfoPasser>().foundCorrectPerson = true;
				} else {
					GameObject.Find ("InfoPasser").GetComponent<InfoPasser>().foundCorrectPerson = false;
				}
				Application.LoadLevel(1);
			} else if (yellowFolder){
				if (badGuyIndex == 1) {
					GameObject.Find ("InfoPasser").GetComponent<InfoPasser>().foundCorrectPerson = true;
				} else {
					GameObject.Find ("InfoPasser").GetComponent<InfoPasser>().foundCorrectPerson = false;
				}
				Application.LoadLevel(1);
			} else if (purpleFolder){
				if (badGuyIndex == 0) {
					GameObject.Find ("InfoPasser").GetComponent<InfoPasser>().foundCorrectPerson = true;
				} else {
					GameObject.Find ("InfoPasser").GetComponent<InfoPasser>().foundCorrectPerson = false;
				}
				Application.LoadLevel(1);
			}
		}

		if (Input.GetButton ("Fire2")) {
			if(orangeFolder || yellowFolder || purpleFolder){
				transform.GetComponent<AudioSource> ().Play ();
				GameObject.Find ("InfoPasser").GetComponent<InfoPasser>().didNotProfile = true;
			}
		}

	}
}
