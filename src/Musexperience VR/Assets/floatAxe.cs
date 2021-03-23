using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatAxe : MonoBehaviour
{
    public GameObject Axe;
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
        startPos = Axe.transform.position;
        startSize = Axe.transform.localScale;
        startRot = Axe.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            if (!activated)
            {
                Axe.transform.position += transformVector;
                Axe.transform.RotateAround(new Vector3(0, 0, 1), 1.5708f);
                Axe.transform.localScale = startSize * 3;
                activated = true;
            }
            Axe.transform.RotateAround(rotateDir, Time.deltaTime * speed);
        }
        else
        {

            activated = false;
            Axe.transform.position = startPos;
            Axe.transform.localScale = startSize;
            Axe.transform.rotation = startRot;

        }
    }
}
