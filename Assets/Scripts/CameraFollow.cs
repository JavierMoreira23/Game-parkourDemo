using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target; // El player
    
    [Header("Offset")]
    public Vector3 offset = new Vector3(0, 5, -7);
    
    [Header("Smooth")]
    public float smoothSpeed = 5f;
    
    private void LateUpdate()
    {
        if (target == null) return;
        
        // Posición deseada
        Vector3 desiredPosition = target.position + offset;
        
        // Suavizar el movimiento
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        // Aplicar posición
        transform.position = smoothedPosition;
        
        // Mirar al player
        transform.LookAt(target);
    }
}
