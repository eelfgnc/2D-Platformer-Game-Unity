using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text cherriestext;
    [SerializeField] private AudioSource collectSoundEffect;
    private int cherries = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriestext.text = "Cherries: " + cherries;
            Debug.Log("cheeries: " + cherries);
        }
    }
}
