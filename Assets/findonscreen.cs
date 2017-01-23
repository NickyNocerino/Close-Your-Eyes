using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class findonscreen : MonoBehaviour {
    public Transform target;
    public monster enemy;
    Camera camera;
   private Renderer rend;
    public RaycastHit hit;
    public Twirl twirl;
    private Fisheye fish;
    private NoiseAndScratches noise;
   
    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
        rend = GetComponent<Renderer>();
        twirl = GetComponent<Twirl>();
        twirl.enabled = false;
        fish = GetComponent<Fisheye>();
        noise = GetComponent<NoiseAndScratches>();
        
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 screenPos = camera.WorldToScreenPoint(target.position);
        Debug.Log("target is " + screenPos.x /Screen.width+ " pixels from the left");
        if (enemy.seen==true)
        {
            twirl.enabled = true;
            
            twirl.center.x = screenPos.x / Screen.width;
            twirl.center.y = screenPos.y / Screen.height;
            twirl.angle += .08f;
            fish.strengthX += .002f;
            fish.strengthY += .002f;
            noise.grainIntensityMax += .002f;
            StartCoroutine(waitForDeath());

        }
        else
        {
            
            twirl.enabled = false;
            twirl.angle = 18;
            if(fish.strengthX>0&& fish.strengthY > 0)
            {
                fish.strengthX -= 0.001f;
                fish.strengthY -= 0.001f;
            }
           if(noise.grainIntensityMax>.1)
            {
                noise.grainIntensityMax -= .002f;
            }
            
        }

    }
    IEnumerator waitForDeath()
    {
        yield return new WaitForSeconds(2f);
        if(enemy.seen)
        {
            print("you are dead motherfucker");
           transform.parent.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
            transform.parent.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
            transform.parent.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
            yield return new WaitForSeconds(2.5f);
            Application.LoadLevel(1);
        }
    }

}
