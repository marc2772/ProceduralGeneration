using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
	private float rotationSpeed = 0.8f;
	private float zoomSpeed = 20.0f;

	void Update()
	{
		//Zoom
		float zoom = Input.GetAxis("Mouse ScrollWheel");

		Vector3 cameraPosition = Camera.main.transform.localPosition;
		cameraPosition.z += zoom * zoomSpeed;

		if(cameraPosition.z > -20.0f)
			cameraPosition.z = -20.0f;
		else if(cameraPosition.z < -175.0f)
			cameraPosition.z = -175.0f;
		
		Camera.main.transform.localPosition = cameraPosition;

		float moveSpeed = -cameraPosition.z / 175.0f;
		
		//Movements
		Vector3 position = transform.position;
		Quaternion localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

		position = Quaternion.Inverse(localRotation) * position;

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		position.x += horizontal * moveSpeed;
		position.z += vertical * moveSpeed;

		position = localRotation * position;

		transform.position = position;

		//Rotation
		float rotation = Input.GetAxis("Rotation");

		Vector3 eulerRotation = transform.eulerAngles;
		eulerRotation.y += -rotation * rotationSpeed;
		transform.eulerAngles = eulerRotation;
	}
}
