using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Valve.VR;

public class PickupItem : MonoBehaviour
{ 
    public SteamVR_Action_Boolean pickup;
    public SteamVR_Input_Sources handTypeL;
    public SteamVR_Input_Sources handTypeR;
    public SteamVR_Behaviour_Pose controllerPoseL;
    public SteamVR_Behaviour_Pose controllerPoseR;
    public GameObject Song;
    public GameObject Light;
    public GameObject Video;
    public GameObject Video2;
    public GameObject Video3;
    public GameObject Video4;
    public GameObject character;
    public int skyType = 0;
    public static int triggerType = 0;
    public static bool change = false;
    bool ishold = false;


    public GameObject text;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    // Start is called before the first frame update
    void Start()
    {
        Light.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, character.transform.position);
        if (distance > 5.5f)
        {
            ishold = false;
        }
        else if(distance <= 5.5f)
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
            Light.SetActive(true);
            Video.GetComponent<VideoPlayer>().Play();
            Video2.GetComponent<VideoPlayer>().Play();
            Video3.GetComponent<VideoPlayer>().Play();
            Video4.GetComponent<VideoPlayer>().Play();

            text.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);


        }
        else if(pickup.GetStateUp(handTypeR))
        {
            Song.GetComponent<AudioSource>().Pause();
            Video.GetComponent<VideoPlayer>().Pause();
            Video2.GetComponent<VideoPlayer>().Pause();
            Video3.GetComponent<VideoPlayer>().Pause();
            Video4.GetComponent<VideoPlayer>().Pause();

            this.transform.SetParent(null);
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<BoxCollider>().enabled = true;
            this.GetComponent<Rigidbody>().freezeRotation = false;
            change = false;
            Light.SetActive(false);

            text.SetActive(true);
            text1.SetActive(true);
            text2.SetActive(true);
            text3.SetActive(true);
            text4.SetActive(true);
            text5.SetActive(true);

        }
    }
}
