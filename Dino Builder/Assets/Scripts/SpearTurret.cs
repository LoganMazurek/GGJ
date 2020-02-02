using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTurret : MonoBehaviour
{
    public Transform target;
    public float attackSpeed = 1f;
    private float cooldown = 0f;
    public float dmg;
    public float range = 15f;
    public float turnSpeed = 8f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;

    private void Start()
    {
        if (target == null)
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
        cooldown = attackSpeed;
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortest = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortest)
            {
                shortest = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortest <= range)
        {
            target = nearestEnemy.transform;
        }
        else
            target = null;
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if (cooldown <= 0f)
        {
            Shoot();
            cooldown = 1f / attackSpeed;
        }
        else
            cooldown -= Time.deltaTime;
    }

    public void Shoot()
    {
        target.GetComponent<Enemy>().TakeDamage(dmg);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
