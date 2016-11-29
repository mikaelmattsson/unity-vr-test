using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject leftControllerGameObject;
    public GameObject rightControllerGameObject;

    public float speed = 3f;

    ControllerManager leftController;
    ControllerManager rightController;

    // Use this for initialization
    void Start ()
	{
        leftController = ControllerManager.Create(leftControllerGameObject, "Left");
		rightController = ControllerManager.Create(rightControllerGameObject, "Right");
    }
	
	// Update is called once per frame
	void Update ()
	{
		ApplyDragFromController (leftController);
		ApplyDragFromController (rightController);
	}

	void Move ()
	{
        // if (rightController.TriggerPressed())
        // {
        //     transform.Translate(rightController.getDragDistance() * Time.deltaTime * speed);
        // } 

		// Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		// RaycastHit hit;
        // 
		// if (Physics.Raycast (ray, out hit)) {
		// 	transform.position = hit.point;
		// }
	}

	void ApplyDragFromController (ControllerManager controller)
	{
		if (controller.device.triggerPressed) {
			transform.Translate (controller.getDragDistance ());
		}
	}
}
