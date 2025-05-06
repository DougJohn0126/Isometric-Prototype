using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {Projectile, Melee}

public abstract class PlayerWeapon : MonoBehaviour
{
    [SerializeField] protected WeaponType p_Type;
    [SerializeField] protected float p_Delay;
    protected float m_NextAttackTime;

    // MODIFIES: THIS
    public abstract void StandardAttack(Transform spot, Quaternion rotation);

    public WeaponType GetType() {return p_Type; }

}
