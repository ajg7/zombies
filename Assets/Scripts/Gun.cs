using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] float speed = 700f;
    ObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, onReleaseBullet, OnDestroyBullet, maxSize: 10);
    }

    Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(this.bullet, transform.position, Quaternion.identity);
        bullet.SetPool(bulletPool);
        return bullet;
    }

    void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, speed));
    }

    void onReleaseBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletPool?.Get();
        }
    }
}