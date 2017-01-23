using UnityEngine;
using System.Collections;

public class node : MonoBehaviour {
    public node node1;
    public node node2;
    public node node3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(node2==null&&node3==null)
        {
            node2 = node1;
            node3 = node1;
        }
        else if(node3==null)
        {
            node3 = node2;
        }
	}
}
