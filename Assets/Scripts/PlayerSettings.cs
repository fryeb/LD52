using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="PlayerSettings", menuName="Player/PlayerSettings", order=1)]
public class PlayerSettings : ScriptableObject
{
	[Range(1.0f, 10.0f)]
	public float speed = 1.0f;
}
