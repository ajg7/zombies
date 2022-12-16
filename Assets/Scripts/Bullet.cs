using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    IObjectPool<Bullet> pool;
    [SerializeField] private Vector3 speed;
    Score score = new Score();

    private void Start()
    {
        score.KillCount = 0;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        pool?.Release(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            score.KillCount += 1;
            pool?.Release(this);
        }
    }

    public void SetPool(IObjectPool<Bullet> pool)
    {
        this.pool = pool;
    }
}
