using UnityEngine;
using UnityEngine.UIElements;

public abstract class Pickup : MonoBehaviour
{
    private float rotationSpeed = 100f;
    const string playerString = "Player";

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Non-player object entered trigger: " + other.gameObject.name);
        }
        Debug.Log("Pickup triggered by: " + other.gameObject.name);
    }
    protected abstract void OnPickup();
   
}
