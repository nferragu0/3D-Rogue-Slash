using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float damage = 2f;
    public float radius = 1f;
    public LayerMask layerMask;
    public bool is_Enemy;
    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);
        
        if (hits.Length > 0)
        {
            if (is_Enemy)
            {
                GameObject.FindGameObjectWithTag("atkpoint").SetActive(false);
            }
            hits[0].gameObject.GetComponent<HealthScript>().ApplyDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
