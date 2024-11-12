using UnityEngine;

public class CharacterAnimationController : AnimationController
{

    private static readonly int isWalking = Animator.StringToHash("isWalking");
    private static readonly int isHit = Animator.StringToHash("isHit");

    private readonly float magnituteThreshold = 0.5f;

    protected override void Awake()
    {
        base.Awake();
    }


    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    public void Move(Vector2 vector)
    {
        animator.SetBool(isWalking, vector.magnitude > magnituteThreshold);
    }

    public void Hit()
    {
        animator.SetBool(isHit, true);
    }

    public void InvincibilityEnd()
    {
        animator.SetBool(isHit, false);
    }
}