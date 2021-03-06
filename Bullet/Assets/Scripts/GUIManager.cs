﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bullet.UI
{
    public class GUIManager : MonoBehaviour
    {
        [SerializeField]
        private Player.PlayerController player;
        [SerializeField]
        private Text score;
        [SerializeField]
        private Image[] textImages;
        [SerializeField]
        private Sprite[] numberSprites;

        void FixedUpdate()
        {
            score.text = player.score.ToString();
            //SetScoreImage(player.score);
        }

        void SetScoreImage(int score)
        {
            textImages[0].sprite = numberSprites[(int)Mathf.Floor(score / 1000)];
            textImages[1].sprite = numberSprites[(int)Mathf.Floor(score / 100)];
            textImages[2].sprite = numberSprites[(int)Mathf.Floor(score / 10)];
            textImages[3].sprite = numberSprites[score % 10];

            if (score < 0)
            {
                for (int i = 0; i < textImages.Length; ++i)
                {
                    textImages[i].sprite = numberSprites[0];
                }
            }
            else if (score > 9 && score < 100)
            {
                textImages[0].sprite = numberSprites[0];
                textImages[1].sprite = numberSprites[0];
            }
            else if (score > 99 && score < 1000)
            {
                textImages[0].sprite = numberSprites[0];
            }
            else if (score >= 9999)
            {
                textImages[0].sprite = numberSprites[9];
                textImages[1].sprite = numberSprites[9];
                textImages[2].sprite = numberSprites[9];
                textImages[3].sprite = numberSprites[9];
            }
        }
    }
}
