using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketChecker : MonoBehaviour
{
    public string correctTag;
    public AudioSource wrongAudio;

    private bool isOccupied = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isOccupied)
            return;

        if (other.CompareTag(correctTag))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
                rb.isKinematic = true;

            // 👇 Detach the cube from the socket
            other.transform.parent = null;

            PlacedFlag flag = other.GetComponent<PlacedFlag>();
            if (flag != null && !flag.isPlaced)
            {
                flag.isPlaced = true;
                PuzzleManager.Instance.MarkCubePlaced();
                isOccupied = true;
            }
        }
        else
        {
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

            if (wrongAudio != null)
                wrongAudio.Play();
        }
    }
}
