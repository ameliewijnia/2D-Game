using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endofLevel1 : MonoBehaviour
{
    private AudioSource finishSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
       finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            finishSoundEffect.Play();
            CompletedLevel();
        }
    }

    private void CompletedLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         
    }

}
