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
    void Start()
    {
        leftController = ControllerManager.Create(leftControllerGameObject, "Left");
        rightController = ControllerManager.Create(rightControllerGameObject, "Right");
    }

    // Update is called once per frame
    void Update()
    {
        HandleControllerUpdate(leftController);
        HandleControllerUpdate(rightController);
    }

    void HandleControllerUpdate(ControllerManager controller)
    {
        controller.Update();
        ApplyDragFromController(controller);
    }

    void ApplyDragFromController(ControllerManager controller)
    {
        if (controller.isDragging())
        {
            Vector3 d = controller.getDragDistance();

            transform.Translate(new Vector3(d.x, 0, d.z));
        }
    }
}
