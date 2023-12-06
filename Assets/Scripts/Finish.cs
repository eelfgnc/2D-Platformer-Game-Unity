using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool levelCompleted = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            GeneralAudioManager audioManager = FindObjectOfType<GeneralAudioManager>();
            if (audioManager != null)
            {
                audioManager.PlayFinishSoundEffect();
            }
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }
    private void CompleteLevel()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex + 1;
        if (sceneNumber <= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }

}
