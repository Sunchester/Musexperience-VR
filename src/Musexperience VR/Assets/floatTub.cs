using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatTub : MonoBehaviour
{
    public GameObject Bathtub;
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
        startPos = Bathtub.transform.position;
        startSize = Bathtub.transform.localScale;
        startRot = Bathtub.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            if (!activated)
            {
                Bathtub.transform.position += transformVector;
                activated = true;
            }
            Bathtub.transform.RotateAround(rotateDir, Time.deltaTime * speed);
        }
        else
        {

            activated = false;
            Bathtub.transform.position = startPos;
            Bathtub.transform.localScale = startSize;
            Bathtub.transform.rotation = startRot;

        }
    }
}
