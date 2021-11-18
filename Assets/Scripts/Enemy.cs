using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 10;
    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidbody();
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
        if (hitPoints <= 0) {
            ProcessKill();
        }
    }

    void ProcessHit()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        hitPoints--;
    }

    void ProcessKill()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
