using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Animator animator;

    protected Rigidbody rigidbody;

    public void UpdateAnimationState(AnimationState state)
    {
        switch (state)
        {
            case AnimationState.Idle:
                animator.SetBool("isWalking", false);
                break;
            case AnimationState.Walking:
                animator.SetBool("isWalking", true);
                break;
                
            case AnimationState.Failing:
                animator.SetTrigger("hasFailed");
                break;
            case AnimationState.Dancing:
                animator.SetTrigger("hasSucceeded");
                print("has succeed");
                break;
        }
    }
}
public enum AnimationState
{
    Idle,
    Walking,
    Dancing,
    Failing
}
public enum CharacterState
{
    Desperate,
    Modest,
    Famous,
    Superstar
}
