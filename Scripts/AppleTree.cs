using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
   [Header("Set in Inspector")]
   //щаблон дл€ создани€ €блок
   public GameObject applePrefab;

   // скорость жвижени€ €блони
   private float speed = 10f;

   // рассто€ние, на котором должно измен€тьс€ направление движени€ €блони
   private float leftAndRightEdge = 25f;

   // веро€тность случайного изменени€ направлени€ движени€
   private float chanceToChangeDirections = 0.02f;

   // частота создани€ экземпл€ров €блок
   public float secondsBetweenAppleDrops = 1f;

   // Start is called before the first frame update
   void Start()
   {
      Invoke("DropApple", 2f);
   }

   // Update is called once per frame
   void Update()
   {
      Vector3 pos = transform.position;
      pos.x += speed * Time.deltaTime;
      transform.position = pos;

      if (pos.x < -leftAndRightEdge)
      {
         speed = Mathf.Abs(speed);
      }
      else if (pos.x > leftAndRightEdge)
      {
         speed = -Mathf.Abs(speed);
      }
   }

   private void FixedUpdate()
   {
      if (Random.value < chanceToChangeDirections)
      {
         speed *= -1;
      }
   }

   void DropApple()
   {
      GameObject apple = Instantiate<GameObject>(applePrefab);
      apple.transform.position = transform.position;
      Invoke("DropApple", secondsBetweenAppleDrops);
   }
}
