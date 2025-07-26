using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    [SerializeField] int currentScore = 0;
    [SerializeField] int requiredScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            if (currentScore >= requiredScore)
            {
                int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextScene);
            }
        }

        if (other.gameObject.CompareTag("Score"))
        {
            currentScore++;
            Destroy(other.gameObject);
        }
    }
}
