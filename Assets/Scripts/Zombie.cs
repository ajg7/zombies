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
    ParticleSystem blood;

    private void Start()
    {
        anim = GetComponent<Animator>();
        blood = GetComponent<ParticleSystem>();
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
            blood.Play();
        }
    }

    public void SetZombiePool(IObjectPool<Zombie> zombiePool)
    {
        this.zombiePool = zombiePool;
    }
}
