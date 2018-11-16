using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class controls : MonoBehaviour
{

    private bool canJump = true;
    private bool canDBJump = true;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce((transform.right * -1) * 15);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * 15);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump(250);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = new Vector3(0, 4, 0);
        }
    }

    void jump(int height)
    {
        if (canJump == true)
        {
            canJump = false;
            rb.AddForce(transform.up * height);
        }
        else if (canJump == false && canDBJump == true)
        {
            canDBJump = false;
            rb.AddForce(transform.up * height);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground" && Input.GetKey(KeyCode.Space) == false)
        {
            canJump = true;
            canDBJump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            canJump = false;
        }
    }
}