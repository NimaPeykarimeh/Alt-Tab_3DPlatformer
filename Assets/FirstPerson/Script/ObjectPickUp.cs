using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] float pickUpRange = 3f;
    [SerializeField] Transform grabPoint;
    [SerializeField] LayerMask pickupLayerMask;

    [SerializeField] GameObject heldObject;
    Rigidbody heldObjectRigidbody;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPickUp();
        }
        if (Input.GetMouseButtonUp(0))
        {
            TryDropObject();
        }
    }

    private void TryPickUp()
    {
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, pickUpRange, pickupLayerMask))
        {
            if (hit.transform.CompareTag("Pickup"))
            {
                heldObject = hit.transform.gameObject;

                heldObjectRigidbody = hit.rigidbody;
                heldObjectRigidbody.isKinematic = true;

                heldObject.transform.SetParent(grabPoint);
                heldObject.transform.localPosition = Vector3.zero;
            }
        }
    }

    private void TryDropObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null);
            heldObjectRigidbody.isKinematic = false;
            heldObject = null;
        }
    }
}
