using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 8f;
    public Transform target;

    // Update is called once per frame  
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + 3f, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
