using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float enemy_speed;
    public Transform player;
    public float raycast_distance;
    private Rigidbody rb;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 desired_position = player.position;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, desired_position - transform.position, out hit, raycast_distance))
        {
            desired_position = hit.point;
            Debug.DrawLine(transform.position, desired_position, Color.red);
        }

        transform.position = Vector3.MoveTowards(transform.position, desired_position, enemy_speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 push_direction = (collision.transform.position - transform.position).normalized;
            rb.AddForce(-push_direction * 200);
        }
    }
}