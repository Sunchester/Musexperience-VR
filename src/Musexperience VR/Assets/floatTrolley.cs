using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatTrolley : MonoBehaviour
{
    public GameObject Trolley;
    public Vector3 transformVector;
    public Vector3 rotateDir;
    Vector3 startPos;
    Vector3 startSize;
    Quaternion startRot;
    public int speed;
    bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = Trolley.transform.position;
        startSize = Trolley.transform.localScale;
        startRot = Trolley.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            if (!activated)
            {
                Trolley.transform.position += transformVector;
                Trolley.transform.RotateAround(new Vector3(0, 0, 1), -1.5708f);
                activated = true;
            }
            Trolley.transform.RotateAround(rotateDir, Time.deltaTime * speed);
        }
        else
        {

            activated = false;
            Trolley.transform.position = startPos;
            Trolley.transform.localScale = startSize;
            Trolley.transform.rotation = startRot;

        }
    }
}
