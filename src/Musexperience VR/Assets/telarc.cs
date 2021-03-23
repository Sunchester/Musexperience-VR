using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class telarc : MonoBehaviour
{
    public CharacterController controller;
    public SteamVR_Input_Sources handLeft;
    public SteamVR_Action_Boolean telbtn;
    public SteamVR_Behaviour_Pose VRcontrollerPose;
    public int segments = 12;
    public float maxdist = 10.0f;
    public LineRenderer lr;

    bool btn_pressed = false;
    bool target_locked = false;

    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool telpressed = telbtn.GetState(handLeft);
        if (!telpressed && !btn_pressed)
        {
            lr.enabled = false;
            return;
        }
        if (!telpressed && btn_pressed)
        {
            btn_pressed = false;
            if (target_locked)
            {
                Vector3 diff = target - controller.transform.position;
                controller.Move(diff);
            }
            target_locked = false;
            lr.enabled = false;
            return;
        }
        btn_pressed = true;

        var pointlist = new List<Vector3>();

        Quaternion rot = VRcontrollerPose.transform.rotation;
        Matrix4x4 m = Matrix4x4.Rotate(rot);
        Vector3 pointdirection = m.MultiplyPoint3x4(new Vector3(0, 0, 1));
        float angle = Vector3.Dot(new Vector3(0, 1, 0), pointdirection);
        float dist = Mathf.Sin(angle * Mathf.PI) * maxdist;

        Vector3 dir = pointdirection;
        dir.y = 0;
        dir = Vector3.Normalize(dir) * dist;

        Vector3 A, P, B;
        A = VRcontrollerPose.transform.position;
        B = A + dir;
        RaycastHit hit;

        if (Physics.Raycast(B, new Vector3(0, -1, 0), out hit, 10))
        {
            B.y = B.y - hit.distance;
            target = B;
            target_locked = true;
            lr.enabled = true;
            Color wS = new Color(1.0f, 1.0f, 1.0f);
            lr.SetColors(wS, wS);

        }
        else
        {
            target_locked = false;
            lr.enabled = true;
            Color red = new Color(1.0f, 0.0f, 0.0f);
            lr.SetColors(red, red);

        }
        P = (A + B) / 2.0f;
        P.y += 3.0f;

        for (float t = 0; t <= 1.0f; t += 1.0f / segments)
        {
            Vector3 AP = A * (1.0f - t) + P * t;
            Vector3 PB = Vector3.Lerp(P, B, t);
            Vector3 R = Vector3.Lerp(AP, PB, t);
            pointlist.Add(R);
        }
        lr.positionCount = pointlist.Count;
        lr.SetPositions(pointlist.ToArray());
    }
}