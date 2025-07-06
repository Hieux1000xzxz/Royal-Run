using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustedChangeMoveSpeed = 3f;
    LevelGenerator levelGenerator;

    private void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustedChangeMoveSpeed);
        Debug.Log("Apple picked up!");
    }
}
