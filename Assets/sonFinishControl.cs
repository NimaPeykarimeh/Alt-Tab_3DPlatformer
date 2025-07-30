using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class sonFinishControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tebrikler;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sonFinish"))
        {
            tebrikler.text = "Tebrikler Tüm Bölümleri Baþarýyla Tamamladýnýz!!!";
        }
    }
}
