using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 cameraOffset;

    public float smoothFactor = 0.5f;

    public float maxX;
    public float maxY;
    public float minX;
    public float minY;

    void Start()
    {

        cameraOffset = transform.position - playerTransform.position;

    }


    void LateUpdate()
    {
        Vector3 newPos = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (playerTransform.position.x < minX)
        {
            transform.position = new Vector3(minX, newPos.y, newPos.z);
        }
        if (playerTransform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, newPos.y, newPos.z);
        }
        if (playerTransform.position.y < minY)
        {
            transform.position = new Vector3(newPos.x, minY, newPos.z);
        }
        if (playerTransform.position.y > maxY)
        {
            transform.position = new Vector3(newPos.x, maxY, newPos.z);
        }
        if (playerTransform.position.x < minX && playerTransform.position.y < minY)
        {
            transform.position = new Vector3(minX, minY, newPos.z);
        }
        if (playerTransform.position.x < minX && playerTransform.position.y > maxY)
        {
            transform.position = new Vector3(minX, maxY, newPos.z);
        }
        if (playerTransform.position.x > maxX && playerTransform.position.y < minY)
        {
            transform.position = new Vector3(maxX, minY, newPos.z);
        }
        if (playerTransform.position.x > maxX && playerTransform.position.y > maxY)
        {
            transform.position = new Vector3(maxX, maxY, newPos.z);
        }

    }
}
