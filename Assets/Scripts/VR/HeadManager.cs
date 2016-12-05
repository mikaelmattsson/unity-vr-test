using UnityEngine;
using System.Collections;

public class HeadManager
{

    public SteamVR_TrackedCamera device;

    public string name;

    public HeadManager(SteamVR_TrackedCamera head)
    {
        device = head;
    }

    public static HeadManager Create(GameObject obj)
    {
        return new HeadManager(obj.transform.GetComponent<SteamVR_TrackedCamera>());
    }

    public void Update()
    {

    }

}
