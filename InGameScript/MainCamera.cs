using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public float Highst = 5.0f;
	public float Distance = 5.0f;

	public float yMinLimit = -10f;
	public float yMaxLimit = 60f;

	public float DistanceMinLimit = 0.7f;
	public float DistanceMaxLimit = 4.0f;

	public float xSpeed = 10.0f;
	public float ySpeed = 10.0f;

	float x, y;
	Transform Camera_Tr;
	Transform Target;
	Vector3 position;

	int CamState = CameraState.START;
	void Start()
	{
		Target = GameObject.Find("Player").GetComponent<Transform>();
		Camera_Tr = GetComponent<Transform>();
	}

	void LateUpdate()
	{
		if (CamState == CameraState.START)
		{
			Distance -= .1f * Input.mouseScrollDelta.y;
			if (Distance < DistanceMinLimit) Distance = DistanceMinLimit;
			if (Distance > DistanceMaxLimit) Distance = DistanceMaxLimit;

			x += Input.GetAxisRaw("Mouse X") * xSpeed;
			y -= Input.GetAxis("Mouse Y") * ySpeed;

			y = ClampAngle(y, yMinLimit, yMaxLimit);
			Quaternion rotation = Quaternion.Euler(0, x, 0);
			Quaternion rotation2 = Quaternion.Euler(y, x, 0);
			Quaternion c_rotation = Quaternion.Euler(0, x, 0);

			position = rotation * new Vector3(0, Highst, -Distance) + Target.position;

			Target.transform.rotation = c_rotation;
			Camera_Tr.rotation = rotation2;
			Camera_Tr.position = position;
		}

	}

	float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp(angle, min, max);

	}


	public void SetCameraMoveState(int state)
	{
		CamState = state;
	}

	public int GetCameraMoveState()
	{
		return CamState;
	}

	private static MainCamera _Self;
	public static MainCamera Self
	{
		get
		{
			if (!_Self)
			{
				_Self = GameObject.FindObjectOfType(typeof(MainCamera)) as MainCamera;
			}
			return _Self;
		}
	}
}


static class CameraState
{
	public const int STOP = 0;
	public const int START = 1;
}