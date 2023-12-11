using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collections : MonoBehaviour
{
    GameObject[] collectibles;

    public TextMeshProUGUI collectText;

    // Start is called before the first frame update
    void Start()
    {
        collectibles = new GameObject[0];
        collectText.text = collectibles.Length.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("collectible"))
        {
            // Add the collided object to the array
            AddToCollectibles(collision.gameObject);

            // Destroy the in-game copy of the object
            Destroy(collision.gameObject);

            // Update counter
            collectText.text = collectibles.Length.ToString();
        }
    }

    private void AddToCollectibles(GameObject collectible)
    {
        // Create a new array with increased size
        GameObject[] newCollectibles = new GameObject[collectibles.Length + 1];

        // Copy existing collectibles to the new array
        for (int i = 0; i < collectibles.Length; i++)
        {
            newCollectibles[i] = collectibles[i];
        }

        // Add the new collectible to the array
        newCollectibles[newCollectibles.Length - 1] = collectible;

        // Update the collectibles array
        collectibles = newCollectibles;
    }

}
