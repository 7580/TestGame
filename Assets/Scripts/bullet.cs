using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    private Vector2 target;    // Target position

    private void Start()
    {
        if (JoystickPlayerExample.Targets.Count > 0)
        {
            target = JoystickPlayerExample.targetToHit;
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * speed;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (JoystickPlayerExample.Targets.Count > 0)
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); 
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        int layer = hitInfo.gameObject.layer;
        string layerName = LayerMask.LayerToName(layer);
        if (layerName == "CanDamage")
        {
            hitInfo.GetComponent<DetectBullet>().TakeDamage();
            Destroy(gameObject);
        }
       
    }
}
