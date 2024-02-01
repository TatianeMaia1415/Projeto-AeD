using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{
    public bool itemArmaEspecial;
    public bool itemDeEscudo;
    public bool itemDeVida;
    public int referenciaArma;
    public int vidaParaDar;


    void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.CompareTag("Player"))
        {
            if(itemArmaEspecial)
            {
                ControleDoJogador controleJogadorScript = other.gameObject.GetComponent<ControleDoJogador>();
                if(!controleJogadorScript.temArmasEspeciais)
                {
                    // controleJogadorScript.estrelas[controleJogadorScript.contadorDeArmaEspecial].SetActive(true);
                    controleJogadorScript.contadorDeArmaEspecial++;
                    controleJogadorScript.armasEspeciaisAtuais.Add(controleJogadorScript.armasEspeciais[referenciaArma]);

                    if(controleJogadorScript.contadorDeArmaEspecial >= 3)
                    {
                        controleJogadorScript.temArmasEspeciais = true;
                        controleJogadorScript.AtivarArmasEspeciais();
                        controleJogadorScript.contadorDeArmaEspecial = 0;
                    }
                }
            }
            else if(itemDeEscudo)
            {

                other.gameObject.GetComponent<VidaDoJogador>().AtivarEscudo();

            }
            else if(itemDeVida)
            {

                other.gameObject.GetComponent<VidaDoJogador>().GanharVida(vidaParaDar);
            }
            Destroy(this.gameObject);

        }

    }



}
