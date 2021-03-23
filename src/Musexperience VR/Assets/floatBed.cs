using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatBed : MonoBehaviour
{
    public GameObject Bed;
    public Vector3 transformVector;
    Vector3 startPos;
    Vector3 startSize;
    Quaternion startRot;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    Vector3 offset = new Vector3();
    Vector3 tempPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        startPos = Bed.transform.position;
        startSize = Bed.transform.localScale;
        startRot = Bed.transform.rotation;
        offset = startPos + transformVector;
    }
    // Update is called once per frame
    void Update()
    {
        if (PickupItem.change && PickupItem.triggerType == 1)
        {
            tempPos = offset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
        }
        else
        {

            Bed.transform.position = startPos;
            Bed.transform.localScale = startSize;
            Bed.transform.rotation = startRot;

        }
    }
}
