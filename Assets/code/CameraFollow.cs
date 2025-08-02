using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // اللاعب
    public Vector3 offset = new Vector3(0, 5, -7);  // المسافة من اللاعب
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target); // تخلي الكاميرا تطالع اللاعب (اختياري)
    }
}
