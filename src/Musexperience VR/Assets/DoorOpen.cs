using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject character;
    public GameObject location;
    public GameObject location2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float angley = 0.0f;
    int move = 0;
    void Update()
    {
        float distance = Vector3.Distance(location.transform.position, character.transform.position);
        float distance2 = Vector3.Distance(location2.transform.position, character.transform.position);
        distance = Mathf.Min(distance, distance2);
        if (distance <= 4.5f)
        {
            if (angley <= 0.0f && move == 0) move = 1;
            //if (angley >= (3.1415296f / 2.0f) && move == 0) move = -1;
        }
        if (distance > 4.5f)
        {
            if (angley > 0.0f && move == 0) move = -1;
            //if (angley < (3.1415296f / 2.0f) && move == -1) move = 1;
            //else if (angley > 0.0f && move == 1) move = -1;
        }
        float mom_angle = 0.0f;
        if (move == 1)
            mom_angle = 0.01f;
        if (move == -1)
            mom_angle = -0.01f;
        this.transform.RotateAround(new Vector3(0, 1, 0), -mom_angle);

        angley += mom_angle;
        if (angley <= 0.0f) move = 0;
        if (angley >= (3.1415296f / 2.0f)) move = 0;

    }
}
