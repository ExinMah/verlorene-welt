using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public GameObject firePrefab; //drag the fire prefeb

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Start the fire at the specified position
    public void StartFire(Vector3 position)
    {
        GameObject Fire = Instantiate(firePrefab, position, Quaternion.identity); // Create a new fire GameObject
        Fire.transform.parent = transform; // Set the fire's parent to the current GameObject (optional)
    }

    // Stop the fire at the specified position
    public void StopFire(Vector3 position)
    {
        // Find the fire GameObject at the specified position
        GameObject Fire = FindFireAtPosition(position);
        if (Fire != null)
        {
            // Destroy the fire GameObject
            Destroy(Fire);
        }
    }

    // Find the fire GameObject at the specified position
    private GameObject FindFireAtPosition(Vector3 position)
    {
        // Find all fire GameObjects in the scene
        GameObject[] fires = GameObject.FindGameObjectsWithTag("Fire");
        // Check each fire GameObject to see if it is at the specified position
        foreach (GameObject Fire in fires)
        {
            if (Fire.transform.position == position)
            {
                return Fire;
            }
        }
        // Return null if no fire was found at the specified position
        return null;
    }
}
