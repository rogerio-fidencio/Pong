using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnePaddleControler : MonoBehaviour
{
    public float speed = 5f;
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer.color = SaveController.Instance.colorPlayerOne;
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");

        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        transform.position = newPosition;
    }

}
