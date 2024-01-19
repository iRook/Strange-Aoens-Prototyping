using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newFollowStateData", menuName = "Data/State Data/Follow State")]
public class D_FollowState : ScriptableObject
{
    public float followSpeed = 3.0f;

    public GameObject whereIsPlayer;
}
