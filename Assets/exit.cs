using UnityEngine;
using System.Collections;

public class exit : MonoBehaviour {
    public monster triple;
    public key key1;
    public key key2;
    public key key3;
    public node gaurd;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(key1.found&&key2.found&&key3.found)
        {
            triple.nextnode = gaurd;
            triple.speed = 6;
            Destroy(gameObject);
        }
	}
}
