using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    GameObject parentGameObject;
    [SerializeField] int scoreToIncrease=20;
    [SerializeField] int hitPoints = 2;
    [SerializeField] int dealedDamage = 1;

    ScoreBoard scoreBoard;

    void Start()
    {
        AddRigidbody();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    } 

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints -= dealedDamage;
    }

    private void KillEnemy()
    {
        
        scoreBoard.IncreaseScore(scoreToIncrease);
        GameObject vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }


}
