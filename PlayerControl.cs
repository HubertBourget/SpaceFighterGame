using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl: MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float controlSpeed = 10f;
    [Tooltip("How fast player moves horizontally")][SerializeField] float xRange = 9f;
    [Tooltip("How fast player moves vertically")][SerializeField] float yRange = 7f;
    [SerializeField] GameObject[] lasers;

    [Header("Screen position based Tuning")]
    [Tooltip("Add all player laser here")]
    [SerializeField]float positionPitchFactor = -2f;
    [SerializeField]float positionYawFactor = 2f;
    [Header("Player input based tuning")]
    [SerializeField]float controlRollFactor = -20f;
     [SerializeField]float controlPithFactor = -15f;
    float xThrow;
    float yThrow;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }
    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrust = yThrow * controlPithFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrust;

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow *controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3
        (clampedXPos,
         clampedYPos,
          transform.localPosition.z);
    }
    void ProcessFiring()
    {
        if(Input.GetButton("Jump"))
        {
            SetLaserActive(true);
        }
        else
        {
            SetLaserActive(false);
        }
    }
    void SetLaserActive(bool isActive)
    {
                foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
