using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float upForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radius;
    private Rigidbody2D dinoRb;
    private Animator dinoAnimator;
    public GameObject SoundJump;
    public GameObject SoundDead;
    void Start()
    {
        dinoRb = GetComponent<Rigidbody2D>();
        dinoAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, ground);
        dinoAnimator.SetBool ("isGrounded", isGrounded);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(SoundJump);
            if (isGrounded)
            {
                dinoRb.AddForce(Vector2.up * upForce);
            }
           
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Instantiate(SoundDead);
            gameManager.Instance.ShowGameOverScreen();
            dinoAnimator.SetTrigger("Die");
            Time.timeScale = 0f;
        }

    }
}


