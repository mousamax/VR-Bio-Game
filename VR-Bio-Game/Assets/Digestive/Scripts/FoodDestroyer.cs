using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigestiveSystem
{
    public class FoodDestroyer : MonoBehaviour
    {

        public GameObject MinimumY;
        

        // Update is called once per frame
        void Update()
        {
            if (this.gameObject.transform.position.y < MinimumY.transform.position.y && !this.CompareTag("Protein"))
            {
                DigestiveScore.Score += 1;
                GameManager._gameManager.ChangeStatus(1, 1);
                GameManager._gameManager.InstantiateScore(this.gameObject.transform, 1);
                Destroy(this.gameObject);
            }
            if (this.gameObject.transform.position.y < MinimumY.transform.position.y && this.CompareTag("Protein"))
            {
                DigestiveScore.Score -= 1;
                GameManager._gameManager.ChangeStatus(1, -1);
                GameManager._gameManager.InstantiateScore(this.gameObject.transform, -1);
                Destroy(this.gameObject);

            }
        }
    }
}
