using UnityEngine;
using System.Collections;

public class key : MonoBehaviour {
    
    public bool found;
    public AudioSource aud;
	// Use this for initialization
	void Start () {
        found = false;
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay(Collider col)
    {
        
           if(Input.GetMouseButtonDown(0))
           {
               found = true;
               transform.GetChild(6).GetComponent<Renderer>().enabled = false;
               aud.Play();
           }
        
    }
}
