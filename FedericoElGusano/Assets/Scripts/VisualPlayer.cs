using UnityEngine;

public class VisualPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;

    public Transform target;

    private Vector3 vel = Vector3.zero;

    private void FixedUpdate()
    {
        
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;
        targetPosition.y = transform.position.y;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, damping);
    }
}



