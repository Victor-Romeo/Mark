using UnityEngine;
using System.Collections;

public class fade : MonoBehaviour {
    
     Color colorStart;
     Color colorEnd;
     float duration = 5.0f;
 
     // Use this for initialization
     void Start () {
     
         colorStart =  GetComponentInChildren<SkinnedMeshRenderer>().material.color;
         colorEnd = new Color(colorStart.r, colorStart.g, colorStart.b, 0.0f);
         FadeOut();
 
     }
     
     public void FadeOut ()
     {
         float t;    
         float alpha = GetComponentInChildren<SkinnedMeshRenderer>().material.color.a;
         
         for (t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
         {
             Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,0,t));
             GetComponentInChildren<SkinnedMeshRenderer>().material.color = newColor;
         }
         
     }
    
}