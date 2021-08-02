using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")] [SerializeField] float speedRegulator=30f;
    [Tooltip("How far ship can move horizontally")] [SerializeField] float xRange = 10f;
    [Tooltip("How far ship can move vertically")] [SerializeField] float yRange = 7f;

    [Header("Laser gun array")]
    [Tooltip("Array containing all lasers attached to the player ship.")] [SerializeField] GameObject[] lasers;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -15f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    private void SetLasersActive(bool status)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = status;
        }
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * speedRegulator;
        float xNewPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(xNewPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * speedRegulator;
        float yNewPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(yNewPos, -yRange, yRange);

        transform.localPosition = new Vector3
             (clampedXPos, clampedYPos, transform.localPosition.z);
    }
    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float rollDueToControlThrow = xThrow * controlRollFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;  //x rotation
        float yaw = yawDueToPosition;                               //y rotation
        float roll = rollDueToControlThrow;                         //z rotation
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

}
 