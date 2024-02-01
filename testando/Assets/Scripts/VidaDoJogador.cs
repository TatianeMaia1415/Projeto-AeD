using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDoJogador : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject escudoDoJogador;
    public int vidaMaximaDoJogador;

    public int vidaAtualDoJogador;

    public int vidaAtualDoEscudo;
    public int vidaMaximaDoEscudo;
    
    public bool temEscudo;


    void Start()
    {

        
        vidaAtualDoJogador = vidaMaximaDoJogador;

        vidaAtualDoEscudo = vidaMaximaDoEscudo;

        escudoDoJogador.SetActive(false);

        temEscudo = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarEscudo()
    {
        //barraDeEnergiaDoEscudo.gameObject.SetActive(true);//ativando a barra do escudo

        vidaAtualDoEscudo = vidaMaximaDoEscudo;

        //barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

        escudoDoJogador.SetActive(true);
        temEscudo = true;
    }


    public void GanharVida(int vidaParaReceber)
    {
        if(vidaAtualDoJogador + vidaParaReceber <= vidaMaximaDoJogador)
        {
            vidaAtualDoJogador += vidaParaReceber;
        }
        else
        {
            vidaAtualDoJogador = vidaMaximaDoJogador;
        }

        //barraDeVidaDoJogador.value = vidaAtualDoJogador;
    }

    public void MachucarJogador(int danoParaReceber)
    {
    
        if(temEscudo == false)
        {
            vidaAtualDoJogador -= danoParaReceber;
            //barraDeVidaDoJogador.value = vidaAtualDoJogador;
            //barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

            if(vidaAtualDoJogador <= 0)
            {
                //FindObjectOfType<ControleDoJogador>().jogadorEstaVivo = false; //acesso ao metodo de outro script
                //GameManager.instance.GameOver();
                Debug.Log("Game Over!");
            }
        }else{

            vidaAtualDoEscudo -= danoParaReceber;

            //barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

            if(vidaAtualDoEscudo <= 0){

                escudoDoJogador.SetActive(false);

                temEscudo = false;

                //barraDeEnergiaDoEscudo.gameObject.SetActive(false);

            }
        }
    }

}
