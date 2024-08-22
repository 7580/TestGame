using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class keepCamerainAxis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        // Clamp the x position between 0 and 26
        position.x = Mathf.Clamp(position.x, 0f, 26f);
        print(position);
        //if (position.x < 0f || position.x > 26f)
        //   GetComponent<PositionConstraint>().enabled = false;
        //else
        //    GetComponent<PositionConstraint>().isa = true;
        // Apply the clamped position back to the camera
        transform.position = position;
    }
}
