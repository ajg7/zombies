using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawn : MonoBehaviour
{
    [SerializeField] Zombie zombie;
    [SerializeField] Transform spawnPointTransform;
    public ObjectPool<Zombie> zombiePool;

    private void Awake()
    {
        zombiePool = new ObjectPool<Zombie>(CreateZombie, OnGetZombie, onReleaseZombie, OnDestroyZombie, maxSize: 10);
    }

    void CleanUp()
    {
        Destroy(zombie.gameObject);
    }

    Zombie CreateZombie()
    {
        Zombie zombie = Instantiate(this.zombie, transform.position, Quaternion.identity);
        zombie.SetZombiePool(zombiePool);
        return zombie;
    }

    void OnGetZombie(Zombie zombie)
    {
        zombie.gameObject.SetActive(true);
    }

    void onReleaseZombie(Zombie zombie)
    {
        Invoke("CleanUp", 5f);
    }

    void OnDestroyZombie(Zombie zombie)
    {
        Destroy(zombie.gameObject);
    }

    private void Start()
    {
        InvokeRepeating("Spawnning", 3f, 3f);
    }
    void Spawnning()
    {
        zombiePool?.Get();
    }
}
