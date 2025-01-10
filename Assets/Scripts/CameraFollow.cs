using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed;

    private void FixedUpdate()
    {
        Vector3 desiredPos= playerTransform.position + offset;
        Vector3 smoothPos= Vector3.Lerp(transform.position,desiredPos, smoothSpeed*Time.deltaTime);


        transform.position = smoothPos;

    }




}
