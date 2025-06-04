using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTagInteractor : XRSocketInteractor
{
    [Tooltip("Only objects with this tag can be snapped into this socket.")]
    public string targetTag;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) &&
               interactable.CompareTag(targetTag);
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) &&
               interactable.CompareTag(targetTag);
    }
}
