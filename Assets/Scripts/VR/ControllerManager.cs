using UnityEngine;
using System.Collections;

public class ControllerManager
{

    public SteamVR_TrackedController device;

    public string name;

    Vector3 dragStart;
    bool dragging = false;
    GameObject grabbedObject = null;
    float grabDistance = 0.2f;

    public ControllerManager(SteamVR_TrackedController controller, string name)
    {
        device = controller;
        device.TriggerClicked += this.Trigger;
        device.TriggerUnclicked += this.UnTrigger;
        this.name = name;
    }

    public static ControllerManager Create(GameObject obj, string name)
    {
        return new ControllerManager(obj.transform.GetComponent<SteamVR_TrackedController>(), name);
    }

    void Trigger(object sender, ClickedEventArgs e)
    {
        GameObject grabbed;
        if (grabbedObject = FindClosestGrabbable())
        {
            grabbedObject.transform.position = device.transform.position;
        }
        else
        {
            dragging = true;
            dragStart = device.transform.localPosition;
        }
    }

    void UnTrigger(object sender, ClickedEventArgs e)
    {
        dragging = false;
        grabbedObject = null;
    }

    public void Update()
    {
        if (grabbedObject)
        {
            grabbedObject.transform.position = device.transform.position;

            Rigidbody rb;

            if (rb = grabbedObject.GetComponent<Rigidbody>()) {
                rb.velocity = new Vector3(0, 0, 0);
            }
            
        }
    }

    public Vector3 getDragDistance()
    {
        Vector3 draggedSinceLastTime = dragStart - device.transform.localPosition;

        dragStart = device.transform.localPosition;

        return draggedSinceLastTime;
    }

    public bool isDragging()
    {
        return dragging;
    }

    GameObject FindClosestGrabbable()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Grabbable");
        GameObject closest = null;
        float distance = grabDistance;
        Vector3 position = device.transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    //public Ray getRay ()
    //{
    //	Vector3 fwd = device.transform.TransformDirection (Vector3.forward);
    //
    //	Debug.DrawRay (device.transform.position, fwd * 50, Color.green);
    //
    //	GameObject objectHit;
    //
    //	if (Physics.Raycast (device.transform.position, fwd, out objectHit, 50)) {
    //		//do something if hit object ie
    //		if (objectHit.name == "Enemy") {
    //			Debug.Log ("Close to enemy");
    //		}
    //	}
    //}

}
