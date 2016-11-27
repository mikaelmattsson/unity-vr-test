using UnityEngine;
using System.Collections;

public class ModelTurner
{
	protected Transform model;

	public ModelTurner (Transform model)
	{
		this.model = model;
	}

	public void TurnTowards (Vector3 dir, float speed)
	{
		Quaternion targetRotation = Quaternion.LookRotation (dir);

		model.rotation = Quaternion.Lerp (model.rotation, targetRotation, Time.deltaTime * speed);
	}
}
