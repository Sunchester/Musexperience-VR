using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatAntler : MonoBehaviour
{
    public GameObject Antler;
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
        startPos = Antler.transform.position;
        startSize = Antler.transform.localScale;
        startRot = Antler.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            if (!activated)
            {
                Antler.transform.position += transformVector;
                Antler.transform.RotateAround(new Vector3(1, 0, 0), -1.5708f);
                activated = true;
            }
            Antler.transform.RotateAround(rotateDir, Time.deltaTime * speed);
        }
        else
        {

            activated = false;
            Antler.transform.position = startPos;
            Antler.transform.localScale = startSize;
            Antler.transform.rotation = startRot;

        }
    }
}