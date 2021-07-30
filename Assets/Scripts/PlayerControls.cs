using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float speedRegulator=15f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow* Time.deltaTime*speedRegulator;
        float xNewPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(xNewPos,-xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * speedRegulator;
        float yNewPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(yNewPos, -yRange, yRange);

       transform.localPosition = new Vector3
            (clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
 