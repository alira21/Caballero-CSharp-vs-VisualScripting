using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 4f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private Vector2 mov;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var teclado = Keyboard.current;
        mov = Vector2.zero;

        if (teclado.leftArrowKey.isPressed) mov.x = -1;
        if (teclado.rightArrowKey.isPressed) mov.x = 1;
        if (teclado.upArrowKey.isPressed) mov.y = 1;
        if (teclado.downArrowKey.isPressed) mov.y = -1;

        mov = mov.normalized; // En diagonal no va más rápido

        if (mov.x != 0) sr.flipX = mov.x < 0; // Mira hacia donde camina

        if (anim != null) anim.SetFloat("Velocidad", mov.magnitude);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = mov * velocidad;
    }
}