using UnityEngine;

public class Pickup : MonoBehaviour
{
    const string playerString = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(playerString))
        {
            Debug.Log("Item picked up by: " + other.gameObject.name);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Non-player object entered trigger: " + other.gameObject.name);
        }
        Debug.Log("Pickup triggered by: " + other.gameObject.name);
    }
}
