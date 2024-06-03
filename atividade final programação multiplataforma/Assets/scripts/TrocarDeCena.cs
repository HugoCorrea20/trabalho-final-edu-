using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrocarDeCena : MonoBehaviour
{
    public string proximaCena; // Nome da pr�xima cena a ser carregada
    public float tempoDeTransicao = 1f; // Tempo da transi��o
    public Image imagemTransicao; // Refer�ncia para a imagem de transi��o

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verifica se o jogador colidiu com o gatilho
        {
            // Inicia a cor da imagem de transi��o com alpha 0
            Color corInicial = imagemTransicao.color;
            corInicial.a = 0f;
            imagemTransicao.color = corInicial;

            // Inicia a transi��o
            StartCoroutine(TransicaoParaProximaCena());
        }
    }
    public void IniciarTransicao()
    {
        StartCoroutine(TransicaoParaProximaCena());
    }

    public IEnumerator TransicaoParaProximaCena()
    {
        // Gradualmente aumenta a opacidade da imagem de transi��o
        float tempoDecorrido = 0f;
        while (tempoDecorrido < tempoDeTransicao)
        {
            // Calcula o progresso da transi��o
            float progresso = tempoDecorrido / tempoDeTransicao;

            // Interpola a opacidade da cor da imagem
            Color cor = imagemTransicao.color;
            cor.a = Mathf.Lerp(0f, 1f, progresso);
            imagemTransicao.color = cor;

            // Atualiza o tempo decorrido
            tempoDecorrido += Time.deltaTime;
            yield return null;
        }

        // Garante que a opacidade est� no m�ximo
        Color corFinal = imagemTransicao.color;
        corFinal.a = 1f;
        imagemTransicao.color = corFinal;

        // Carrega a pr�xima cena ap�s a transi��o
        SceneManager.LoadScene(proximaCena);
    }
}
