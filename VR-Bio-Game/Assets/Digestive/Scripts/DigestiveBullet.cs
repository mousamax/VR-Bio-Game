using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigestiveSystem
{


    public class DigestiveBullet : MonoBehaviour
    {

        [SerializeField] public float speed = 10f;
        //public GameObject collisionPrefabBlue;

        private float _prevoiusTime = 0;

        private void Update()
        {
            //moving the bullet 
            if (this.gameObject.activeSelf)
            {
                //transform.Translate(0, 0, -speed * Time.deltaTime);
                this.transform.position += this.transform.forward.normalized * speed * Time.deltaTime;
            }
            if (_prevoiusTime > 4)
            {
                this.gameObject.SetActive(false);
                _prevoiusTime = 0;
            }
            _prevoiusTime += Time.deltaTime;
        }
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("BloodCells"))
            {
                this.gameObject.SetActive(false);
            }
            if (collision.gameObject.CompareTag("Protein") )
            {
                this.gameObject.SetActive(false);
                DigestiveScore.Score += 1;
                GameManager._gameManager.ChangeStatus(1, 5);
                GameManager._gameManager.InstantiateScore(collision.gameObject.transform, 5);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Fats") || collision.gameObject.CompareTag("Carbs"))
            {
                this.gameObject.SetActive(false);
                DigestiveScore.Score -= 1;
                GameManager._gameManager.ChangeStatus(1, -1);
                GameManager._gameManager.InstantiateScore(collision.gameObject.transform, -1);
                Destroy(collision.gameObject);
            }
        }
    }
}

