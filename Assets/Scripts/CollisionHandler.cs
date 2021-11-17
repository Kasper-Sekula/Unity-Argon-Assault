using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;
    void OnCollisionEnter(Collision other) {
        Debug.Log(this.name + " -- " + other.gameObject.name);
        ProccessCrash();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} ** {other.gameObject.name}");
        ProccessCrash();
    }

    void ProccessCrash()
    {
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponentInChildren<Collider>();
        
        //GetComponent<Collider>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
