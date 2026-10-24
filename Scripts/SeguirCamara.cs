using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    public Transform objetivo;
    public float suavizado = 5f;

    void LateUpdate()
    {
        Vector3 destino = new Vector3(objetivo.position.x, objetivo.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, destino, suavizado * Time.deltaTime);
    }
}