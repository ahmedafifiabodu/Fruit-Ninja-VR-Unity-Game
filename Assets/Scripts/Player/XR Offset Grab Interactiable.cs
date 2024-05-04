using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 initialLocalPosition;
    private Quaternion initialLocalRotation;

    private void Start()
    {
        if (!attachTransform)
        {
            GameObject grab = new("Offset Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }
        else
        {
            initialLocalPosition = attachTransform.localPosition;
            initialLocalRotation = attachTransform.localRotation;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            attachTransform.position = args.interactorObject.transform.position;
            attachTransform.rotation = args.interactorObject.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initialLocalPosition;
            attachTransform.localRotation = initialLocalRotation;
        }

        base.OnSelectEntered(args);
    }
}