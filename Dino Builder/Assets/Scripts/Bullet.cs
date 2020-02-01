using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed = 15f;
    public float dmg;
    public GameObject impactEffect;
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.position += dir.normalized * distanceThisFrame;
    }

    void HitTarget()
    {
        target.GetComponent<Enemy>().TakeDamage(dmg);
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}

