using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For Game Over Text
using TMPro;

//For Restart Button to work
using UnityEngine.SceneManagement;

//For Restart Button to appear
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Tooltip("For spawning objects")]
    public List<GameObject>targets;

    private float spawnRate = 3.0f;

    [Tooltip("Playing Background Music")]
    private new AudioSource audio;

    public TextMeshProUGUI gameOverText;

    [Tooltip("To Stop the spawning of spheres")]
    public bool isGameActive;

    public Button restartButton;

    [Tooltip("Accessing titleScreen.To deactive it")]
    public GameObject titleScreen;

    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

   IEnumerator SpawnTarget()
   {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,targets.Count);
            Instantiate(targets[index]);
        }   
   }

   public void GameOver()
   {
    isGameActive = false;
    gameOverText.gameObject.SetActive(true);
    restartButton.gameObject.SetActive(true);
   }

   public void RestartGame()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void StartGame(int difficulty)
   {
        spawnRate/=difficulty;
        titleScreen.SetActive(false);
        isGameActive = true;
        StartCoroutine(SpawnTarget());
   }
    
}
