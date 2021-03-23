using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTable : MonoBehaviour
{
    public GameObject Table;
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
        startPos = Table.transform.position;
        startSize = Table.transform.localScale;
        startRot = Table.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            count++;
            if (!switchdir)
                Table.transform.position += movedir * Time.deltaTime;
            else
                Table.transform.position -= movedir * Time.deltaTime;
            if (count > (50 * 5 * slow))
            {
                count = 0;
                switchdir = !switchdir;
            }
        }
        else
        {
            Table.transform.position = startPos;
            Table.transform.localScale = startSize;
            Table.transform.rotation = startRot;
        }
    }
}
