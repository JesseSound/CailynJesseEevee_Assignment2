using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collections : MonoBehaviour
{
    public GameObject[] collectibles;

    public TextMeshProUGUI collectText;
    public GameObject[] keys;

    // Start is called before the first frame update
    void Start()
    {
        collectibles = new GameObject[0];
        collectText.text = collectibles.Length.ToString();
        keys = new GameObject[0];
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
        }else if (collision.CompareTag("key"))
        {
            AddToKeys(collision.gameObject);

            // Destroy the in-game copy of the key
            Destroy(collision.gameObject);
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
    private void AddToKeys(GameObject key)
    {
        // Create a new array with increased size
        GameObject[] newKeys = new GameObject[keys.Length + 1];

        // Copy existing keys to the new array
        for (int i = 0; i < keys.Length; i++)
        {
            newKeys[i] = keys[i];
        }

        // Add the new key to the array
        newKeys[newKeys.Length - 1] = key;

        // Update the keys array
        keys = newKeys;
    }
}
