using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator myAnimator;
    private bool lookright;
    private bool isgrounded;
    private float n;

    public float velocity;
    public float hiz;
    public GameObject Ball;
    public float ballspeed;
    public GameObject player;
    public float h;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        lookright = true;
        isgrounded = false;
        n = 0;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            n = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            n = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            n = -1;
        }
        TemelHareketler(n);
        YonCevir(n);
        if (player.transform.position.y < h)
        {
            isgrounded = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isgrounded)
        {
            rb.velocity = Vector2.up * velocity;
            isgrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            StartCoroutine(SpawnBullet());
        }
    }
    private void TemelHareketler(float yatay){
        rb.velocity=new Vector2(n*hiz,rb.velocity.y);
        myAnimator.SetFloat("karakterHizi",Mathf.Abs(n));
    }
    private void YonCevir(float yatay)
    {
        if (n < 0 && !lookright || n > 0 && lookright)
        {
            lookright = !lookright;
            Vector3 yon = transform.localScale;
            yon.x *= -1;
            transform.localScale = yon;
        }
    }
    private IEnumerator SpawnBullet()
    {
        GameObject ball = Instantiate(Ball);
        ball.transform.position = new Vector2(player.transform.position.x + (lookright ? -0.5f : 0.5f), player.transform.position.y);
        if (lookright)
        {
            ball.GetComponent<Rigidbody2D>().velocity = -transform.right * ballspeed;
        }
        else
        {
            ball.GetComponent<Rigidbody2D>().velocity = transform.right * ballspeed;
        }

        yield break;
    }
}
