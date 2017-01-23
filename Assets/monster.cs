using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class monster : MonoBehaviour {
    public bottomblinkscript vischeck;
    public Transform player;
    private Renderer rend;
    public RaycastHit hit;
    public float speed;
    public bool seen;
    public node initnode;
    public node curnode;
    public node nextnode;
    public AudioClip ambient;
    public AudioClip active;
    public AudioSource aud;
    // Use this for initialization
    void Start () {
        rend = transform.GetChild(8).GetComponent<Renderer>();
        seen = false;
        curnode = initnode;
        nextnode = initnode;
        transform.position = initnode.transform.position;
        aud = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(rend.isVisible==true&&vischeck.isclosed==false)
        {
            if (Physics.Raycast(transform.position, player.position - transform.position,out hit))
            {
                if(hit.transform==player)
                {
                    print("die");
                    seen = true;
                    aud.clip = active;
                    if (!aud.isPlaying)
                    {
                        aud.Play();
                    }
                    aud.volume += .001f;
                }
                else
                {
                    print("live");
                    seen = false;
                    aud.clip = ambient;
                    if (!aud.isPlaying)
                    {
                        aud.Play();
                    }
                    aud.loop = true;
                    aud.volume = .1f/Vector3.Distance(player.position, transform.position) * 11;
                }
            }
            else
            {
                print("live");
                seen = false;
                aud.clip = ambient;
                if (!aud.isPlaying)
                {
                    aud.Play();
                }
                aud.loop = true;
                aud.volume = .1f / Vector3.Distance(player.position, transform.position)*11;
            }
                
        }
        else
        {
            print("live");
            seen = false;
            aud.clip = ambient;
            if(!aud.isPlaying)
            {
                aud.Play();
            }
            aud.loop = true;
            aud.volume = .1f / Vector3.Distance(player.position, transform.position) * 11;
        }
        if(transform.position==nextnode.transform.position)
        {
            StartCoroutine(findNextNode());
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextnode.transform.position, speed*Time.deltaTime);
        }
	
	}
    IEnumerator findNextNode()
    {
        curnode = nextnode;
        yield return new WaitForSeconds(3);
        int rand = Random.Range(1, 4);
        if (rand == 1)
        {
            nextnode = curnode.node1;
        }
        else if (rand == 2)
        {
            nextnode = curnode.node2;
        }
        else
        {
            nextnode = curnode.node3;
        }
    }
    
}