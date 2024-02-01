using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{
    public bool itemArmaEspecial;
    public bool itemDeEscudo;
    public bool itemDeVida;
    private int contadorDeArmaEspecial;
    public int vidaParaDar;


    void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.CompareTag("Player"))
        {
            if(itemArmaEspecial)
            {
                contadorDeArmaEspecial = contadorDeArmaEspecial + 1;
                if(contadorDeArmaEspecial >= 3)
                {
                    other.gameObject.GetComponent<ControleDoJogador>().temArmasEspeciais = true;
                }
            }

            if(itemDeEscudo)
            {

                other.gameObject.GetComponent<VidaDoJogador>().AtivarEscudo();

            }
            if(itemDeVida)
            {

                other.gameObject.GetComponent<VidaDoJogador>().GanharVida(vidaParaDar);

            }

        }

    }



}
