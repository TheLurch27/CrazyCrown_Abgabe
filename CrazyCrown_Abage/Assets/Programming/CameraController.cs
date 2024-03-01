using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Der Transform des Characters, dem die Kamera folgen soll
    public float smoothSpeed = 0.125f; // Geschwindigkeit, mit der die Kamera dem Character folgt
    public float minXPosition; // Minimale X-Position, die die Kamera erreichen kann
    public float maxXPosition; // Maximale X-Position, die die Kamera erreichen kann

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            // Zielposition der Kamera berechnen
            float targetX = Mathf.Clamp(target.position.x, minXPosition, maxXPosition);
            Vector3 desiredPosition = new Vector3(targetX, transform.position.y, transform.position.z);

            // Sanftes Verfolgen des Characters
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
