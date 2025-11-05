using UnityEngine;

public class MirrorLogic2 : MonoBehaviour {
    public Camera mainCamera;

    public Transform mirrorSurface;
    public Transform reflectionCameraTransform;


    void LateUpdate() {

        if (mainCamera == null || mirrorSurface == null) return;

        // Player position relative to mirror
        Vector3 localPlayerPos = mirrorSurface.InverseTransformPoint(mainCamera.transform.position);

        // Invert it so it's a reflection
        Vector3 reflectedLocalPos = new Vector3(-localPlayerPos.x, localPlayerPos.y, localPlayerPos.z);
        reflectionCameraTransform.position = mirrorSurface.TransformPoint(reflectedLocalPos);

        // Find where player is facing
        Vector3 cameraDirection = mainCamera.transform.forward;
        // Find where mirror is facing
        Vector3 mirrorNormal = mirrorSurface.forward;

        // Reflect the camera's direction across the mirror
        Vector3 reflectedDirection = Vector3.Reflect(cameraDirection, mirrorNormal);
        reflectionCameraTransform.rotation = Quaternion.LookRotation(reflectedDirection);
    }
}