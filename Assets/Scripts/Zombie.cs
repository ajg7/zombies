using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class Zombie : MonoBehaviour
{
    [SerializeField] GameObject goal;
    Animator anim;
    [SerializeField] NavMeshAgent agent;
    IObjectPool<Zombie> zombiePool;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        agent.destination = goal.transform.position;
        agent.speed = 2f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            agent.isStopped = true;
            anim.SetBool("isDead", true);
            zombiePool?.Release(this);
        }
    }

    public void SetZombiePool(IObjectPool<Zombie> zombiePool)
    {
        this.zombiePool = zombiePool;
    }
}
