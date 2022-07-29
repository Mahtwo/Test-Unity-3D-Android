using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnPoint;
    int score = 0;

    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(0.75f, 1.5f);
            yield return new WaitForSeconds(waitTime);  // Wait between 0.75 and 1.5 seconds

            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameStart()
    {
        player.SetActive(true);  // Activate player
        playButton.SetActive(false);  // Desactivate play button

        StartCoroutine(nameof(SpawnObstacles));
        InvokeRepeating(nameof(ScoreUp), 2f, 1f);
    }
}
