using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public int mushroomsNeeded = 10; // Số lượng nấm cần thiết để qua màn

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (MushroomManager.instance.HasCollectedEnoughMushrooms(mushroomsNeeded))
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
