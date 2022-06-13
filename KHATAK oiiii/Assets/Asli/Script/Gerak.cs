using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerak : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    public float jumpAmount = 10;
    private float horizontalInput;

    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;

    //tambahan
    [SerializeField] private Transform detectGround;
    [SerializeField] private LayerMask targetMask;//sesuaikan dengan mask tanah
    [SerializeField] private float radius=0.2f;//jarak pendeteksian tanah
    public bool isGrounded;


    private void Awake()
    {
        //ambil referens buad rigidbody sma animator dari object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(detectGround.transform.position, radius, targetMask);
        moving();
       
    }
    public void moving()
    {
        float horizontalInput = SimpleInput.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //flip kanan kiri
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.35f, 0.35f, 0.35f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            JUmpBtn();
        }

        //parameter animatornya
        anim.SetBool("isRunning", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded);
    }
    public void JUmpBtn()//utuk tombol ui lompat
    {
        if (isGrounded == true)
        {
            SoundManager.instance.PlaySound(jumpSound);
            Jump();
        }
    }
    public void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        //grounded = false;
        body.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //        grounded = true;
    //}
    public bool canAttack()
    {
        return horizontalInput == 0;
    }
}
