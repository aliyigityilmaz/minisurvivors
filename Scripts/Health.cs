
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    private float currentHealth;
    private float maxHealth;
    [SerializeField]
    private Slider healthslider;
    [SerializeField]
    private GameObject deadEnemy0, deadEnemy1, deadEnemy2, deadEnemy3;
    [SerializeField]
    private Text playerHpText;
    [SerializeField]
    private GameObject exp0, exp1, exp2;

    [SerializeField]
    private GameObject healthbuff;

    // Start is called before the first frame update
    void Awake()
    {
        if (gameObject.tag == "Player")
        {
            maxHealth = 100;           
        }
        if (gameObject.tag == "Enemy0")
        {
            maxHealth = 10;
        }
        if (gameObject.tag == "Enemy1")
        {
            maxHealth = 15;
        }
        if (gameObject.tag == "Enemy2")
        {
            maxHealth = 25;
        }
        if (gameObject.tag == "Enemy3")
        {
            maxHealth = 35;
        }
        currentHealth = maxHealth;
        SetHealth(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
        SetHealth(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy0")
            {
                Instantiate(deadEnemy0, transform.position, Quaternion.identity);
                Instantiate(exp0, transform.position, Quaternion.identity);
                int rng = Random.Range(0, 100);
                if (rng <= 5)
                {
                    Instantiate(healthbuff, transform.position, Quaternion.identity);
                }
            }
            if (gameObject.tag == "Enemy1")
            {
                Instantiate(deadEnemy1, transform.position, Quaternion.identity);
                Instantiate(exp0, transform.position, Quaternion.identity);
                int rng = Random.Range(0, 100);
                if (rng <= 7)
                {
                    Instantiate(healthbuff, transform.position, Quaternion.identity);
                }
            }
            if (gameObject.tag == "Enemy2")
            {
                Instantiate(deadEnemy2, transform.position, Quaternion.identity);
                Instantiate(exp1, transform.position, Quaternion.identity);
                int rng = Random.Range(0, 100);
                if (rng <= 10)
                {
                    Instantiate(healthbuff, transform.position, Quaternion.identity);
                }
            }
            if (gameObject.tag == "Enemy3")
            {
                Instantiate(deadEnemy3, transform.position, Quaternion.identity);
                Instantiate(exp2, transform.position, Quaternion.identity);
                int rng = Random.Range(0, 100);
                if (rng <= 15)
                {
                    Instantiate(healthbuff, transform.position, Quaternion.identity);
                }
            }
            Destroy(gameObject);
        }
    }
    public void SetHealth(float health, float maxhealth)
    { 
        healthslider.value = health / maxhealth;
        if (gameObject.tag != "Player")
        {
            if (health == maxhealth)
            {
                healthslider.gameObject.SetActive(false);
            }
            else
            {
                healthslider.gameObject.SetActive(true);
            }
        }
        if (gameObject.tag == "Player")
        {
            playerHpText.text = health + " / " + maxhealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag == "Player")
        {
            if (collision.tag == "HealthBuff")
            {
                currentHealth += 5;
                if (currentHealth >= maxHealth)
                {
                    currentHealth = maxHealth;
                }
                SetHealth(currentHealth, maxHealth);
                Destroy(collision.gameObject);
            }
        }
    }
}
