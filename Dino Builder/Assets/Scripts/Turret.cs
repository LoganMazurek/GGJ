﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    public GameObject bulletPrefab;
    public float attackSpeed = 1f;
    private float cooldown = 0f;
    public float range = 15f;
    public float turnSpeed = 8f;
    public string enemyTag = "Enemy";
    public Transform firePoint;

    public Transform partToRotate;
    // Start is called before the first frame update
    void Start()
    {
        if(target == null)
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
            if(distanceToEnemy < shortest)
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
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }
        //target lock-on and follow
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if (cooldown <= 0f)
        {
            Shoot();
            cooldown = 1f/attackSpeed;
        }
        else
            cooldown -= Time.deltaTime;
    }
    
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.SetTarget(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
