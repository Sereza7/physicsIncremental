using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
	private Vector3 previousPosition;
	public Transform target;

	// Update is called once per frame
	void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			previousPosition = Input.mousePosition;
		}
		else if (Input.GetMouseButton(0))
		{
			Vector3 direction = -(previousPosition - Input.mousePosition) / 10;
			foreach (Camera cam in Camera.allCameras)
			{
				cam.transform.position = target.position;//new Vector3();
				cam.transform.Rotate(new Vector3(1, 0, 0), -direction.y);
				cam.transform.Rotate(new Vector3(0, 1, 0), direction.x, Space.World);
				cam.transform.Translate(new Vector3(0, 0, -10));
			}
			previousPosition = Input.mousePosition;
		}
	}
}
