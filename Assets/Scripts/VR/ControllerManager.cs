using UnityEngine;
using System.Collections;

public class ControllerManager
{

	public SteamVR_TrackedController device;

	public string name;

	Vector3 dragStart;

	public ControllerManager (SteamVR_TrackedController controller, string name)
	{
		device = controller;
		device.TriggerClicked += this.Trigger;
		this.name = name;
	}

	public static ControllerManager Create (GameObject obj, string name)
	{
		return new ControllerManager (obj.transform.GetComponent<SteamVR_TrackedController> (), name);
	}

	void Trigger (object sender, ClickedEventArgs e)
	{
		dragStart = device.transform.localPosition;
		Debug.Log ("Trigger " + name + " has been pressed");
	}

	public Vector3 getDragDistance ()
	{
		Vector3 draggedSinceLastTime = dragStart - device.transform.localPosition;

		dragStart = device.transform.localPosition;

		return draggedSinceLastTime;
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
