﻿using UnityEngine;
using System.Collections;

// helper script for testing angle calculation
// USAGE:
// - Attach this script to objectA and assign objectB as target
// - Then select objectA and move it around ObjectB and you can see angle values in inspector

[ExecuteInEditMode]
public class GetAngle : MonoBehaviour 
{
	public Transform target;
	public float angle;
	public float yAngle;
	public float angleOpt;

	void Update () 
	{
		if (!target) return;

		var myPos = transform.position;
		// myPos.y = 0;

		var targetPos = target.position;
		// targetPos.y = 0;

		Vector3 toOther = (myPos - targetPos).normalized;
		Vector3 targetDir = target.position - transform.position;


		angle = ((Mathf.Atan2(toOther.z, toOther.x) * Mathf.Rad2Deg) + 360) % 360;
		angleOpt = atan2Approximation(toOther.z, toOther.x) * Mathf.Rad2Deg + 180;
		
		
		
		
		yAngle = ((Mathf.Atan2(toOther.x, toOther.y) * Mathf.Rad2Deg) + 360) % 360;

		Debug.DrawLine (myPos, targetPos, Color.yellow);
	}


public static Vector3 GetDirection(float aAzimuth, float aElevation) {
	aAzimuth *= Mathf.Deg2Rad;
	aElevation *= Mathf.Deg2Rad;

	float c = Mathf.Cos(aElevation);
	return new Vector3(Mathf.Sin(aAzimuth) * c, Mathf.Sin(aElevation), Mathf.Cos(aAzimuth) * c);
}
	float atan2Approximation(float y, float x) // http://http.developer.nvidia.com/Cg/atan2.html
	{
		float t0, t1, t2, t3, t4;
		t3 = Mathf.Abs(x);
		t1 = Mathf.Abs(y);
		t0 = Mathf.Max(t3, t1);
		t1 = Mathf.Min(t3, t1);
		t3 = 1f / t0;
		t3 = t1 * t3;
		t4 = t3 * t3;
		t0 =         - 0.013480470f;
		t0 = t0 * t4 + 0.057477314f;
		t0 = t0 * t4 - 0.121239071f;
		t0 = t0 * t4 + 0.195635925f;
		t0 = t0 * t4 - 0.332994597f;
		t0 = t0 * t4 + 0.999995630f;
		t3 = t0 * t3;
		t3 = (Mathf.Abs(y) > Mathf.Abs(x)) ? 1.570796327f-t3 : t3;
		t3 = (x < 0) ? 3.141592654f-t3:t3;
		t3 = (y < 0) ? -t3 : t3;
		return t3;
	}

}