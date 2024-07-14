using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    
    private void Update()
    {
        transform.position = targetTransform.position;
    }
}
