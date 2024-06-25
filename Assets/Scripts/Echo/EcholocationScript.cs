using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EcholocationScript : MonoBehaviour
{
    [SerializeField] private GameObject echoPoint;

    [SerializeField] private float range = 100f; // Range of the raycast
    [SerializeField] private GameObject hitEffectPrefab; // Prefab to spawn at hit point

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to your preferred input
        {
            Shoot();
        }
    }

    void Shoot()
    {
        int pellets = 100; // Number of rays/pellets
        float spreadAngle = 0.25f; // Spread angle in degrees
        RaycastHit hit;

        for (int i = 0; i < pellets; i++)
        {
            Vector3 rayOrigin = transform.position;
            Vector3 rayDirection = CalculateSpreadDirection(transform.forward, spreadAngle);

            // Draw the ray in the Scene view
            Debug.DrawRay(rayOrigin, rayDirection * range, Color.red, 2f); // Red ray for 2 seconds

            if (Physics.Raycast(rayOrigin, rayDirection, out hit, range))
            {
                Debug.Log("Hit: " + hit.transform.name); // Log the name of the object hit

                // Instantiate hit effect at the hit point
                if (hitEffectPrefab != null)
                {
                    GameObject hitEffectInstance = Instantiate(hitEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(hitEffectInstance, 5f);
                    hitEffectInstance.gameObject.GetComponent<Renderer>().material.DOFade(0, 1f);
                }
            }
        }
    }

    Vector3 CalculateSpreadDirection(Vector3 forward, float spreadAngle)
    {
        // Randomly spread the direction within the specified angle
        float spreadX = Random.Range(-spreadAngle, spreadAngle);
        float spreadY = Random.Range(-spreadAngle, spreadAngle);

        // Calculate the spread direction
        Vector3 spreadDirection = forward + new Vector3(spreadX, spreadY, 0);
        return spreadDirection.normalized;
    }
}
