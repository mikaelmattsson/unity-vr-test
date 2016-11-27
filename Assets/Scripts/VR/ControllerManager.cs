using UnityEngine;
using System.Collections;

public class ControllerManager : MonoBehaviour
{

    private SteamVR_TrackedController device;

    public string logName;

    void Start()
    {
        device = transform.GetComponent<SteamVR_TrackedController>();
        device.TriggerClicked += this.Trigger;
    }

    void Trigger(object sender, ClickedEventArgs e)
    {
        Debug.Log("Trigger" + logName + " has been pressed");
    }
}
