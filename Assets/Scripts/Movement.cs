using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 2.5f;
    Animator anim;
    Vector3 input;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void AnimMoveDirection(float dir)
    {
        if (dir < 0)
        {
            anim.SetBool("isLeft", true);
            anim.SetBool("isStopped", false);
            anim.SetBool("isRight", false);
        } else if (dir > 0)
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isStopped", false);
            anim.SetBool("isRight", true);
        } else if (dir == 0)
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isStopped", true);
            anim.SetBool("isRight", false);
        }

    }


    private void FixedUpdate()
    {
        input = anim.GetBool("isDead") ? new Vector3(0, 0, 0) : new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        rb.MovePosition(transform.position + input * Time.deltaTime * speed);
        float direction = input.x;
        AnimMoveDirection(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            anim.SetBool("isDead", true);
        }
    }
}
