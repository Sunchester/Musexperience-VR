using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSink : MonoBehaviour
{
    public GameObject Sink;
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
        startPos = Sink.transform.position;
        startSize = Sink.transform.localScale;
        startRot = Sink.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            count++;
            if (!switchdir)
                Sink.transform.position += movedir * Time.deltaTime;
            else
                Sink.transform.position -= movedir * Time.deltaTime;
            if (count > (50 * 5 * slow))
            {
                count = 0;
                switchdir = !switchdir;
            }
        }
        else
        {
            Sink.transform.position = startPos;
            Sink.transform.localScale = startSize;
            Sink.transform.rotation = startRot;
        }
    }
}
