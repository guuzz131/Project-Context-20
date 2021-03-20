using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;

    public float height = 10f;
    public float distance = 20f;
    public float angle = 0f;
    public float smoothSpeed = 0.5f;

    private Vector3 refVelocity;
    void Start()
    {
        HandleCamera();
    }

    void Update()
    {
        HandleCamera();
    }

    protected virtual void HandleCamera()
    {
        if (!target)
        {
            return;
        }

        Vector3 worldposition = (Vector3.forward * -distance) + (Vector3.up * height);

        Vector3 rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * worldposition;

        Vector3 flatTargetPosition = target.position;
        flatTargetPosition.y = 0f;
        Vector3 finalPosition = flatTargetPosition + rotatedVector;
        Debug.DrawLine(target.position, finalPosition, Color.blue);

        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, smoothSpeed);
        transform.LookAt(flatTargetPosition);
    }
}
