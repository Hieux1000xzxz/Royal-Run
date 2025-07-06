using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    float cooldownTimer = 0f;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(cooldownTimer >= collisionCooldown)
        {
            animator.SetTrigger("Hit");
            cooldownTimer = 0f;
        }
    }
}
