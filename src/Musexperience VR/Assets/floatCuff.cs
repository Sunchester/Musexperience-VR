using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatCuff : MonoBehaviour
{
    public GameObject Cuffs;
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
        startPos = Cuffs.transform.position;
        startSize = Cuffs.transform.localScale;
        startRot = Cuffs.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            if (!activated)
            {
                Cuffs.transform.position += transformVector;
                activated = true;
            }
            Cuffs.transform.RotateAround(rotateDir, Time.deltaTime * speed);
        }
        else
        {

            activated = false;
            Cuffs.transform.position = startPos;
            Cuffs.transform.localScale = startSize;
            Cuffs.transform.rotation = startRot;

        }
    }
}
