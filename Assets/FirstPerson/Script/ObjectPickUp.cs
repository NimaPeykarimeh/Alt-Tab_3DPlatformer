using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    // Nesneleri alıp bırakmak için değişkenler
    [SerializeField] Transform playerCamera; // Oyuncunun kamerası
    [SerializeField] float pickUpRange = 3f; // Nesne alma mesafesi
    [SerializeField] Transform grabPoint; // Nesnenin tutulacağı nokta
    [SerializeField] LayerMask pickupLayerMask; // Alınabilir nesnelerin katmanı

    GameObject heldObject; // Tutulan nesne
    Rigidbody heldObjectRigidbody; // Tutulan nesnenin fizik bileşeni

    void Update()
    {
        // Sol fare tuşuna basıldığında nesne almayı dene
        if (Input.GetMouseButtonDown(0))
        {
            TryPickUp();
        }
        // Sol fare tuşu bırakıldığında nesneyi bırakmayı dene
        if (Input.GetMouseButtonUp(0))
        {
            TryDropObject();
        }
    }

    private void TryPickUp()
    {
        // Kamera yönünde ışın gönder ve nesneye çarpıp çarpmadığını kontrol et
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, pickUpRange, pickupLayerMask))
        {
            // Çarpılan nesne "Pickup" etiketi taşıyorsa
            if (hit.transform.CompareTag("Pickup"))
            {
                heldObject = hit.transform.gameObject; // Nesneyi tut

                heldObjectRigidbody = hit.rigidbody; // Nesnenin fizik bileşenini al
                heldObjectRigidbody.isKinematic = true; // Nesneyi fiziksel etkilerden çıkar

                heldObject.transform.SetParent(grabPoint); // Nesneyi tutma noktasına bağla
                heldObject.transform.localPosition = Vector3.zero; // Nesneyi tutma noktasında sıfırla
            }
        }
    }

    private void TryDropObject()
    {
        // Eğer bir nesne tutuluyorsa
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null); // Nesneyi serbest bırak
            heldObjectRigidbody.isKinematic = false; // Nesneyi fiziksel etkilerle etkileşimli yap
            heldObject = null; // Tutulan nesneyi sıfırla
        }
    }
}
