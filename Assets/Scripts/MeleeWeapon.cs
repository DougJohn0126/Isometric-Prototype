using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : PlayerWeapon
{
    [SerializeField]
    private Animator m_Animator;

    public override void StandardAttack(Transform spot, Quaternion Rotation)
    {
        float delay = p_Delay;

        m_NextAttackTime = Time.time + delay;
        Debug.Log(m_Animator.isActiveAndEnabled);
        m_Animator.SetTrigger("Swing");

    }
}
