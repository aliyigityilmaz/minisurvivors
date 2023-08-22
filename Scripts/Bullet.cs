using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Bullet : MonoBehaviour
{
    private Health health;
    private float lifeSpan = 2f;
    public GameObject enemyHitEffect;

    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy0")
        {
            health = collision.GetComponent<Health>();
            health.Damage(5);
            Instantiate(enemyHitEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.tag == "Enemy1")
        {
            health = collision.GetComponent<Health>();
            health.Damage(5);
            Instantiate(enemyHitEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.tag == "Enemy2")
        {
            health = collision.GetComponent<Health>();
            health.Damage(5);
            Instantiate(enemyHitEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.tag == "Enemy3")
        {
            health = collision.GetComponent<Health>();
            health.Damage(5);
            Instantiate(enemyHitEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
