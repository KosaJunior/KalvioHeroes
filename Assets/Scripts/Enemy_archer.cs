using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_archer : MonoBehaviour
{
    public GameObject target, arrow;
    public Transform arrowSpawnPosition;
    Vector3 targetPos;
    public int enemyHP = 6;
    public bool shoot = false, created;
    public float InstantiationTimer = 1.8f, distanceToTarget = 1.3f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            Attack(target);
        else
            GetComponent<Animator>().SetBool("atak", false);
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
        {
            target = player.gameObject;
            GetComponent<Animator>().SetBool("atak", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null)
            target = null;
    }

    public void Attack(GameObject target)
    {
        targetPos = new Vector2(target.transform.position.x, target.transform.position.y);

        if (Vector2.Distance(transform.position, targetPos) > distanceToTarget)
        {
            GetComponent<Animator>().SetBool("fist_atak", false);
            InstantiationTimer -= Time.deltaTime;

            if (shoot && !created)
            {
                Instantiate(arrow, arrowSpawnPosition.position, arrowSpawnPosition.rotation);
                created = true;
            }

            if (InstantiationTimer <= 0)
            {
                created = false;
                InstantiationTimer = 1.8f;
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("fist_atak", true);
        }

    }
}