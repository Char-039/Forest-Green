using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using static Unity.XR.CoreUtils.XROrigin;

public class PlayerHeightAdjuster : MonoBehaviour
{
    public Transform cameraOffset;
    public Slider heightSlider;

    public float minHeight = 0.5f;
    public float maxHeight = 2.5f;

    void Start()
    {
        if (cameraOffset == null || heightSlider == null)
        {
            Debug.LogError("PlayerHeightAdjuster requires Camera Offset and Height Slider references to be set in the Inspector.", this);
            enabled = false;
            return;
        }

        heightSlider.minValue = minHeight;
        heightSlider.maxValue = maxHeight;

        heightSlider.value = cameraOffset.localPosition.y;

        heightSlider.onValueChanged.AddListener(SetPlayerHeight);

        if (TryGetComponent<XROrigin>(out var xrOrigin))
        {
            xrOrigin.RequestedTrackingOriginMode = XROrigin.TrackingOriginMode.Device;
        }
    }
    private void SetPlayerHeight(float newHeight)
    {
        float clampedHeight = Mathf.Clamp(newHeight, minHeight, maxHeight);

        cameraOffset.localPosition = new Vector3(
            cameraOffset.localPosition.x,
            clampedHeight,
            cameraOffset.localPosition.z
        );
    }
}