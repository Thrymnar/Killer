using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    //private Animator attack;
    //private Animator can;
    private Animator tullanma;
    private bool sagabak;
    private bool isgrounded;

    public float velocity;
    public float hiz;
    public GameObject Ball;
    public float ballspeed;
    public GameObject player;
    public float h;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        //attack = GetComponent<Animator>();
        //can = GetComponent<Animator>();
        tullanma = GetComponent<Animator>();
        sagabak = true;
        isgrounded = false;
    }

    void Update()
    {
        float yatay=Input.GetAxis("Horizontal");
        TemelHareketler(yatay);
        YonCevir(yatay);
        if (player.transform.position.y < h)
        {
            isgrounded = true;
        }
        if (Input.GetKeyDown(KeyCode.W) && isgrounded)
        {
            myRigidbody.velocity = Vector2.up * velocity;
            isgrounded = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SpawnBullet());
        }
        Debug.Log(yatay);
    }
    private void TemelHareketler(float yatay){
        myRigidbody.velocity=new Vector2(yatay*hiz,myRigidbody.velocity.y);
        myAnimator.SetFloat("karakterHizi",Mathf.Abs(yatay));
    }
    private void YonCevir(float yatay)
    {
        if (yatay > 0 && !sagabak || yatay < 0 && sagabak)
        {
            sagabak = !sagabak;
            Vector3 yon = transform.localScale;
            yon.x *= -1;
            transform.localScale = yon;
        }
    }
    private IEnumerator SpawnBullet()
    {
        GameObject ball = Instantiate(Ball);
        ball.transform.position = new Vector2(player.transform.position.x + (sagabak ? 0.5f : -0.5f), player.transform.position.y);
        if (sagabak)
        {
            ball.GetComponent<Rigidbody2D>().velocity = transform.right * ballspeed;
        }
        else
        {
            ball.GetComponent<Rigidbody2D>().velocity = -transform.right * ballspeed;
        }

        yield break;
    }
}
