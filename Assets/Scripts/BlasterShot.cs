using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterShot : MonoBehaviour
{
    [SerializeField] AOEAttack m_ExplosionPrefab;

    [SerializeField] private float m_Speed;

    [SerializeField] private bool m_IsExplosive;

    public void Launch ( Vector3 direction)
    {
        direction.Normalize();
        transform.up = direction;
        GetComponent<Rigidbody>().velocity = direction * m_Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (m_IsExplosive)
        {
            Instantiate(m_ExplosionPrefab, transform.position, transform.rotation);
        }
    }

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
}
