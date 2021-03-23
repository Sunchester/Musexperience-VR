using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphClock : MonoBehaviour
{
    public GameObject Clock;
    Vector3 startPos;
    Vector3 startSize;
    Quaternion startRot;
    float inc = 0;
    bool sw = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = Clock.transform.position;
        startSize = Clock.transform.localScale;
        startRot = Clock.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(PickupItem.change && PickupItem.triggerType == 1)
        {
            if (inc <= 4.0f && !sw)
            {
                inc += 0.1f;
                Clock.transform.localScale = new Vector3(startSize.x + inc, startSize.y + inc, startSize.z + inc);
                if (inc >= 4.0f)
                    sw = true;
            }
            else
            {
                inc -= 0.1f;
                Clock.transform.localScale = new Vector3(startSize.x + inc, startSize.y + inc, startSize.z + inc);
                if (inc <= 0.01)
                    sw = false;
            }
        }
        else
        {
            inc = 0.0f;
            Clock.transform.position = startPos;
            Clock.transform.localScale = startSize;
            Clock.transform.rotation= startRot;
        }
        
    }
}
