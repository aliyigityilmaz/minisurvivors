using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private const float moveSpeed = 200f;
    private Rigidbody2D rb;
    private Vector3 moveDir;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Slider xpSlider;
    private float xpcount = 0;
    private float xpmax = 49;
    public int playerLevel;
    public AudioSource coincollect;
    public AudioSource levelUp;
    private GameObject inGameMenu;

    private bool skill1enabled, hasSkill1, skill2enabled, hasSkill2, skill3enabled, hasSkill3 = false;
    [SerializeField]
    private GameObject spearPrefab;
    [SerializeField]
    private GameObject scythePrefab;
    [SerializeField]
    private GameObject shovelPrefab;
    [SerializeField]
    private GameObject shovelPrefab2;

    private float timer = 0f;
    private float timerSpear = 2f;
    private float timer2 = 0f;
    private float timerShovel = 2f;
    // Start is called before the first frame update
    void Awake()
    {
        inGameMenu = GameObject.FindWithTag("inGameMenu");
        

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetXP();
    }
    private void Start()
    {
        playerLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SkillCheck();
        Movement();
        UpdateFacingDirection();
    }

    void Movement()
    {
        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
            animator.SetBool("isRunning", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
            animator.SetBool("isRunning", true);
        }
        moveDir = new Vector3 (moveX, moveY).normalized;
        animator.SetBool("isRunning", moveDir.magnitude > 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDir * Time.deltaTime * moveSpeed;
    }
    void UpdateFacingDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < transform.position.x)
        {
            spriteRenderer.flipX = true; // Flip the sprite horizontally
        }
        else
        {
            spriteRenderer.flipX = false; // Don't flip the sprite
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "exp0")
        {
            xpcount += 5;
            SetXP();
            coincollect.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "exp1")
        {
            xpcount += 12;
            SetXP();
            coincollect.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "exp2")
        {
            xpcount += 25;
            SetXP();
            coincollect.Play();
            Destroy(collision.gameObject);
        }
    }
    void SetXP()
    {
        xpSlider.value = xpcount / xpmax;
        if (xpcount >= xpmax)
        {
            levelUp.Play();
            playerLevel++;
            xpcount = 0;
            xpmax = xpmax + (xpmax / 10);
        }
    }

    void SkillCheck()
    {
        skill1enabled = inGameMenu.GetComponent<InGameMenu>().sickleSelected;
        skill2enabled = inGameMenu.GetComponent<InGameMenu>().shovelSelected;
        skill3enabled = inGameMenu.GetComponent<InGameMenu>().harrowSelected;

        if (skill1enabled && !hasSkill1)
        {
            Instantiate(scythePrefab, transform.position, Quaternion.identity);
            hasSkill1 = true;
        }
        if (skill3enabled && !hasSkill3)
        {
            hasSkill3 = true;
        }

        if (skill2enabled && !hasSkill2)
        {
            hasSkill2 = true;
        }

        if (hasSkill2)
        {
            timer2 += Time.deltaTime;

            if (spriteRenderer.flipX == true && timer2>=timerShovel)
            {
                Instantiate(shovelPrefab, new Vector3(transform.position.x - 3, transform.position.y, transform.position.z), Quaternion.identity);

                timer2 = 0;
            }
            if (spriteRenderer.flipX == false && timer2 >= timerShovel)
            {
                Instantiate(shovelPrefab2, new Vector3(transform.position.x + 3, transform.position.y, transform.position.z), Quaternion.identity);
                timer2 = 0;
            }
        }



        if (hasSkill3)
        {
            timer += Time.deltaTime;
            if (timer>=timerSpear)
            {
                Instantiate(spearPrefab, transform.position, Quaternion.identity);
                timer = 0;
            }
        }
    }
}
