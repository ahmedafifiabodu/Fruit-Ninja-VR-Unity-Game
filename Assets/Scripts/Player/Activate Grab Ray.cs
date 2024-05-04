using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour
{
    [SerializeField] private GameObject leftGrabRay;
    [SerializeField] private GameObject rightGrabRay;

    [SerializeField] private XRDirectInteractor LeftDirectGrab;
    [SerializeField] private XRDirectInteractor RightDirectGrab;

    private void Update()
    {
        leftGrabRay.SetActive(LeftDirectGrab.interactablesSelected.Count == 0);
        rightGrabRay.SetActive(RightDirectGrab.interactablesSelected.Count == 0);
    }
}