using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBullet : MonoBehaviour
{

    public Animator animator;
    public GameObject miniRocks;
    int hits = 3;
    int currentHit;
    public ParticleSystem devilVfx;
    // Start is called before the first frame update
    void Start()
    {
        currentHit = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage()
    {
        currentHit++;
        if (gameObject.tag == "rock")
        {
            if (currentHit < hits)
            {
                animator.SetTrigger("alpha");
            }
            else
            {
                GameObject mini = Instantiate(miniRocks,gameObject.transform.parent);
                Destroy(mini,1f);
                Destroy(gameObject);
                JoystickPlayerExample.Targets.Remove(gameObject);
            }           
        }
        else if(gameObject.tag == "devil")
        {
            if (currentHit < hits)
            {
                transform.parent.GetComponent<Animator>().SetTrigger("damage");
            }
            else
            {
                transform.parent.GetComponent<Animator>().SetTrigger("die");
                Destroy(transform.parent.gameObject, 1f);
                JoystickPlayerExample.Targets.Remove(gameObject);
            }
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print(collision.collider.name);
    //    if (collision.collider.CompareTag("bullet"))
    //    {
    //        print("rafiqqqqqqqqq");
    //        if (gameObject.tag == "rock")
    //        {
    //            print("asfarrrrrrrrrrrrrrr");
    //            animator.SetTrigger("alpha");
    //        }
    //    }
    //}
}
