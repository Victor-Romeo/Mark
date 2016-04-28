using UnityEngine;
using System.Collections;

public class fade : MonoBehaviour {
    
    

	// Use this for initialization
	void Start () {
        
    
	}
	
	// Update is called once per frame
	void Update () {
        
        Color color = GetComponent<Renderer>().material.color;
        color.a -= 0.1f;
        GetComponent<Renderer>().material.color = color;
        if(color.a <= 0){
            
            Destroy(gameObject);
        }

    }
}
