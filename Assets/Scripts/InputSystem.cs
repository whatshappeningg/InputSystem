using UnityEngine;
using UnityEngine.UIElements;

public class InputSystem : MonoBehaviour
{
    public float playerSpeed = 5f;

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


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ejercicio1();
    }
}
