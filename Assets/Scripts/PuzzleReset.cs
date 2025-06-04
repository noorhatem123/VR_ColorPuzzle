using UnityEngine;
using UnityEngine.UI;

public class PuzzleReset : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject successMessage;
    public Button restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(ResetPuzzle);
        restartButton.gameObject.SetActive(false); // Hide by default
    }

    public void ShowRestart()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void ResetPuzzle()
    {
        foreach (GameObject cube in cubes)
        {
            cube.transform.position = cube.GetComponent<OriginalPosition>().startPos;

            Rigidbody rb = cube.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        successMessage.SetActive(false);
        restartButton.gameObject.SetActive(false);

        PuzzleManager.Instance.ResetState();
    }
}
