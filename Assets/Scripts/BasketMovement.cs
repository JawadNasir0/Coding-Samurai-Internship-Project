using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketMovement : MonoBehaviour
{
   private Rigidbody2D bucket;
   public float speed,xbound;
    void Start()
    {
        bucket= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
		if(x>0)
			bucket.velocity = Vector2.right * speed;
		else if(x<0)
			bucket.velocity = Vector2.left * speed;
		else
			bucket.velocity = Vector2.zero;
		
		transform.position = new Vector2(Mathf.Clamp(transform.position.x, -xbound , xbound),transform.position.y);
    }
}
