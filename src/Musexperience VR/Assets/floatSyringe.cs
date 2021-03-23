using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatSyringe : MonoBehaviour
{
    public GameObject Syringe;
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
        startPos = Syringe.transform.position;
        startSize = Syringe.transform.localScale;
        startRot = Syringe.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            if (!activated)
            {
                Syringe.transform.position += transformVector;
                activated = true;
            }
            Syringe.transform.RotateAround(rotateDir, Time.deltaTime * speed);
        }
        else
        {

            activated = false;
            Syringe.transform.position = startPos;
            Syringe.transform.localScale = startSize;
            Syringe.transform.rotation = startRot;

        }
    }
}
