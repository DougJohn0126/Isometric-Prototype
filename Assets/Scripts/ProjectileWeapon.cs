using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : PlayerWeapon
{
    [SerializeField] BlasterShot m_BlasterShotPrefab;


    public override void StandardAttack(Transform spot, Quaternion Rotation)
    {
        float delay = p_Delay;

        m_NextAttackTime = Time.time + delay;
        var shot = Instantiate(m_BlasterShotPrefab, spot.position, Rotation);

        //shot.transform.localScale(PlayerController.Instance.state
        shot.Launch(spot.forward);

    }
}
