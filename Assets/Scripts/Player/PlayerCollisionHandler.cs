using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustedChangeMoveSpeed = -2f;
    [SerializeField] LevelGenerator levelGenerator;
    float cooldownTimer = 0f; 
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(cooldownTimer >= collisionCooldown)
        {
            levelGenerator.ChangeChunkMoveSpeed(adjustedChangeMoveSpeed);
            animator.SetTrigger("Hit");
            cooldownTimer = 0f;
        }
    }
}
