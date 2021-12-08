using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiploToque : MonoBehaviour
{
    // variável publica do objeto que será instanciado
    public GameObject objeto;
    // Update is called once per frame
    void Update()
    {
        // código só roda no editor
        #if UNITY_EDITOR
            // Verifica se ouve clique com o botão direito do mouse
            if (Input.GetMouseButton(0))
                // chamando o metodo GerarObjeto para cada posição de cada toque
                GeraObjeto(Input.mousePosition);
        #endif

        // código só roda em android
        #if UNITY_ANDROID
            // loop para pegar todos os toque na tela
            for (int i = 0; i < Input.touchCount; i++)
            {
                // chamando o metodo GerarObjeto para cada posição de cada toque
                GeraObjeto(Input.touches[i].position);
            }        
        #endif
    }

    void GeraObjeto(Vector3 posicaoToque) {
        // tranformando o toque na tela a posição referente na cena do unity
        posicaoToque = Camera.main.ScreenToWorldPoint(posicaoToque);
        // Zerando o eixo Z 
        posicaoToque.z = 0f;
        // instacia o clone do objeto na posição que foi feito o toque
        GameObject clone = Instantiate(objeto, posicaoToque, Quaternion.identity);
        // programa destruição do objeto após 1 segundo
        Destroy(clone, 1);
    }
}
