using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatHack : MonoBehaviour
{
    public GameObject Hacksaw;
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
        startPos = Hacksaw.transform.position;
        startSize = Hacksaw.transform.localScale;
        startRot = Hacksaw.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            if (!activated)
            {
                Hacksaw.transform.position += transformVector;
                activated = true;
            }
            Hacksaw.transform.RotateAround(rotateDir, Time.deltaTime * speed);
        }
        else
        {

            activated = false;
            Hacksaw.transform.position = startPos;
            Hacksaw.transform.localScale = startSize;
            Hacksaw.transform.rotation = startRot;

        }
    }
}
