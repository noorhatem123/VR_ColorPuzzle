using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    private int placedCount = 0;
    public int totalCubes = 3;

    public GameObject successMessage;
    public AudioSource successSound;

    private void Awake()
    {
        Instance = this;
    }

    public void MarkCubePlaced()
    {
        placedCount++;

        if (placedCount >= totalCubes)
        {
            if (successMessage != null)
                successMessage.SetActive(true);

            if (successSound != null)
                successSound.Play();

            // Show the restart button
            FindObjectOfType<PuzzleReset>().ShowRestart();
        }
    }

    public void ResetState()
    {
        placedCount = 0;
    }
}
