using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BoatLeverController : MonoBehaviour
{
    public BoatManager boatManager;

    [Header("Lever Settings")]
    public XRGrabInteractable lever;
    public float leverRotationRange = 45f; // Range of lever rotation
    public float leverSensitivity = 1f; // Sensitivity of lever input

    private float leverValue;

    private void Start()
    {
        if (lever != null)
        {
            lever.selectExited.AddListener(OnLeverReleased);
        }
    }

    private void Update()
    {
        if (lever.isSelected)
        {
            UpdateLever();
        }
    }

    private void UpdateLever()
    {
        leverValue = lever.transform.localEulerAngles.x;
        leverValue = NormalizeAngle(leverValue);
        leverValue = Mathf.Clamp(leverValue, -leverRotationRange, leverRotationRange);

        float leverRotation = leverValue * leverSensitivity;
        boatManager.RotateBoatLeverControl(leverRotation);
    }

    private void OnLeverReleased(SelectExitEventArgs args)
    {
        leverValue = 0;
        boatManager.RotateBoatLeverControl(0);
    }

    private float NormalizeAngle(float angle)
    {
        while (angle > 180) angle -= 360;
        while (angle < -180) angle += 360;
        return angle;
    }
}
