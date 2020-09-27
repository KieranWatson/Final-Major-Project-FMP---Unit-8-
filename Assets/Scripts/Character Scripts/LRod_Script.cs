using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRod_Script : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 50;
    
    public Rigidbody2D rb;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy_Health enemy = hitInfo.GetComponent<Enemy_Health>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
