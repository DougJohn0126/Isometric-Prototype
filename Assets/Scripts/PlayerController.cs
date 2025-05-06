using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public Transform MeleeAttackPoint;
    public Transform ProjectileAttackPoint;

    public TextMeshProUGUI UIText;


    private PlayerState mPlayerState;
    private int mCurrentStateIndex;
    [SerializeField]
    private AllPlayerStates m_AllPlayerStates;

    [SerializeField]
    private MovementController m_MovementController;

    private GameObject mCurrentWeaponGO;
    private GameObject mCurrentWeaponGOPrefab;
    private PlayerWeapon mCurrentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(m_AllPlayerStates.AllStates[0]);
        mCurrentStateIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mPlayerState.EquipedWeapon != null)
            {
                switch (mCurrentWeapon.GetType()) {
                    case WeaponType.Melee:
                        mCurrentWeapon.StandardAttack(ProjectileAttackPoint, transform.rotation);
                        break;
                    case WeaponType.Projectile:
                        mCurrentWeapon.StandardAttack(MeleeAttackPoint, transform.rotation);
                        break;

                }
            }
        }
        if (Input.GetKeyDown("space"))
        {
            mCurrentStateIndex += 1;
            if (mCurrentStateIndex >= m_AllPlayerStates.AllStates.Count)
            {
                mCurrentStateIndex = 0;
            } 
            ChangeState(m_AllPlayerStates.AllStates[mCurrentStateIndex]);
        }
    }


    public void ChangeState(PlayerState state)
    {
        Destroy(mCurrentWeaponGOPrefab);
        UIText.text = state.StateName;

        mPlayerState = state;
        m_MovementController.SetSpeed(state.PlayerSpeed);
        Physics.IgnoreLayerCollision(3, 7, mPlayerState.IsPhasable);

        transform.localScale = new Vector3(1,1,1) * state.PlayerScale;

        mCurrentWeaponGO = mPlayerState.EquipedWeapon;

        if (mCurrentWeaponGO != null)
        {
            mCurrentWeapon = mCurrentWeaponGO.GetComponent<PlayerWeapon>();
        }

        if (mCurrentWeaponGO != null)
        {
            if (mCurrentWeapon.GetType() == WeaponType.Melee)
            {
                mCurrentWeaponGOPrefab = Instantiate(mCurrentWeaponGO, MeleeAttackPoint.position, transform.rotation, MeleeAttackPoint);
            } 
        }
    }
}
