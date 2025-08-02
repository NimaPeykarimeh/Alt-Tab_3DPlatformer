using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    // Þu anki puanýmýz (baþlangýçta 0)
    [SerializeField] int currentScore = 0;

    // Bölüm geçmek için gereken puan miktarý (Inspector'dan ayarlanabilir)
    [SerializeField] int requiredScore;

    // Oyuncu bir nesneye çarptýðýnda bu fonksiyon çalýþýr
    private void OnTriggerEnter(Collider other)
    {
        // Eðer çarptýðýmýz nesne "Finish" ise
        if (other.gameObject.CompareTag("Finish"))
        {
            // Yeterli puan toplandýysa bir sonraki sahneye geç
            if (currentScore >= requiredScore)
            {
                int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextScene); // Bir sonraki sahneyi yükle
            }
        }

        // Eðer çarptýðýmýz nesne "Score" etiketi taþýyorsa
        if (other.gameObject.CompareTag("Score"))
        {
            currentScore++; // Skoru bir artýr
            Destroy(other.gameObject); // Nesneyi sahneden sil (örneðin bir elmas)
        }
    }
}
