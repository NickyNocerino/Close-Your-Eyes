using UnityEngine;
using System.Collections;

public class bottomblinkscript : MonoBehaviour {
    public GameObject top;
    public GameObject bottom;
    public Transform topinit;
    public Transform bottominit;
    public bool isclosed;
    public float speed;

    // Use this for initialization
    void Start () {
        //topinit =  top.transform;
        //bottominit = bottom.transform;
        isclosed = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.Space))
        {
            isclosed = true;
            float step = speed * Time.deltaTime;
            top.transform.position = Vector3.MoveTowards(top.transform.position, bottom.transform.position, step);
            bottom.transform.position = Vector3.MoveTowards(bottom.transform.position, top.transform.position, step);
        }
        else
        {
            isclosed = false;
            float step = speed * Time.deltaTime;
            top.transform.position = Vector3.MoveTowards(top.transform.position, topinit.position, step);
            bottom.transform.position = Vector3.MoveTowards(bottom.transform.position, bottominit.position, step);
        }
    }
}
