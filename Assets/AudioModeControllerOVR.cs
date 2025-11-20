using UnityEngine;
using UnityEngine.XR;

public class AudioModeControllerOVR : MonoBehaviour
{
    public AudioSource audioSource;

    private bool is3D = false;

    void Update()
    {
        bool pressed = false;
        InputDevice rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out pressed) && pressed)
        {
            ToggleAudioMode();
        }
    }

    void ToggleAudioMode()
    {
        is3D = !is3D;

        if (is3D)
        {
            audioSource.spatialBlend = 1f;   // 3D
            Debug.Log("Audio cambiado a 3D");
        }
        else
        {
            audioSource.spatialBlend = 0f;   // 2D
            Debug.Log("Audio cambiado a 2D");
        }
    }
}
