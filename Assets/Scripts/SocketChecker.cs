using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketChecker : MonoBehaviour
{
    public string correctTag;
    public AudioSource wrongAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(correctTag))
        {
            // Wrong cube → move back and buzz
            OriginalPosition original = other.GetComponent<OriginalPosition>();
            if (original != null)
            {
                other.transform.position = original.startPos;
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }

            if (wrongAudio != null) wrongAudio.Play();
        }
        else
        {
            // Right cube → lock in place
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = true;

            PuzzleManager.Instance.MarkCubePlaced();
        }
    }
}
