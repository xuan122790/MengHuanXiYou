using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorAnimatorController : MonoBehaviour
{
    public Animator animator;
    public void PlayerLocomotionAnimation(Vector3 lookVector, float dis)
    {
        if (dis > 0.2f) 
        {
            animator.SetFloat("LookX", lookVector.normalized.x);
            animator.SetFloat("LookY", lookVector.normalized.y);
            animator.SetBool("MoveState",true);
        }
        else
        {
            animator.SetBool("MoveState", false);
        }
    }
}
