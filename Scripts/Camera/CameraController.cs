using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform objectToFollow;
    public Vector3 cameraPosition;


     void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + cameraPosition;
        transform.LookAt(objectToFollow);
    }

}
