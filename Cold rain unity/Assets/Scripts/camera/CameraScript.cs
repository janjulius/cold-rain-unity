using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform PlayerTransform;
    private Camera cameraa;
    private Vector3 cameraOffset;
    public float Camerazoom;

    public float SmoothFactor = 0.5f;

    public float MaxX;
    public float MaxY;
    public float MinX;
    public float MinY;

    void Start()
    {
        cameraOffset = transform.position - PlayerTransform.position;
        cameraa = GetComponent<Camera>();
    }

    void Update()
    {
        Camerazoom = cameraa.orthographicSize;
    }

    void LateUpdate()
    {
        float viewDistance = Camerazoom + (Camerazoom / 5);
        Vector3 newPos = PlayerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if ((PlayerTransform.position.x - viewDistance)< MinX)
        {
            transform.position = new Vector3((MinX + viewDistance), newPos.y, newPos.z);
        }
        if ((PlayerTransform.position.x + viewDistance)> MaxX)
        {
            transform.position = new Vector3((MaxX - viewDistance), newPos.y, newPos.z);
        }
        if ((PlayerTransform.position.y - viewDistance) < MinY)
        {
            transform.position = new Vector3(newPos.x, (MinY + viewDistance), newPos.z);
        }
        if ((PlayerTransform.position.y + viewDistance) > MaxY)
        {
            transform.position = new Vector3(newPos.x, (MaxY - viewDistance), newPos.z);
        }
        if ((PlayerTransform.position.x - viewDistance) < MinX && (PlayerTransform.position.y - viewDistance) < MinY)
        {
            transform.position = new Vector3((MinX+ viewDistance), (MinY + viewDistance), newPos.z);
        }
        if ((PlayerTransform.position.x - viewDistance) < MinX && (PlayerTransform.position.y + viewDistance) > MaxY)
        {
            transform.position = new Vector3((MinX + viewDistance), (MaxY - viewDistance), newPos.z);
        }
        if ((PlayerTransform.position.x + viewDistance)> MaxX && (PlayerTransform.position.y - viewDistance) < MinY)
        {
            transform.position = new Vector3((MaxX - viewDistance), (MinY + viewDistance), newPos.z);
        }
        if ((PlayerTransform.position.x + viewDistance) > MaxX && (PlayerTransform.position.y + viewDistance) > MaxY)
        {
            transform.position = new Vector3((MaxX - viewDistance), (MaxY - viewDistance), newPos.z);
        }

    }
}
