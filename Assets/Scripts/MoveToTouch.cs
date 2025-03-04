using UnityEngine;

/// <summary>
/// Move o objeto na direção do toque.
/// Se houver múltiplos toques, ele se move para o ponto médio entre eles.
/// </summary>
public class MoveToTouch : MonoBehaviour
{
    /// <summary>
    /// Velocidade de movimento do objeto.
    /// </summary>
    public float velocidade = 5f;

    /// <summary>
    /// Referência para a câmera principal.
    /// </summary>
    private Camera cam;

    /// <summary>
    /// Posição alvo para onde o objeto deve se mover.
    /// </summary>
    private Vector3 destino;

    /// <summary>
    /// Inicializa a referência da câmera principal e define o destino inicial como a posição atual.
    /// </summary>
    void Start()
    {
        cam = Camera.main;
        destino = transform.position;
    }

    /// <summary>
    /// Atualiza a posição alvo com base no toque ou clique do usuário.
    /// </summary>
    void Update()
    {
        // Se houver toques na tela (dispositivos móveis)
        if (Input.touchCount > 0)
        {
            destino = CalcularPontoMedio();
        }
        // Se não houver toques, mas houver clique do mouse (Editor)
        else if (Input.GetMouseButton(0))
        {
            destino = ObterPosicaoMundo(Input.mousePosition);
        }

        // Move o objeto na direção do destino
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);
    }

    /// <summary>
    /// Calcula a posição intermediária entre todos os toques na tela.
    /// </summary>
    /// <returns>O ponto médio entre os toques convertidos para coordenadas do mundo.</returns>
    private Vector3 CalcularPontoMedio()
    {
        Vector3 somaPosicoes = Vector3.zero;

        // Soma todas as posições dos toques na tela
        for (int i = 0; i < Input.touchCount; i++)
        {
            somaPosicoes += ObterPosicaoMundo(Input.touches[i].position);
        }

        // Calcula a média das posições
        return somaPosicoes / Input.touchCount;
    }

    /// <summary>
    /// Converte uma posição da tela (2D) para coordenadas do mundo (3D).
    /// </summary>
    /// <param name="posicaoTela">Posição do toque ou clique na tela.</param>
    /// <returns>Posição correspondente no mundo da Unity.</returns>
    private Vector3 ObterPosicaoMundo(Vector3 posicaoTela)
    {
        Vector3 posicaoMundo = cam.ScreenToWorldPoint(new Vector3(posicaoTela.x, posicaoTela.y, cam.nearClipPlane));
        posicaoMundo.z = 0f; // Mantém no plano 2D
        return posicaoMundo;
    }
}
