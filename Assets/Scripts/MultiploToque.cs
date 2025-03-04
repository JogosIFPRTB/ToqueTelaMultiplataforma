using UnityEngine;

/// <summary>
/// Classe responsável por instanciar um objeto na posição do toque (Android) ou clique (PC).
/// Funciona tanto no Unity Editor (usando o mouse) quanto em dispositivos móveis (toque na tela).
/// </summary>
public class MultiploToque : MonoBehaviour
{
    /// <summary>
    /// Objeto que será instanciado quando houver um toque ou clique.
    /// </summary>
    public GameObject objeto;

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
    /// </summary>
    void Update()
    {
        // Verifica se há toques na tela (Android ou dispositivos touch)
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                // Captura apenas o início do toque para evitar múltiplas instâncias
                if (Input.touches[i].phase == TouchPhase.Began)
                    GeraObjeto(Input.touches[i].position);
            }
        }
        // Se não há toque, verifica se houve clique do mouse (para testes no Editor)
        else if (Input.GetMouseButtonDown(0))
        {
            GeraObjeto(Input.mousePosition);
        }
    }

    /// <summary>
    /// Instancia um objeto na posição do toque ou clique.
    /// </summary>
    /// <param name="posicaoToque">Posição da tela onde ocorreu o toque ou clique.</param>
    void GeraObjeto(Vector3 posicaoToque)
    {
        // Converte a posição da tela (2D) para coordenadas do mundo (3D)
        Vector3 posicaoMundo = cam.ScreenToWorldPoint(new Vector3(posicaoToque.x, posicaoToque.y, cam.nearClipPlane));
        posicaoMundo.z = 0f; // Mantém o objeto no plano 2D

        // Instancia o objeto na posição calculada
        GameObject clone = Instantiate(objeto, posicaoMundo, Quaternion.identity);

        // Destroi o objeto após 1 segundo para evitar sobrecarga de instâncias na cena
        Destroy(clone, 1f);
    }
}
