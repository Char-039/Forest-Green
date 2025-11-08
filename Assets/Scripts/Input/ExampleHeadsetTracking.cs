using UnityEngine;

public class HeadsetTracker : MonoBehaviour
{
    public Transform headsetTransform;

    void Start()
    {
        if (headsetTransform == null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                headsetTransform = mainCamera.transform;
            }
            else
            {
                Debug.LogError("HeadsetTracker: No Main Camera found. Please assign it manually.");
            }
        }
    }

    void Update()
    {
        if (headsetTransform != null)
        {
            // Get the headset's current position
            Vector3 headsetPosition = headsetTransform.position;

            // Get the headset's current rotation
            Quaternion headsetRotation = headsetTransform.rotation;
        }
    }
}