using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class FindBadGuyGift : MonoBehaviour {

	RaycastHit hit;

	public GameObject[] explosionPrefabs = new GameObject[5];

    public List<AudioClip> audioList;

    AudioSource aSource;

    bool findCorrectPerson;
    bool didNotDiscriminate;

	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
        var passer = GameObject.Find("InfoPasser").GetComponent<InfoPasser>();
        if (!passer)
        {
            findCorrectPerson = passer.foundCorrectPerson;
            didNotDiscriminate = passer.didNotProfile;
            if (findCorrectPerson)
            {
                if (didNotDiscriminate)
                {
                    aSource.clip = audioList[0];
                }
                else
                {
                    aSource.clip = audioList[1];
                }
            }
            else
            {
                if (didNotDiscriminate)
                {
                    aSource.clip = audioList[2];
                }
                else
                {
                    aSource.clip = audioList[3];
                }
            }
            aSource.Play();
        }
	}

    float dTime = float.MaxValue;

	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * 1, Color.green);

		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward) * 1, out hit)) {
			if (hit.transform.gameObject.tag == ("Friend")) {
				if (Input.GetButton ("Fire1")) {
					OperationBoomBoom ();
                    dTime = Time.time + 3.0f;
				}
			} else if (hit.transform.gameObject.tag == ("BadGuy")) {
				if (Input.GetButton ("Fire1")) {
                    aSource.clip = audioList[4];
					transform.GetComponent<AudioSource> ().Play ();
                    aSource.Play();
                    dTime = Time.time + 5.0f;
                }
            }
		} else {
			
		}
        if(Time.time > dTime)
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }

    void OperationBoomBoom(){
		foreach(GameObject explosion in explosionPrefabs){
			explosion.GetComponent<Detonator>().enabled = true;
		}
	}
}
