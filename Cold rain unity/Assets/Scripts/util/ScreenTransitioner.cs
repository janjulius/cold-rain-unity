﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.util
{
    public class ScreenTransitioner : Node
    {
        public Animator Transition;
        public float transitionTime = 1f;
        public int sceneToLoad;

        public IEnumerator LoadLevel(int levelIndex)
        {
            Transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(levelIndex);
        }

        public IEnumerator FadeScreen(float time)
        {
            Transition.SetTrigger("Start");
            yield return new WaitForSeconds(time);
            Transition.SetTrigger("End");
        }

        public IEnumerator FadeScreenWarp(float time, Player player, int SceneId, Vector2 endlocation)
        {
            Transition.SetTrigger("Start");
            yield return new WaitForSeconds(1f);
            player.LoadIntoScene(SceneId, endlocation);
            yield return new WaitForSeconds(time);
            Transition.SetTrigger("End");
        }
    }
}