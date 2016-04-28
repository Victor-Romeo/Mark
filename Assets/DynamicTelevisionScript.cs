using UnityEngine;
using System.Collections;

public class DynamicTelevisionScript : MonoBehaviour {

    public MovieTexture f_nrp;
    public MovieTexture f_rp;
    public MovieTexture s_rp;
    public MovieTexture s_nrp;

    public AudioClip f_nrp_audio;
    public AudioClip f_rp_audio;
    public AudioClip s_rp_audio;
    public AudioClip s_nrp_audio;

    public bool foundCorrectPerson = false;
    public bool didNotProfile = false;






	// Use this for initialization
	void Start () {
        //determine which movie to play
        MovieTexture chosenVideo = null;
        AudioClip    chosenAudio = s_nrp_audio;

        GameObject theInformation = GameObject.Find("InfoPasser");
        InfoPasser info = theInformation.GetComponent<InfoPasser>();
        foundCorrectPerson = info.foundCorrectPerson;
        didNotProfile = info.didNotProfile;

        if(didNotProfile && foundCorrectPerson){
          chosenVideo = s_nrp;
          chosenAudio = s_nrp_audio;
        }else if(didNotProfile && !foundCorrectPerson){

          chosenVideo = f_nrp;
          chosenAudio = f_nrp_audio;

        }else if(!didNotProfile && foundCorrectPerson){
          chosenVideo = s_rp;
          chosenAudio = s_rp_audio;
        }else if(!didNotProfile && !foundCorrectPerson){
          chosenVideo = f_rp;
          chosenAudio = f_rp_audio;

        }


        //play that movie

        AudioSource audio = GetComponent<AudioSource>();
        Renderer r = GetComponent<Renderer>();
        audio.clip = chosenAudio;
        MovieTexture movie = (MovieTexture)r.material.mainTexture;
        movie = chosenVideo;
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
        audio.Play();




	}

	// Update is called once per frame
	void Update () {

	}
}
