using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunAim : MonoBehaviour
{
    private Transform aimTransform;
    public Transform gunTransform;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private SpriteRenderer spriteRenderer;

    private float bulletForce = 5f;
    private float shootDelay = 1.0f; // Delay in seconds
    private bool canShoot = true; // Flag to control shooting delay
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        spriteRenderer = gunTransform.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aiming();
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shooting();
            StartCoroutine(ShootWithDelay());
        }
    }
    void Aiming()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 aimDirection = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        
        if (mousePos.x < transform.position.x)
        {
            spriteRenderer.flipY = true; // Flip the sprite horizontally
        }
        else
        {
            spriteRenderer.flipY = false; // Don't flip the sprite
        }
    }
    IEnumerator ShootWithDelay()
    {
        canShoot = false; // Disable shooting temporarily
        yield return new WaitForSeconds(shootDelay); // Wait for the specified delay
        canShoot = true; // Enable shooting again
    }
    void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
