using System;
using UnityEngine;
using UnityEngine.UIElements;

public class InputSystem : MonoBehaviour
{
    public float playerSpeed = 5f;
    public Transform cameraTransform;

    void Ejercicio1()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float offsetY;

        if (Input.GetButton("Fire3"))
        {
            playerSpeed += 1f * Time.deltaTime;
            float amplitude = 0.05f;
            float frequency = 4f;

            offsetY = transform.position.y + Mathf.Sin(Time.time * frequency) * amplitude;

        }
        else
        {
            playerSpeed = 5f;
            offsetY = 0.5f;
        }

        Vector3 movement = new Vector3(x, 0f, z) * playerSpeed * Time.deltaTime;
        transform.position += movement;

        transform.position = new Vector3(
        transform.position.x,
        offsetY,
        transform.position.z);
    }

    void Ejercicio2()
    {
        float zoomSpeed = 4;
        float rotationSpeed = 25;
        float maxDistance = 6f;
        float minDistance = 2f;
        float distance;

        if (Input.GetKey(KeyCode.Q))
        {
            cameraTransform.LookAt(transform.position);
            cameraTransform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed * -1);
            cameraTransform.Translate(cameraTransform.forward * Input.GetAxis("Vertical") * Time.deltaTime * zoomSpeed);

            distance = Math.Clamp(Vector3.Distance(transform.position, cameraTransform.position), minDistance, maxDistance);
            Vector3 dir = (cameraTransform.position - transform.position).normalized;
            cameraTransform.position = transform.position + dir * distance;
        }
        else
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed);
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed);
        }

    }

    void Ejercicio3()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0) transform.position = new Vector3(transform.position.x + 1, transform.position.y);
            else transform.position = new Vector3(transform.position.x - 1, transform.position.y);
        }
        if (Input.GetButtonUp("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0) transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            else transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            transform.position = new Vector3(0, 0.5f, 0);
        }

    }

    void Start()
    {

    }

    void Update()
    {
        Ejercicio3();
    }

}
