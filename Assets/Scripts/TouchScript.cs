using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    void Update()
    {
        // código só roda no editor
        #if UNITY_EDITOR
            // Verifica se ouve clique com o botão direito do mouse
            if (Input.GetMouseButton(0)) {
                // Chama a função de movimentação
                MoverObjeto(Input.mousePosition);
            }
                
        #endif

        // código só roda em android
        #if UNITY_ANDROID
            // Verifica se teve toque na tela
            if (Input.touchCount > 0) {
                // Variável para guardar as informações do toque na tela 
                Touch toque = Input.GetTouch(0);
                // Chama a função de movimentação
                MoverObjeto(toque.position);
            }
        #endif        
    }

    void MoverObjeto(Vector3 posicaoToque) {
        // tranformando o toque na tela a posição referente na cena do unity
        posicaoToque = Camera.main.ScreenToWorldPoint(posicaoToque);
        // Zerando o eixo Z 
        posicaoToque.z = 0f;
        // fazendo o objeto ficar na mesma posição do toque
        transform.position = posicaoToque;
    }
}
