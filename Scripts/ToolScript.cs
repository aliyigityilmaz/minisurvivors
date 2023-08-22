using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToolScript : MonoBehaviour
{
    private float speed = 2.0f;
    private Health health;
    private GameObject player;
    public float rotationSpeed = 50f; // Adjust the rotation speed as needed

    private float distance = 0f; // Distance from the player to the object
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
            float rotationAngle = rotationSpeed * Time.deltaTime;
            // Rotate the object around the player
            transform.RotateAround(player.gameObject.transform.position, Vector3.forward, rotationAngle);
            // Move the object to its new position at the same distance from the player
            transform.position = player.gameObject.transform.position + (transform.position - player.gameObject.transform.position).normalized * distance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy0" || collision.tag == "Enemy1" || collision.tag == "Enemy2" || collision.tag == "Enemy3")
        {
            health = collision.gameObject.GetComponent<Health>();
            health.Damage(5);
        }
    }
}
