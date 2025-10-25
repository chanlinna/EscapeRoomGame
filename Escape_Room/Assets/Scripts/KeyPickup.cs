using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public float pickupDistance = 2.0f;

    // Reference to the Player's Transform (set in the Inspector)
    public Transform playerTransform;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= pickupDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickupKey();
            }
        }
    }

    private void PickupKey()
    {
        GameManager.HasKey = true;
        Destroy(gameObject);
    }
}
