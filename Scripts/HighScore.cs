using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
  static public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      Text gt = this.GetComponent<Text>();
      gt.text = "High Score: " + score;

      // обновить счет в хранилище если нужно
      if(score > PlayerPrefs.GetInt("HighScore"))
      {
         PlayerPrefs.SetInt("HighScore", score);
      }
    }

    void Awake()
   {
      if(PlayerPrefs.HasKey("HighScore"))
      {
         score = PlayerPrefs.GetInt("HighScore");
      }
      else
      PlayerPrefs.SetInt("HighScore", score);
   }
}
