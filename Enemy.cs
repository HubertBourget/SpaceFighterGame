using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scoreIncreaseOnKill;
    [SerializeField] int scoreIncreaseOnHit;
    [SerializeField] int hitPoints = 3;

    ScoreBoard ScoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        ScoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <1)
        {
            KillEnnemy();
        }
        
    }
    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints--;
        ScoreBoard.IncreaseScore(scoreIncreaseOnHit);
    }
    void KillEnnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
        ScoreBoard.IncreaseScore(scoreIncreaseOnKill);
    }


}
