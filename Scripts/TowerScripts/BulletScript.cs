using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public int damage = 10;

    public GameObject impactEffect;
    
    void Start()
    {
        
    }
    public void Seek(Transform targe)
    {
        target = targe;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 v3 = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (v3.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(v3.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

        void HitTarget()
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 5f);
            {
                Damage(target);
            }

            Destroy(gameObject);
        }
        void Damage(Transform enemy)
        {
            EnemyScript es = enemy.GetComponent<EnemyScript>();

            if (es != null)
            {
                es.TakeDamage(damage);
            }
        }
    }
}
