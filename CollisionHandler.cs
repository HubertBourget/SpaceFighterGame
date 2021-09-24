using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem deathExplosionParticles;
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log(this.name + "-- Collided with--" + other.gameObject.name);
    }
    void OnTriggerEnter(Collider other) 
    {
        StartCrashSequence();
        Debug.Log(other.name);
    }

    void StartCrashSequence()
    {
        deathExplosionParticles.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerControl>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
