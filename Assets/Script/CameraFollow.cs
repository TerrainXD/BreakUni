using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;


    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, -29, 39f),
            Mathf.Clamp(targetToFollow.position.y, -23f, 23f),
            transform.position.z);
    }
}
