using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class controllerMove : MonoBehaviour
{
    public CharacterController controller;
    public SteamVR_Input_Sources handTypeRotate;
    public SteamVR_Action_Vector2 Trackrot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 trackingrot = Trackrot.GetAxis(handTypeRotate);
        Vector3 euler = new Vector3(0, trackingrot.x * Time.deltaTime * 50.0f, 0);
        transform.Rotate(euler);
    }
}
