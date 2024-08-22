using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JoystickPlayerExample : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public float walkSpeed;
    public float jumpSpeed;
    public VariableJoystick variableJoystick;

    
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    public int magazineSize = 10;
    public int reloadCount = 3;
    private int currentBullets;
    private int currentReloads;
    public TextMeshProUGUI ammoDisplay;
    private bool isJumping;
    public float gravityScale = 2f;
    private float originalGravityScale;

    int detected;
    public static Vector2 targetToHit;
    public static List<GameObject> Targets = new List<GameObject>();
    private void Start()
    {
        Targets.Clear();
        originalGravityScale = rb.gravityScale;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentBullets = magazineSize;   
        currentReloads = reloadCount;
        UpdateAmmoDisplay();
    }
    public void FixedUpdate()
    {
        Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;
        rb.AddForce(direction * walkSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
    private void Update()
    {
        if (Targets.Count > 0)
        {
            targetToHit = Targets[0].transform.position;
        }


        if (variableJoystick.isWalking)
        {
            animator.SetBool("Walk", true);
        }
        else
            animator.SetBool("Walk", false);
    }
    public void ShootAnimation()
    {
      animator.SetTrigger("shoot");  
    }
  
    public void Jump()
    {
        if (!isJumping)
        {
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            rb.gravityScale = gravityScale;  // Increase gravity to make the character fall faster
            isJumping = true;
        }
    }
    public void Shoot()
    {
        StartCoroutine(shootSelection());
    }
    IEnumerator shootSelection()
    {
        if (currentReloads > 0 || currentBullets > 0)
            if (!Manager.isBrust)
            {
                currentBullets--;
                if (currentBullets <= 0)
                {
                    Reload();
                }
                Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.Pistol);
                Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

                yield return null;
                UpdateAmmoDisplay();
            }
            else
            {
                currentBullets -= 5;
                if (currentBullets <= 0)
                {
                    Reload();
                }
                Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.ShotGun);

                for (int i = 0; i < 5; i++)
                {
                    Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
                    yield return new WaitForSecondsRealtime(0.02f);
                }
                UpdateAmmoDisplay();
            }
    }
    void Reload()
    {
        if (currentReloads > 0 && currentBullets <= 0)
        {
            currentBullets = magazineSize + currentBullets;
            currentReloads--;            
            Debug.Log("Reloaded");
        }
        else if (currentReloads == 0)
        {
            currentBullets = 0;
        }
    }
    void UpdateAmmoDisplay()
    {
        ammoDisplay.text = currentBullets + "/" + currentReloads;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            rb.gravityScale = originalGravityScale;  // Restore the original gravity scale
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        string layerName = LayerMask.LayerToName(layer);
        if (layerName == "CanDamage")
        {
            Targets.Add(collision.gameObject);
            detected++;
            print("Detected no: " + detected);
           // collision.GetComponent<DetectBullet>().TakeDamage();
        }
    }
}
