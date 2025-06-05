using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleReset : MonoBehaviour
{
    public void ResetPuzzle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
