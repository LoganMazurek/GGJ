using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public float speed = 10.0f;
    public float maxHealth;
    public float currentHealth;
    public int boneWorth;
    public Player player;
    private Transform target;
    private int waypointStartIndex;
    private int waypointIndex = 0;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    private void Start()
    {
        target = Waypoints.points[waypointStartIndex];
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
        if(currentHealth <= 0f)
        {
            Die();
        }

    }
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
    }

    void Die()
    {
        player.GetBone(boneWorth);
        Destroy(gameObject);
    }
    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            player.TakeDamage(boneWorth);
            Destroy(gameObject);
            return;
        }
        waypointIndex++;

        target = Waypoints.points[waypointIndex];
    }
}
