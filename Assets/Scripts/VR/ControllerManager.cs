using UnityEngine;
using System.Collections;

public class ControllerManager
{

    public SteamVR_TrackedController device;

    public string name;

    Vector3 dragStart;

    public ControllerManager(SteamVR_TrackedController controller, string name)
    {
        device = controller;
        device.TriggerClicked += this.Trigger;
        this.name = name;
    }

    public static ControllerManager Create(GameObject obj, string name)
    {
        return new ControllerManager(obj.transform.GetComponent<SteamVR_TrackedController>(), name);
    }

    void Trigger(object sender, ClickedEventArgs e)
    {
        dragStart = device.transform.localPosition;
        Debug.Log("Trigger " + name + " has been pressed");
    }

    public bool TriggerPressed()
    {
        return device.triggerPressed;
    }

    public Vector3 getDragDistance()
    {
        return device.transform.localPosition - dragStart;
    }
}
