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
	public AudioClip startAudioClip;
	public AudioClip hurryUpAudioClip;
	public AudioClip finalChoiceAudioClip;
	public AudioSource audioSource;
	public int badGuyIndex;
	public float badGuyAudioLength;

	public GameObject coPresence;
	public Animator coPresenceAnimator;

	public int state;
	public bool startIsDone;
	public bool firstChoiceIsDone;
	public bool hurryUpIsDone;
	public bool secondChoiceIsDone;
	public bool finalAudioIsDone;

	// Use this for initialization
	void Start () {

		badGuyAudioLength = audios [2].length;

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

		state = -1;
		audioSource = coPresence.GetComponent<AudioSource> ();
		startIsDone = false;
		firstChoiceIsDone = false;
		hurryUpIsDone = false;
		secondChoiceIsDone = false;
		finalAudioIsDone = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!audioSource.isPlaying) {
			coPresenceAnimator.SetFloat("Blend",0f);
		} else {
			coPresenceAnimator.SetFloat("Blend",1f);
		}


		if(state == -1){
			if(Input.GetButton ("Fire1")){
				state++;
				audioSource.clip = startAudioClip;
				audioSource.Play ();
			}
		} else if(state == 0){
			if(!audioSource.isPlaying){
				startIsDone = true;
			}

			if(startIsDone){

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
						state++;
						audioSource.Play ();
						GameObject.Find ("InfoPasser").GetComponent<InfoPasser>().didNotProfile = true;
					}
				}
			}
		} else if(state == 1){
			if(!audioSource.isPlaying){
				firstChoiceIsDone = true;
			}

			if(firstChoiceIsDone){
				state++;
				audioSource.clip = hurryUpAudioClip;
				audioSource.Play ();
			}
		}  else if(state == 2){
			if(!audioSource.isPlaying){
				hurryUpIsDone = true;
			}

			if(hurryUpIsDone){

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
						state++;
						audioSource.Play ();
						GameObject.Find ("InfoPasser").GetComponent<InfoPasser>().didNotProfile = true;
					}
				}
			}
		} else if(state == 3){
			if(!audioSource.isPlaying){
				secondChoiceIsDone = true;
			}

			if(secondChoiceIsDone){
				state++;
				audioSource.clip = finalChoiceAudioClip;
				audioSource.Play ();
			}
		} else if(state == 4){
			if(!audioSource.isPlaying){
				finalAudioIsDone = true;
			}

			if(finalAudioIsDone){

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
						//maybe play audio source
						Application.LoadLevel(1); 
					}
				}
			}
		} 

		//Stare at folders
		Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * 100000, Color.green);

		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward) * 100000, out hit)) {
			if (hit.transform.gameObject.tag == ("Folder")) {
				if (hit.transform.gameObject.name == "OrangeCollider") {

					if(!audioSource.isPlaying){
						audioSource.clip = audios [2];
					}

					orangeFolder = true;
					yellowFolder = false;
					purpleFolder = false;
					orangeAnimator.SetBool ("Animate", true);
					purpleAnimator.SetBool ("Animate", false);
					yellowAnimator.SetBool ("Animate", false);
				} else if (hit.transform.gameObject.name == "YellowCollider") {

					if (!audioSource.isPlaying) {
						audioSource.clip = audios [1];
					}

					yellowFolder = true;
					orangeFolder = false;
					purpleFolder = false;
					yellowAnimator.SetBool ("Animate", true);
					purpleAnimator.SetBool ("Animate", false);
					orangeAnimator.SetBool ("Animate", false);
				} else if (hit.transform.gameObject.name == "PurpleCollider") {

					if (!audioSource.isPlaying) {
						audioSource.clip = audios [0];
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
	}
}
