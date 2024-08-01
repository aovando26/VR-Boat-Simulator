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
            SpinRudder();
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

    private void SpinRudder()
    {
        if (mockRudder != null)
        {
            Vector3 spinRotate = new Vector3(0.3f, 0, 0); // Correctly initialize the vector
            mockRudder.transform.Rotate(spinRotate * speed * Time.deltaTime); // Apply the rotation
        }
        else
        {
            Debug.LogError("mockRudder is not assigned.");
        }
    }
}
