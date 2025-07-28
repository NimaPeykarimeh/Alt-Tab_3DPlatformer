using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    // �u anki puan�m�z (ba�lang��ta 0)
    [SerializeField] int currentScore = 0;

    // B�l�m ge�mek i�in gereken puan miktar� (Inspector'dan ayarlanabilir)
    [SerializeField] int requiredScore;

    // Oyuncu bir nesneye �arpt���nda bu fonksiyon �al���r
    private void OnTriggerEnter(Collider other)
    {
        // E�er �arpt���m�z nesne "Finish" ise
        if (other.gameObject.CompareTag("Finish"))
        {
            // Yeterli puan topland�ysa bir sonraki sahneye ge�
            if (currentScore >= requiredScore)
            {
                int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextScene); // Bir sonraki sahneyi y�kle
            }
        }

        // E�er �arpt���m�z nesne "Score" etiketi ta��yorsa
        if (other.gameObject.CompareTag("Score"))
        {
            currentScore++; // Skoru bir art�r
            Destroy(other.gameObject); // Nesneyi sahneden sil (�rne�in bir elmas)
        }
    }
}
