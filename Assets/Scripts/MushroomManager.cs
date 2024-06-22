using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MushroomManager : MonoBehaviour
{
    public static MushroomManager instance;
    private int mushroom;
    [SerializeField] private TMP_Text mushroomDisplay;
    private int mushroomsCollected = 0; // Số lượng nấm đã thu thập

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Giữ MushroomManager khi chuyển cảnh
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnGUI()
    {
        mushroomDisplay.text = mushroom.ToString();
    }

    public void ChangeMushrooms(int amount)
    {
        mushroom += amount;
        mushroomsCollected += amount; // Tăng số lượng nấm đã thu thập
    }

    public bool HasCollectedEnoughMushrooms(int requiredMushrooms)
    {
        return mushroomsCollected >= requiredMushrooms;
    }
}

