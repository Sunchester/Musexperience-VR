using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Valve.VR;

public class PickupFinale: MonoBehaviour
{
    public SteamVR_Action_Boolean pickup;
    public SteamVR_Input_Sources handTypeL;
    public SteamVR_Input_Sources handTypeR;
    public SteamVR_Behaviour_Pose controllerPoseL;
    public SteamVR_Behaviour_Pose controllerPoseR;
    public GameObject Song;
    public GameObject all;
    public GameObject planetEarth;
    public GameObject planetNext;
    public GameObject hg;
    public GameObject disc;

    public int skyType = 0;
    int count = 0;
    public static int triggerType = 0;
    public static bool change = false;
    bool ishold = false;
    Vector3 nextStartpos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        nextStartpos = planetNext.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
        if (distance > 5.5f)
        {
            ishold = false;
        }
        else if (distance <= 5.5f)
        {
            ishold = true;
        }

        if (pickup.GetStateDown(handTypeR) && ishold)
        {
            triggerType = skyType;
            Song.GetComponent<AudioSource>().Play();
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.SetParent(controllerPoseR.transform);
            this.GetComponent<Rigidbody>().freezeRotation = true;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            change = true;

            all.SetActive(false);
            planetEarth.SetActive(false);
            planetNext.SetActive(false);
            hg.SetActive(false);
            disc.SetActive(false);

        }
        else if (pickup.GetStateUp(handTypeR))
        {
            Song.GetComponent<AudioSource>().Pause();
            

            this.transform.SetParent(null);
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<BoxCollider>().enabled = true;
            this.GetComponent<Rigidbody>().freezeRotation = false;
            change = false;
            all.SetActive(true);
            hg.SetActive(true);
            disc.SetActive(true);
        }
        if (Song.GetComponent<AudioSource>().time >= 31.6f)
            triggerType = 3;
        if (Song.GetComponent<AudioSource>().time >= 61.89f)
            triggerType = 4;
        if (Song.GetComponent<AudioSource>().time >= 92.0f)
        {
            triggerType = 9;
            planetEarth.SetActive(true);
            planetNext.SetActive(true);

        }
        if (Song.GetComponent<AudioSource>().time >= 157.0f && Song.GetComponent<AudioSource>().time <= 193)
        {
            planetEarth.SetActive(false);
            planetNext.SetActive(false);
            count += 1;
            if (count <= 6)
            {
                triggerType = 5;
            }
            else if (count <= 12)
            {
                triggerType = 7;
            }
            else if (count <= 18)
            {
                triggerType = 8;
                count = 0;
            }
        }
        if (Song.GetComponent<AudioSource>().time >= 193)
        {
            triggerType = 4;
            planetEarth.SetActive(false);
            planetNext.SetActive(false);
        }
        if (Song.GetComponent<AudioSource>().time >= 196.0 && Song.GetComponent<AudioSource>().time < 197.0)
        {
            triggerType = 5;
        }
        if (Song.GetComponent<AudioSource>().time >= 197.0 && Song.GetComponent<AudioSource>().time < 199.0)
        {
            triggerType = 4;
        }
        if (Song.GetComponent<AudioSource>().time >= 198.15 && Song.GetComponent<AudioSource>().time < 198.90)
        {
            triggerType = 7;
        }
        if (Song.GetComponent<AudioSource>().time >= 198.90 && Song.GetComponent<AudioSource>().time < 200.4)
        {
            triggerType = 4;
        }
        if (Song.GetComponent<AudioSource>().time >= 200.4 && Song.GetComponent<AudioSource>().time < 201.0)
        {
            triggerType = 8;
        }
        if (Song.GetComponent<AudioSource>().time >= 201.0 && Song.GetComponent<AudioSource>().time < 207.2)
        {
            triggerType = 4;
        }
        if (Song.GetComponent<AudioSource>().time >= 207.2 && Song.GetComponent<AudioSource>().time < 237.0)
        {
            triggerType = 10;
        }
        if (Song.GetComponent<AudioSource>().time >= 237.0 && Song.GetComponent<AudioSource>().time < 237.3f)
        {
            triggerType = 9;
            planetEarth.SetActive(true);
            planetNext.SetActive(true);

        }
        if (Song.GetComponent<AudioSource>().time >= 237.3f && Song.GetComponent<AudioSource>().time < 237.6f)
        {
            triggerType = 9;
            planetNext.transform.position = nextStartpos + new Vector3(0, 0, -842.7f);

        }
        if (Song.GetComponent<AudioSource>().time >= 237.6f && Song.GetComponent<AudioSource>().time < 237.9f)
        {
            triggerType = 9;
            planetNext.transform.position = nextStartpos + new Vector3(0, 0, 691.3f);

        }
        if (Song.GetComponent<AudioSource>().time >= 237.9f && Song.GetComponent<AudioSource>().time < 240.0f)
        {
            triggerType = 9;
            planetNext.transform.position = nextStartpos;

        }
        if (Song.GetComponent<AudioSource>().time >= 240.0f && Song.GetComponent<AudioSource>().time < 242.0f)
        {
            triggerType = 11;
            planetEarth.SetActive(false);
            planetNext.SetActive(false);

        }
        if (Song.GetComponent<AudioSource>().time >= 242.0f && Song.GetComponent<AudioSource>().time < 243.0f)
        {
            triggerType = 12;

        }
        if (Song.GetComponent<AudioSource>().time >= 243.0f && Song.GetComponent<AudioSource>().time < 243.4f)
        {
            triggerType = 13;

        }
        if (Song.GetComponent<AudioSource>().time >= 243.4f && Song.GetComponent<AudioSource>().time < 243.8f)
        {
            triggerType = 4;

        }
        if (Song.GetComponent<AudioSource>().time >= 243.8f && Song.GetComponent<AudioSource>().time < 244.0f)
        {
            triggerType = 6;

        }
        if (Song.GetComponent<AudioSource>().time >= 244.0f && Song.GetComponent<AudioSource>().time < 246.0f)
        {
            triggerType = 14;

        }
        if (Song.GetComponent<AudioSource>().time >= 246.0f && Song.GetComponent<AudioSource>().time < 248.0f)
        {
            triggerType = 7;

        }

        if (Song.GetComponent<AudioSource>().time >= 248.0f && Song.GetComponent<AudioSource>().time < 250.0f)
        {
            triggerType = 8;

        }
        if (Song.GetComponent<AudioSource>().time >= 250.0f)
        {
            triggerType = 15;

        }


       
        
        
        
        
        if (Song.GetComponent<AudioSource>().time >= 282.0f && Song.GetComponent<AudioSource>().time < 283.0f)
        {
            triggerType = 6;

        }

        if (Song.GetComponent<AudioSource>().time >= 283.0f && Song.GetComponent<AudioSource>().time < 284.0f)
        {
            triggerType = 3;

        }
        if (Song.GetComponent<AudioSource>().time >= 284.0f && Song.GetComponent<AudioSource>().time < 285.0f)
        {
            triggerType = 4;

        }


        if (Song.GetComponent<AudioSource>().time >= 285.0f && Song.GetComponent<AudioSource>().time < 286.0f)
        {
            triggerType = 9;

        }

        if (Song.GetComponent<AudioSource>().time >= 286.0f && Song.GetComponent<AudioSource>().time < 287.0f)
        {
            triggerType = 5;

        }
        if (Song.GetComponent<AudioSource>().time >= 287.0f && Song.GetComponent<AudioSource>().time < 288.0f)
        {
            triggerType = 7;

        }












        if (Song.GetComponent<AudioSource>().time >= 288.0f && Song.GetComponent<AudioSource>().time < 289.0f)
        {
            triggerType = 8;

        }

        if (Song.GetComponent<AudioSource>().time >= 289.0f && Song.GetComponent<AudioSource>().time < 290.0f)
        {
            triggerType = 9;

        }
        if (Song.GetComponent<AudioSource>().time >= 290.0f && Song.GetComponent<AudioSource>().time < 291.0f)
        {
            triggerType = 10;

        }


        if (Song.GetComponent<AudioSource>().time >= 291.0f && Song.GetComponent<AudioSource>().time < 292.0f)
        {
            triggerType =11;

        }

        if (Song.GetComponent<AudioSource>().time >= 292.0f && Song.GetComponent<AudioSource>().time < 293.0f)
        {
            triggerType = 12;

        }
        if (Song.GetComponent<AudioSource>().time >= 293.0f && Song.GetComponent<AudioSource>().time < 294.0f)
        {
            triggerType = 13;

        }

        if (Song.GetComponent<AudioSource>().time >= 294.0f && Song.GetComponent<AudioSource>().time < 295.0f)
        {
            triggerType = 14;

        }
        if (Song.GetComponent<AudioSource>().time >= 295.0f && Song.GetComponent<AudioSource>().time < 296.0f)
        {
            triggerType = 15;

        }


        if (Song.GetComponent<AudioSource>().time >= 312.0f && Song.GetComponent<AudioSource>().time < 312.5f)
        {
            triggerType = 6;

        }

        if (Song.GetComponent<AudioSource>().time >= 312.5f && Song.GetComponent<AudioSource>().time < 313.0f)
        {
            triggerType = 3;

        }
        if (Song.GetComponent<AudioSource>().time >= 313.0f && Song.GetComponent<AudioSource>().time < 313.5f)
        {
            triggerType = 4;

        }


        if (Song.GetComponent<AudioSource>().time >= 313.5f && Song.GetComponent<AudioSource>().time < 314.0f)
        {
            triggerType = 9;

        }

        if (Song.GetComponent<AudioSource>().time >= 314.0f && Song.GetComponent<AudioSource>().time < 314.5f)
        {
            triggerType = 5;

        }
        if (Song.GetComponent<AudioSource>().time >= 314.5f && Song.GetComponent<AudioSource>().time < 315.0f)
        {
            triggerType = 7;

        }












        if (Song.GetComponent<AudioSource>().time >= 315.0f && Song.GetComponent<AudioSource>().time < 315.5f)
        {
            triggerType = 8;

        }

        if (Song.GetComponent<AudioSource>().time >= 315.5f && Song.GetComponent<AudioSource>().time < 316.0f)
        {
            triggerType = 9;

        }
        if (Song.GetComponent<AudioSource>().time >= 316.0f && Song.GetComponent<AudioSource>().time < 316.5f)
        {
            triggerType = 10;

        }


        if (Song.GetComponent<AudioSource>().time >= 316.5f && Song.GetComponent<AudioSource>().time < 317.0f)
        {
            triggerType = 11;

        }

        if (Song.GetComponent<AudioSource>().time >= 317.0f && Song.GetComponent<AudioSource>().time < 317.5f)
        {
            triggerType = 12;

        }
        if (Song.GetComponent<AudioSource>().time >= 317.5f && Song.GetComponent<AudioSource>().time < 318.0f)
        {
            triggerType = 13;

        }

        if (Song.GetComponent<AudioSource>().time >= 318.0f && Song.GetComponent<AudioSource>().time < 318.5f)
        {
            triggerType = 14;

        }
        if (Song.GetComponent<AudioSource>().time >= 318.5f && Song.GetComponent<AudioSource>().time < 319.0f)
        {
            triggerType = 15;

        }



        if (Song.GetComponent<AudioSource>().time >= 342.0f)
        {
            triggerType = 6;

        }



    }
}
