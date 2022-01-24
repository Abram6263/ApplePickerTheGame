using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
   public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
      GameObject scoreGO = GameObject.Find("ScoreCounter");
      scoreGT = scoreGO.GetComponent<Text>();
      scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
      // получить положение мыши на экране 
      Vector3 mousePos2D = Input.mousePosition;
      mousePos2D.z = -Camera.main.transform.position.z;

      Vector3 mousePod3D = Camera.main.ScreenToWorldPoint(mousePos2D);

      Vector3 pos = this.transform.position;
      pos.x = mousePod3D.x;
      this.transform.position = pos;

    }

   private void OnCollisionEnter(Collision collision)
   {
      GameObject colidedWith = collision.gameObject;
      if(colidedWith.tag == "Apple")
      {
         Destroy(colidedWith);

         int score = int.Parse(scoreGT.text);
         score += 100;
         scoreGT.text = score.ToString();

         if(score > HighScore.score)
         {
            HighScore.score = score;
         }
      }
   }
}
