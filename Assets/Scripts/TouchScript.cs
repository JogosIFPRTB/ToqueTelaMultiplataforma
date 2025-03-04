using UnityEngine;

/// <summary>
/// Classe responsável por mover um objeto para a posição do toque (Android) ou clique (PC).
/// Permite que o objeto siga a posição do dedo na tela ou do cursor do mouse.
/// </summary>
public class TouchScript : MonoBehaviour
{
    /// <summary>
    /// Referência para a câmera principal da cena.
    /// </summary>
    private Camera cam;

    /// <summary>
    /// Método chamado uma vez quando o script inicia.
    /// Aqui, armazenamos a referência da câmera principal para otimizar chamadas no Update.
    /// </summary>
    void Start()
    {
        cam = Camera.main;
    }

    /// <summary>
    /// Método chamado a cada frame para verificar a entrada do usuário (toque ou clique).
    /// Move o objeto conforme o toque arrastado ou o movimento do mouse.
    /// </summary>
    void Update()
    {
        // Verifica se há toque na tela (Android ou dispositivos touch)
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            // Movimenta o objeto apenas se o usuário arrastar o dedo na tela
            if (toque.phase == TouchPhase.Moved)
                MoverObjeto(toque.position);
        }
        // Se não há toque, verifica se o botão do mouse está pressionado (para testes no Editor)
        else if (Input.GetMouseButton(0))
        {
            MoverObjeto(Input.mousePosition);
        }
    }

    /// <summary>
    /// Move o objeto para a posição do toque ou clique.
    /// </summary>
    /// <param name="posicaoToque">Posição da tela onde ocorreu o toque ou clique.</param>
    void MoverObjeto(Vector3 posicaoToque)
    {
        // Converte a posição da tela (2D) para coordenadas do mundo (3D)
        Vector3 posicaoMundo = cam.ScreenToWorldPoint(new Vector3(posicaoToque.x, posicaoToque.y, cam.nearClipPlane));
        posicaoMundo.z = 0f; // Mantém o objeto no plano 2D

        // Define a posição do objeto para a posição do toque/clique
        transform.position = posicaoMundo;
    }
}
