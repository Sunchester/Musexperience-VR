using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHeater : MonoBehaviour
{
    public GameObject Heater;
    Vector3 startPos;
    Vector3 startSize;
    Quaternion startRot;
    bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = Heater.transform.position;
        startSize = Heater.transform.localScale;
        startRot = Heater.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            if (!activated)
            {
                Heater.transform.localScale= new Vector3(startSize.x, startSize.y * 100, startSize.z);
                activated = true;
            }
        }
        else
        {

            activated = false;
            Heater.transform.position = startPos;
            Heater.transform.localScale = startSize;
            Heater.transform.rotation = startRot;

        }
    }
}
