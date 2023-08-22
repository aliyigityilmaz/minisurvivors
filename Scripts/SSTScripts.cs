using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSTScripts : MonoBehaviour
{
    private Health health;

    private float speed = 5f;

    public AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Spear")
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360f));
            Destroy(gameObject, 5f) ;
        }
        if (gameObject.tag == "Shovel")
        {
            
            Destroy(gameObject, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.tag == "Spear")
        {
            transform.Translate(Vector3.up * speed* Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy0" || collision.tag == "Enemy1" || collision.tag == "Enemy2" || collision.tag == "Enemy3")
        {
            health = collision.gameObject.GetComponent<Health>();
            health.Damage(5);
            hitSound.Play();
            if (this.gameObject.tag == "Spear" )
            {
                Destroy(this.gameObject);
            }
        }
    }
}
