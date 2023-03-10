using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_life : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] AudioSource deathSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
       animator = GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
