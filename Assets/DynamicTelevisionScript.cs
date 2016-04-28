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
    
    
    

	// Use this for initialization
	void Start () {
        //determine which movie to play
        //play that movie
        
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = f_rp_audio;
        
        
	
	}
	
	// Update is called once per frame
	void Update () {
        
        
        
        if (Input.GetButtonDown ("Jump")) {
            
            Renderer r = GetComponent<Renderer>();
            MovieTexture movie = (MovieTexture)r.material.mainTexture;
            AudioSource audio = GetComponent<AudioSource>();
            
            if (movie.isPlaying) {
                movie.Pause();
                audio.Pause();
                
            }
            else {
                movie.Play();
                audio.Play();
            }
        }
        
        
        //temporarily allow selection of film
       
        //play current film
        //pause current film
        //change to next film
        
        if (Input.GetButtonDown("Fire1")){
            Renderer r = GetComponent<Renderer>();
            AudioSource audio = GetComponent<AudioSource>();
            MovieTexture movie = (MovieTexture)r.material.mainTexture; 
            audio.Pause();
            movie.Pause();
            r.material.mainTexture = f_nrp;
            audio.clip = f_nrp_audio;
            movie.Play();
            audio.Play();
        }
        
	
	}
}
