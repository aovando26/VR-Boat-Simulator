using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class LeverController : MonoBehaviour
{
    public GameObject Rudder; // The cube to be rotated
    public float rotationSpeed = 0.5f; // Speed of rotation
    private XRGrabInteractable grabInteractable;
    private bool isGrabbed = false; // Flag to check if the lever is being grabbed
    private float lastLeverRotation = 0f; // Last rotation value of the lever
    private InputActionProperty rotateAction;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Register event listeners for grabbing and releasing the lever
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void Update()
    {
        if (isGrabbed)
        {
            RotateRudder();
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        Debug.Log("Lever grabbed");
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        Debug.Log("Lever released");
    }

    private void RotateRudder()
    {
        Vector3 currentRotation = Rudder.transform.localEulerAngles;
        float newZRotation = currentRotation.z;

        // Get VR controller input
        float rotationInput = rotateAction.action.ReadValue<Vector2>().x; // Assuming left/right movement on the X axis

        // Calculate potential new rotation
        newZRotation += rotationInput * rotationSpeed;

        // Adjust newZRotation to ensure it's within the -45 to 45 degree range
        newZRotation = NormalizeAngle(newZRotation);
        newZRotation = Mathf.Clamp(newZRotation, -45, 45);

        // Apply the clamped rotation
        Rudder.transform.localEulerAngles = new Vector3(currentRotation.x, currentRotation.y, newZRotation);
    }

    // Helper method to normalize angles
    float NormalizeAngle(float angle)
    {
        while (angle > 180)
        {
            angle -= 360;
        }
        while (angle < -180)
        {
            angle += 360;
        }
        return angle;
    }
}
