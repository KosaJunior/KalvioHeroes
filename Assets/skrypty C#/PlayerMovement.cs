using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    private Animator animacja;
    private GameObject otherGO;
    public Texture2D intTex;
    public bool canMove = true;

    // -------------------------------------czy postać stoi na ziemii i może skakać
    private bool m_Grounded = false;
    bool canJump;

    //-----------------------------------------szybkość poruszania się i siła skoku
    public float m_Speed;
    public float m_JumpForce;

    // Use this for initialization
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>() as Rigidbody2D;
        animacja = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
            Animating();
        else return;
    }

    // LateUpdate is called after Update()
    void LateUpdate()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            animacja.SetBool("is_pressed", false);
    }

    void FixedUpdate()
    {
        if (canMove)
            PlayerSteering();
        else return;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Skakanie
        if (other.GetComponent<Collider2D>().tag.Contains("Jumpable"))
        {
            m_Grounded = true;
            animacja.SetBool("in_air", false);
        }

        // Powiadom o punkcie interakcji
        if (other.GetComponent<Collider2D>().tag.Contains("interactable"))
        {
            GameObject.Find("interest_point").GetComponent<SpriteRenderer>().enabled = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Skakanie OFF
        if (other.GetComponent<Collider2D>().tag.Contains("Jumpable"))
        {
            m_Grounded = false;
            animacja.SetBool("in_air", true);
        }

        // Powiadom o punkcie interakcji
        if (other.GetComponent<Collider2D>().tag.Contains("interactable"))
        {
            GameObject.Find("interest_point").GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void Animating()
    {
        //----------------------------------------------- Walk left/right animation
        if (Input.GetAxis("Horizontal") != 0)
        {
            animacja.SetBool("is_pressed", true);

            if (Input.GetAxis("Horizontal") > 0)
            {
                animacja.SetBool("walk_right", true);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                animacja.SetBool("walk_left", true);
            }
        }
        else
        {
            animacja.SetBool("walk_left", false);
            animacja.SetBool("walk_right", false);
        }
        //-------------------------------------------------------------------------

        //----------------------------------------------------- Crouching animation
        if (Input.GetAxis("Vertical") < 0)
        {
            animacja.SetBool("is_pressed", true);
            animacja.SetBool("crouch", true);
        }
        else
        {
            animacja.SetBool("crouch", false);
        }
        //-------------------------------------------------------------------------

        //------------------------------------------------------- Jumping animation
        if (Input.GetButton("Jump"))
        {
            animacja.SetBool("jump", true);
        }
        else
        {
            animacja.SetBool("jump", false);
        }
        //-------------------------------------------------------------------------
    }

    void PlayerSteering()
    {
        {
            if (Input.GetButton("Horizontal"))
                m_Rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * m_Speed, m_Rigidbody.velocity.y);

            if (Input.GetButton("Jump") && m_Grounded && canJump)
                m_Rigidbody.AddForce(new Vector2(0, Input.GetAxis("Jump") * m_JumpForce));

            if (Input.GetAxis("Vertical") < 0)
            {
                canJump = false;
                m_Rigidbody.velocity = new Vector2(0, m_Rigidbody.velocity.y);
            }
            else
                canJump = true;

            // Atak
            if (Input.GetKeyDown("f"))
                animacja.GetComponent<Animator>().SetBool("atak", true);
            else
                animacja.GetComponent<Animator>().SetBool("atak", false);

            // Blok
            if (Input.GetKey("r") && m_Grounded)
            {
                animacja.GetComponent<Animator>().SetBool("blok", true);
                GetComponent<playerStats>().isBlocking = true;
                m_Rigidbody.velocity = new Vector2(0, 0);
            }
            else
            {
                animacja.GetComponent<Animator>().SetBool("blok", false);
                GetComponent<playerStats>().isBlocking = false;
            }
        }
    }
}
