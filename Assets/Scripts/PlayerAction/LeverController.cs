using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverController : MonoBehaviour
{
    public GameObject mockRudder; // The cube to be rotated
    public float speed = 5.0f; // Speed of rotation
    private XRGrabInteractable grabInteractable;
    private bool isGrabbed = false; // Flag to check if the lever is being grabbed
    private float lastLeverRotation = 0f; // Last rotation value of the lever

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
        lastLeverRotation = transform.localEulerAngles.x; // Capture the initial rotation
        Debug.Log("Lever grabbed");
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        Debug.Log("Lever released");
    }

    private void RotateRudder()
    {
        // Get current rotation of the lever
        float currentLeverRotation = transform.localEulerAngles.x;

        // Calculate the difference in rotation since the last frame
        float rotationDelta = currentLeverRotation - lastLeverRotation;

        // Apply the rotation to the cube (mockRudder)
        mockRudder.transform.Rotate(Vector3.right, rotationDelta * speed);

        // Update the last rotation value
        lastLeverRotation = currentLeverRotation;

        // Log rotation details for debugging
        Debug.Log("Rotating cube with amount: " + rotationDelta);
    }
}
