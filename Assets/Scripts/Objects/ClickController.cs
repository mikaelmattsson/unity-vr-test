using UnityEngine;
using System.Collections;

public class ClickController : MonoBehaviour
{

	GameObject player;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		// if (Input.GetButtonDown("Fire1")) {
		// 	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		// 	if (Physics.Raycast(ray))
		// 		Instantiate(particle, transform.position, transform.rotation);
		// }

		// Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		// RaycastHit hit;
		// 
		// if (Physics.Raycast (ray, out hit)) {
		// 	player.transform.position = hit.point;
		// }
	}
}
