using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatChair : MonoBehaviour
{
    public GameObject Chair;
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
        startPos = Chair.transform.position;
        startSize = Chair.transform.localScale;
        startRot = Chair.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            if (!activated)
            {
                Chair.transform.position += transformVector;
                activated = true;
            }
            Chair.transform.RotateAround(rotateDir, Time.deltaTime * speed);
        }
        else
        {

            activated = false;
            Chair.transform.position = startPos;
            Chair.transform.localScale = startSize;
            Chair.transform.rotation = startRot;

        }
    }
}
