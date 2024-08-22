//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class bullet : MonoBehaviour
//{

//    public float speed = 20f;
//    public int damage = 40;
//    public Rigidbody2D rb;
//   // public GameObject impactEffect;

//    // Use this for initialization
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        rb.velocity = transform.up * speed;
//        Destroy(gameObject, 1f);
//    }

//    void OnTriggerEnter2D(Collider2D hitInfo)
//    {
//        //Enemy enemy = hitInfo.GetComponent<Enemy>();
//        //if (enemy != null)
//        //{
//        //    enemy.TakeDamage(damage);
//        //}

//        //Instantiate(impactEffect, transform.position, transform.rotation);
//        int layer = hitInfo.gameObject.layer;
//        string layerName = LayerMask.LayerToName(layer);
//        if(layerName == "CanDamage")
//        {
//            hitInfo.GetComponent<DetectBullet>().TakeDamage();
//        }
//        Destroy(gameObject);
//    }

//}




using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    //    // Use this for initialization
    //    void Start()
    //    {
    //        rb = GetComponent<Rigidbody2D>();
    //        rb.velocity = transform.up * speed;
    //        Destroy(gameObject, 1f);
    //    }

    private Vector2 target;    // Target position

    private void Start()
    {
        if (JoystickPlayerExample.Targets.Count > 0)
        {
            target = JoystickPlayerExample.targetToHit;
            //SetTarget(JoystickPlayerExample.targetToHit);
            Destroy(gameObject, 1f);
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * speed;
            Destroy(gameObject, 1f);
        }
    }
    // Call this function to set the target for the bullet
    public void SetTarget(Vector2 targetPosition)
    {
        // Calculate the direction from the bullet's position to the target
        Vector2 direction = targetPosition - (Vector2)transform.position;

        // Calculate the angle to rotate the bullet to face the target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation so the bullet faces the target
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Now that it's rotated, the bullet will move in the direction it's facing
        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.up * speed;  // Moving in the bullet's up direction

        // Destroy the bullet after 1 second (optional)
       // Destroy(gameObject, 1f);
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
