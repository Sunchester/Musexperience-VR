using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveStretch : MonoBehaviour
{
    public GameObject Stretcher;
    public Vector3 movedir;
    public float slow = 1;
    bool switchdir = false;
    int count = 0;
    Vector3 startPos;
    Vector3 startSize;
    Quaternion startRot;
    // Start is called before the first frame update
    void Start()
    {
        startPos = Stretcher.transform.position;
        startSize = Stretcher.transform.localScale;
        startRot = Stretcher.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            count++;
            if (!switchdir)
                Stretcher.transform.position += movedir * Time.deltaTime;
            else
                Stretcher.transform.position -= movedir * Time.deltaTime;
            if (count > (50 * 5 * slow))
            {
                count = 0;
                switchdir = !switchdir;
            }
        }
        else
        {
            Stretcher.transform.position = startPos;
            Stretcher.transform.localScale = startSize;
            Stretcher.transform.rotation = startRot;
        }
    }
}
