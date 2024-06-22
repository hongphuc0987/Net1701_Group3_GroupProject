using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (MushroomManager.instance.HasCollectedEnoughMushrooms(10))
            {
                SceneController.instance.NextLevel();
            }
            else
            {
                UnityEngine.Debug.Log("Not enough mushrooms collected to proceed to the next level.");
            }
        }
    }
}

