using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float speedRegulator=15f;

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

        float yOffset = yThrow * Time.deltaTime * speedRegulator;
        float yNewPos = transform.localPosition.y + yOffset;

       transform.localPosition = new Vector3
            (xNewPos, yNewPos, transform.localPosition.z);
    }
}
 