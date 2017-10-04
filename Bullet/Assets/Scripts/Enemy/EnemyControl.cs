﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet.Enemy
{
    public class EnemyControl : MonoBehaviour
    {

        public GameObject EnAudioObject;//<--Felipe(trigger audio on shot)
        [SerializeField]
        private GameObject explosionPrefab;
        public bool useSpeed;
        public float speed;
        [SerializeField]
        private float health = 100f;
        public float damage = 20f;

        [SerializeField]
        private bool isDown = true;

        [SerializeField]
        private PickUp pickupPrefab;
        [SerializeField]
        private float dropRatio; // 0 to 1

        // Use this for initialization
        void Start()
        {
            EnAudioObject = GameObject.Find("Audio3");
            //speed = 2f;
        }

        // Update is called once per frame
        void Update()
        {
            if (isDown)
            {
                Vector2 position = transform.position;
                if (useSpeed) {
                    position = new Vector2(position.x, position.y - speed * Time.deltaTime);

                    transform.position = position;
                }

                Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

                if (transform.position.y < min.y)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "PlayerBullet")
            {
                Damage(nPlayer.PlayerController.Instance.GetDamageAmount());
            }
            else if (col.tag == "PlayerShip")
            {
                Death();
            }
        }

        void Damage(float amount)
        {
            health -= amount;
            if (health <= 0) Death();
        }

        void Death()
        {
            PlayExplosion();
            SpawnPickup();
            Destroy(gameObject);
        }

        void PlayExplosion()
        {
            GameObject explosion = Instantiate(explosionPrefab);
            EnAudioObject.GetComponent<AudioScript3>().EnemyExplosion();//<--felipe
            explosion.transform.position = transform.position;
        }

        void SpawnPickup()
        {
            if (Random.Range(0,1f) <= dropRatio)
            {
                Instantiate(pickupPrefab, transform.position, transform.rotation);
            }
        }
    }
}
