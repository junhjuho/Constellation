using UnityEngine;

public class Observatory : MonoBehaviour
{
    public GameObject parentObject;
    public float rotationSpeed = 30f;

    private float currentSpeedMultiplier = 1f;
    private bool isButtonPressed = false;
    private float buttonPressTime = 0f;
    private float baseMultiplier = 1f;

    void Update()
    {
        if (parentObject)
        {
            parentObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * currentSpeedMultiplier * baseMultiplier);

            Debug.Log("Rotation Speed Multiplier: " + currentSpeedMultiplier); // temporal logging

            if (isButtonPressed)
            {
                buttonPressTime += Time.deltaTime;

                if (buttonPressTime > 3f)
                {
                    currentSpeedMultiplier = 10f;
                }
                else
                {
                    currentSpeedMultiplier = 3f;
                }
            }
            else
            {
                currentSpeedMultiplier = 1f;
            }
        }
    }

    public void OnArrowButtonPressed(bool isRight)
    {
        Debug.Log("Button Pressed. Direction: " + (isRight ? "Right" : "Left")); // temporal logging
        isButtonPressed = true;
        baseMultiplier = isRight ? 1f : -1f;
    }

    public void OnArrowButtonReleased()
    {
        Debug.Log("Button Released."); // temporal logging
        isButtonPressed = false;
        buttonPressTime = 0f;
        currentSpeedMultiplier = 1f;
    }
}