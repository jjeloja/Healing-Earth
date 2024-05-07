using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : CollisionController
{
    public GameObject projectile;
    public float launchVelocity = 700f;
	  Transform attachmentPoint;

    void FixedUpdate()
    {

        if (Input.GetButtonDown("Fire1") && potions > 0)
        {
			GameObject ball = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);

            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, launchVelocity,0));
			Destroy(ball, 1.5f);
			potions--;
		}
    }
}
