using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen2 : MonoBehaviour
{
    public GameObject character;
    public GameObject location;
    public GameObject location2;
    Vector3 startpos = new Vector3();
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        startpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(location.transform.position, character.transform.position);
        float distance2 = Vector3.Distance(location2.transform.position, character.transform.position);
        distance = Mathf.Min(distance, distance2);
        if (distance <= 4.5f)
        {
            if (this.transform.position.y <= startpos.y + 20.0f)
            {
                this.transform.position += offset * Time.deltaTime;
            }
        }
        if (distance > 4.5f)
        {
            if(this.transform.position.y > startpos.y)
            {
                this.transform.position -= offset * Time.deltaTime;
            }
        }

    }
}
