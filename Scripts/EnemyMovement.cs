using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private float speed = 1f;
    private SpriteRenderer spriteRenderer;
    private Health health;
    [SerializeField]
    private AudioSource attacksound;
    public GameObject playerHitEffect;
    private float attackRange = 1.25f;
    private float attackCooldown = 1.0f;
    private bool canAttack = true;

    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        if (gameObject.tag == "Enemy1")
        {
            speed = 1.25f;
        }
        if (gameObject.tag == "Enemy2")
        {
            speed = 1.5f;
        }
        if (gameObject.tag == "Enemy3")
        {
            speed = 1.75f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= attackRange && canAttack)
        {
            StartCoroutine(AttackCooldown());
            attacksound.Play();
            Instantiate(playerHitEffect, player.transform.position, Quaternion.identity);
            DamagePlayer();
        }
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        UpdateFacingDirection();
    }

    void UpdateFacingDirection()
    {
        Vector3 playerPos = player.transform.position;
        if (playerPos.x < transform.position.x)
        {
            spriteRenderer.flipX = true; // Flip the sprite horizontally
        }
        else
        {
            spriteRenderer.flipX = false; // Don't flip the sprite
        }
    }

    private void DamagePlayer()
    {
        health = player.GetComponent<Health>();
        if (this.gameObject.tag == "Enemy0")
        {
            health.Damage(5);
        }
        if (this.gameObject.tag == "Enemy1")
        {
            health.Damage(10);
        }
        if (this.gameObject.tag == "Enemy2")
        {
            health.Damage(20);
        }
        if (this.gameObject.tag == "Enemy3")
        {
            health.Damage(25);
        }
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

}
