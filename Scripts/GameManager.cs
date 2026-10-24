using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public TextMeshProUGUI textoOro;
    public TextMeshProUGUI textoTiempo;
    public GameObject panelVictoria;
    public GameObject panelDerrota;
    public float tiempo = 60f; // Segundos para recolectar todo el oro

    private int oro = 0;
    private int total;
    private bool terminado = false;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        total = GameObject.FindGameObjectsWithTag("Oro").Length; // Cuenta el oro del mapa por tag
        ActualizarOro();
    }

    void Update()
    {
        if (terminado)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        tiempo -= Time.deltaTime;
        if (tiempo < 0) tiempo = 0;

        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.CeilToInt(tiempo % 60);
        if (segundos == 60) { minutos++; segundos = 0; }
        textoTiempo.text = "Tiempo: " + minutos + ":" + segundos.ToString("00");

        if (tiempo <= 0) Terminar(panelDerrota);
    }

    public void SumarOro()
    {
        if (terminado) return;
        oro++;
        ActualizarOro();
        if (oro >= total) Terminar(panelVictoria);
    }

    void ActualizarOro()
    {
        textoOro.text = "Oro: " + oro + " / " + total;
    }

    void Terminar(GameObject mensaje)
    {
        terminado = true;
        mensaje.SetActive(true);
        Time.timeScale = 0f; // Congela el juego
    }
}