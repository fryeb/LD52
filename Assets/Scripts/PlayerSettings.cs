using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="PlayerSettings", menuName="Player/PlayerSettings", order=1)]
public class PlayerSettings : ScriptableObject
{
	[Range(1.0f, 10.0f)]
	public float max_speed = 1.0f;
	[Range(0.01f, 10.0f)]
	public float time_to_max_speed = 1.0f;
	[Range(0.01f, 10.0f)]
	public float time_to_rest = 1.0f;
	[Range(1.0f, 10.0f)]
	public float max_revs =  10.0f;

	 // Seconds to full rotation
	[Range(0.01f, 10.0f)]
	public float pitch_time = 1.0f;
	[Range(0.01f, 10.0f)]
	public float yaw_time = 1.0f;
	[Range(0.01f, 10.0f)]
	public float roll_time = 1.0f;

	public float GetAcceleration() {
		return max_speed / time_to_max_speed;
	}

	public float GetDeceleration() {
		return max_speed / time_to_rest;
	}
}
