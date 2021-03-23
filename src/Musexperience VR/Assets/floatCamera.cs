using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatCamera : MonoBehaviour
{
    public GameObject Proj;
    public Vector3 transformVector;
    Vector3 startPos;
    Vector3 startSize;
    Quaternion startRot;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    Vector3 offset = new Vector3();
    Vector3 tempPos = new Vector3();
    bool once = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = Proj.transform.position;
        startSize = Proj.transform.localScale;
        startRot = Proj.transform.rotation;
        offset = startPos + transformVector;
    }
    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            if(!once)
            {
                Proj.transform.localScale = startSize * 4;
                once = true;
            }

            tempPos = offset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
        }
        else
        {
            once = false;
            Proj.transform.position = startPos;
            Proj.transform.localScale = startSize;
            Proj.transform.rotation = startRot;

        }
    }
}
