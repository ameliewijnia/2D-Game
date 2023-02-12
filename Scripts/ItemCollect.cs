using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    private int strawberry = 0;
    [SerializeField] private Text strawberryText;
    [SerializeField] private AudioSource coinCollectEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Reward"))
        {
            coinCollectEffect.Play();
            Destroy(collision.gameObject);
            strawberry++;
            strawberryText.text = "Strawberry:" + strawberry;
        }
    }

    
}
