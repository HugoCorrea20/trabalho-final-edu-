using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimentoNavio : MonoBehaviour
{
    public float velocidadeMovimento = 5f; // Velocidade de movimento do navio
    public int maxHealth = 100; // Vida máxima do jogador
    public int currentHealth; // Vida atual do jogador
    public GameObject balaPrefab; // Prefab da bala
    public Transform pontoDeSpawn; // Ponto de spawn da bala
    public float velocidadeBala = 10f; // Velocidade da bala
    private Rigidbody2D rb;
    private float tempoUltimoTiro;
    private bool primeiroTiroDisparado = false;
    public float tempotiro = 3f; // Tempo de recarga (cooldown) do tiro
    public int danorecibido = 10;
    public Transform heatlhbar; //barra verde
    public GameObject heatltbarobject; // objeto pai das barras 
    public float speed = 5f;
    private Vector3 heatltbarScale; //tamanho da barra
    private float heathpercent;   // percetual de vida para o calculo  do tamanho da barra 

    void Start()
    {
        tempoUltimoTiro = Time.time;
        currentHealth = maxHealth; // Inicialize a vida atual com a vida máxima
        heatltbarScale = heatlhbar.localScale;
        heathpercent = heatltbarScale.x / currentHealth;
        rb = GetComponent<Rigidbody2D>(); // Inicialize o Rigidbody2D
    }

    void UpdateHealthbar()
    {
        heatltbarScale.x = heathpercent * currentHealth;
        heatlhbar.localScale = heatltbarScale;
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    void Update()
    {
        if (!PauseMenu.isPaused) // Verifica se o jogo não está pausado
        {
            MovimentarNavio();
        }
    }

    void MovimentarNavio()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        Vector3 movimento = new Vector3(movimentoHorizontal, 0f, 0f) * velocidadeMovimento * Time.deltaTime;
        transform.Translate(movimento);
    }

    public void AtirarBala()
    {
        if (Time.time >= tempoUltimoTiro + tempotiro)
        {
            GameObject bala = Instantiate(balaPrefab, pontoDeSpawn.position, pontoDeSpawn.rotation);
            bala.GetComponent<Rigidbody2D>().velocity = transform.right * velocidadeBala;
            tempoUltimoTiro = Time.time;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthbar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("balainimigo"))
        {
            Destroy(collision.gameObject); // Destrua a bala inimiga
            TakeDamage(danorecibido); // Cause dano ao jogador
        }
    }
}
