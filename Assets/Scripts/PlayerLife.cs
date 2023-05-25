using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private bool dead = false;
    void Update()
    {
        if (!dead && transform.position.y < -7)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!dead && collision.gameObject.CompareTag("EnemyBody"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

    public void Die()
    {
        dead = true;
        Invoke(nameof(ReloadLevel), 1.2f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        dead = false;
    }
}
