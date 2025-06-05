using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public int totalCubes = 3;
    public GameObject successMessage;
    public GameObject restartButton; // 🎯 Now directly assigned in Inspector
    public AudioSource successSound;

    private int placedCount = 0;

    private void Awake()
    {
        if (Instance == null)
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

            if (restartButton != null)
                restartButton.SetActive(true); // 🎯 Trigger reset button here
        }
    }

    public void ResetPlacedCount()
    {
        placedCount = 0;
    }
}
