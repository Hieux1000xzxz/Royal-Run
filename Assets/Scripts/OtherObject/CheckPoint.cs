using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float checkPointTimeExtention = 5f;
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.IsGameOver) return;
        if (other.CompareTag("Player"))
        {
           GameManager.Instance.IncreaseTime(checkPointTimeExtention);
        }
    }
}
