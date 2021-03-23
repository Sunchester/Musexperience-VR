using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatKnife : MonoBehaviour
{
    public GameObject Knife;
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
        startPos = Knife.transform.position;
        startSize = Knife.transform.localScale;
        startRot = Knife.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            if (!activated)
            {
                Knife.transform.position += transformVector;
                activated = true;
            }
            Knife.transform.RotateAround(rotateDir, Time.deltaTime * speed);
        }
        else
        {

            activated = false;
            Knife.transform.position = startPos;
            Knife.transform.localScale = startSize;
            Knife.transform.rotation = startRot;

        }
    }
}
