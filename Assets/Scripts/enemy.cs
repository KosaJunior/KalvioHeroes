using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject target;
    Vector3 targetPos;
    public int enemyHP = 6, moveSpeed = 1;
    public float distanceToTarget = 1;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
            Follow(target);
        else
        {
            GetComponent<Animator>().SetBool("walk_left", false);
            GetComponent<Animator>().SetBool("walk_right", false);
        }
    }

    void LateUpdate()
    {
        if (enemyHP <= 0)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "atak_collider")
            enemyHP--;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null)
            target = player.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null)
            target = null;
    }

    void Follow(GameObject target)
    {
        targetPos = new Vector2(target.transform.position.x, target.transform.position.y);

        if (Vector2.Distance(transform.position, targetPos) > distanceToTarget)
        {
            Vector2 direction = targetPos - transform.position;
            direction.Normalize();

            if (GetComponent<Rigidbody2D>().velocity.x < 0)
                GetComponent<Animator>().SetBool("walk_left", true);
            else if (GetComponent<Rigidbody2D>().velocity.x > 0)
                GetComponent<Animator>().SetBool("walk_right", true);
            
            GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
        }

        if (Vector2.Distance(transform.position, targetPos) <= distanceToTarget)
        {
            GetComponent<Animator>().SetBool("atak", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("atak", false);
        }
    }
}
