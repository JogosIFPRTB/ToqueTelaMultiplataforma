using UnityEngine;

/// <summary>
/// Move o objeto na dire��o do toque.
/// Se houver m�ltiplos toques, ele se move para o ponto m�dio entre eles.
/// </summary>
public class MoveToTouch : MonoBehaviour
{
    /// <summary>
    /// Velocidade de movimento do objeto.
    /// </summary>
    public float velocidade = 5f;

    /// <summary>
    /// Refer�ncia para a c�mera principal.
    /// </summary>
    private Camera cam;

    /// <summary>
    /// Posi��o alvo para onde o objeto deve se mover.
    /// </summary>
    private Vector3 destino;

    /// <summary>
    /// Inicializa a refer�ncia da c�mera principal e define o destino inicial como a posi��o atual.
    /// </summary>
    void Start()
    {
        cam = Camera.main;
        destino = transform.position;
    }

    /// <summary>
    /// Atualiza a posi��o alvo com base no toque ou clique do usu�rio.
    /// </summary>
    void Update()
    {
        // Se houver toques na tela (dispositivos m�veis)
        if (Input.touchCount > 0)
        {
            destino = CalcularPontoMedio();
        }
        // Se n�o houver toques, mas houver clique do mouse (Editor)
        else if (Input.GetMouseButton(0))
        {
            destino = ObterPosicaoMundo(Input.mousePosition);
        }

        // Move o objeto na dire��o do destino
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);
    }

    /// <summary>
    /// Calcula a posi��o intermedi�ria entre todos os toques na tela.
    /// </summary>
    /// <returns>O ponto m�dio entre os toques convertidos para coordenadas do mundo.</returns>
    private Vector3 CalcularPontoMedio()
    {
        Vector3 somaPosicoes = Vector3.zero;

        // Soma todas as posi��es dos toques na tela
        for (int i = 0; i < Input.touchCount; i++)
        {
            somaPosicoes += ObterPosicaoMundo(Input.touches[i].position);
        }

        // Calcula a m�dia das posi��es
        return somaPosicoes / Input.touchCount;
    }

    /// <summary>
    /// Converte uma posi��o da tela (2D) para coordenadas do mundo (3D).
    /// </summary>
    /// <param name="posicaoTela">Posi��o do toque ou clique na tela.</param>
    /// <returns>Posi��o correspondente no mundo da Unity.</returns>
    private Vector3 ObterPosicaoMundo(Vector3 posicaoTela)
    {
        Vector3 posicaoMundo = cam.ScreenToWorldPoint(new Vector3(posicaoTela.x, posicaoTela.y, cam.nearClipPlane));
        posicaoMundo.z = 0f; // Mant�m no plano 2D
        return posicaoMundo;
    }
}
