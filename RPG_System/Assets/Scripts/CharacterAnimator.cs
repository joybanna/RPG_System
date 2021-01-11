using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Animator model_animator;
    [SerializeField] private float currentspeed;


    public void MovementAnim(float _iswalk, bool _isRun)
    {
        currentspeed = _iswalk * 10;
        if (currentspeed != 0)
        {
            model_animator.SetFloat("direction", currentspeed);
            if (_isRun)
            {
                model_animator.SetBool("isRun", true);
                model_animator.SetBool("isWalk", false);
            }
            else
            {
                model_animator.SetBool("isWalk", true);
                model_animator.SetBool("isRun", false);
            }

        }
        else
        {
            model_animator.SetBool("isWalk", false);
            model_animator.SetBool("isRun", false);
        }

    }
    public void JumpAnim()
    {
        model_animator.SetTrigger("isJump");
    }
}
