using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class InputSystem : MonoBehaviour
{
    // Public attributes
    public float playerSpeed = 5f;
    public float rotationSpeed = 90f;
    public Transform cameraTransform;

    // Private attributes
    private int _ejercicio = 0;
    private bool _start = true;
    private bool _input = false;
    private bool _win = false;
    private bool _lose = false;
    private char sequence = '\0';
    private char sequenceChosen = '\0';


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

    void Ejercicio4()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed);
    }

    void Ejercicio5()
    {
        char[] possibleInputs = { 'W', 'A', 'S', 'D' };

        if (_start)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
            sequence = possibleInputs[UnityEngine.Random.Range(0, possibleInputs.Length)];
            sequenceChosen = '\0';
            print("La siguiente tecla es " + sequence);
            print("Marca la tecla correcta...");

            _start = false;
            _input = true;
        }
        else if (_input)
        {
            if (sequenceChosen == '\0')
            {
                if (Input.GetKeyUp(KeyCode.W))
                { sequenceChosen = 'W'; transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1); }
                else if (Input.GetKeyUp(KeyCode.A))
                { sequenceChosen = 'A'; transform.position = new Vector3(transform.position.x - 1, transform.position.y); }
                else if (Input.GetKeyUp(KeyCode.S))
                { sequenceChosen = 'S'; transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1); }
                else if (Input.GetKeyUp(KeyCode.D))
                { sequenceChosen = 'D'; transform.position = new Vector3(transform.position.x + 1, transform.position.y); }
            }
            else
            {
                print("Tecla pulsada: " + sequenceChosen);
                _input = false;
                if (sequence == sequenceChosen) _win = true;
                else _lose = true;
            }
        }
        else if (_lose)
        {
            print("No es correcto :(, la tecla correcta era " + sequence);
            print("¡Juguemos otra vez!");
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            sequence = '\0';
            transform.position = new Vector3(0, 0.5f, 0);

            _lose = false;
            _start = true;
        }
        else if (_win)
        {
            print("¡Correcto!");
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            _win = false;
            _start = true;
        }

    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1)) _ejercicio = 1;
        else if (Input.GetKeyUp(KeyCode.Alpha2)) _ejercicio = 2;
        else if (Input.GetKeyUp(KeyCode.Alpha3)) _ejercicio = 3;
        else if (Input.GetKeyUp(KeyCode.Alpha4)) _ejercicio = 4;
        else if (Input.GetKeyUp(KeyCode.Alpha5)) _ejercicio = 5;

        switch (_ejercicio)
        {
            case 1:
                Ejercicio1();
                break;
            case 2:
                Ejercicio2();
                break;
            case 3:
                Ejercicio3();
                break;
            case 4:
                Ejercicio4();
                break;
            case 5:
                Ejercicio5();
                break;
            default:
                break;
        }
    }

}
