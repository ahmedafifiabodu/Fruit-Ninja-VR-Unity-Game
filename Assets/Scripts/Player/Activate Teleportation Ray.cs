using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{
    [Header("Teleportation Ray")]
    [SerializeField] private GameObject leftTeleportation;

    [SerializeField] private GameObject rightTeleportation;

    [Header("Input Actions")]
    [SerializeField] private InputActionProperty leftTeleportationAction;

    [SerializeField] private InputActionProperty rightTeleportationAction;

    [SerializeField] private InputActionProperty leftCancel;
    [SerializeField] private InputActionProperty rightCancel;

    [Header("Ray Interactors")]
    [SerializeField] private XRRayInteractor leftRay;

    [SerializeField] private XRRayInteractor rightRay;

    private void Update()
    {
        bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftPosition, out Vector3 leftNormal, out int leftNumber, out bool leftValid);
        bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightPosition, out Vector3 rightNormal, out int rightNumber, out bool rightValid);

        leftTeleportation.SetActive(!isLeftRayHovering && leftCancel.action.ReadValue<float>() == 0 && leftTeleportationAction.action.ReadValue<float>() > 0.1f);
        rightTeleportation.SetActive(!isRightRayHovering && rightCancel.action.ReadValue<float>() == 0 && rightTeleportationAction.action.ReadValue<float>() > 0.1f);
    }
}