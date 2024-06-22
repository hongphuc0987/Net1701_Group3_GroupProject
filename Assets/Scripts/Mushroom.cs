using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private MushroomManager mushroomManager;

    private void Start()
    {
        mushroomManager = MushroomManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            mushroomManager.ChangeMushrooms(value);
            Destroy(gameObject);
        }
    }
}
