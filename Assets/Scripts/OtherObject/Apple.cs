using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustedChangeMoveSpeed = 3f;
    LevelGenerator levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustedChangeMoveSpeed);
        Debug.Log("Apple picked up!");
    }
}
