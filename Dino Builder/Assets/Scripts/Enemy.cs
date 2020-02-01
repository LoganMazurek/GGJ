using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy: MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    private Player player;
    private Transform target;
    private int waypointIndex = 0;
    public float speed = 10.0f;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    private void Start()
    {
        target = Waypoints.points[0];
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth <= 0)
        {
            Die();
            return;
        }
    }

    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            player.LoseLife();
            Destroy(gameObject);
            return;
        }
        waypointIndex++;

        target = Waypoints.points[waypointIndex];
    }
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
    }

    void Die()
    {
        player.bones++;
        Destroy(gameObject);
    }
}
