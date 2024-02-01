using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControleDoJogador : MonoBehaviour
{


    public Rigidbody2D oRigidbody2D;
    public float velocidadeDaNave; 

    private Vector2 teclasApertadas;

    public GameObject laserDoJogador;
    public List<GameObject> armasEspeciais;
    public List<GameObject> armasEspeciaisAtuais;

    public Transform localDoDisparoUnico;
    public Transform localDoDisparoDaEsquerda;
    public Transform localDoDisparoDaDireita;

    public bool temArmasEspeciais;

    public ItensColetaveis itensColetaveis;
    // public LaserDoJogador laserDoJogadorScript;
    public int contadorDeArmaEspecial;


    private int heapSize;

    public float tempoAtualDasArmasEspeciais;

    public float tempoMaximoDasArmasEspeciais;
   




    
    void Start()
    {
      // itensColetaveis = FindObjectOfType<ItensColetaveis>();
      // laserDoJogador = FindObjectOfType<LaserDoJogador>();


      // itensColetaveis.contadorDeArmaEspecial = 0;

      tempoAtualDasArmasEspeciais = tempoMaximoDasArmasEspeciais;
    }

    
    void Update()
    {
        
         MovimentarJogador();
         AtirarLaser();
        
        //*
        if(temArmasEspeciais == true)
        {
            tempoAtualDasArmasEspeciais -= Time.deltaTime;
            if(tempoAtualDasArmasEspeciais <= 0)
            {
                DesativarArmasEspeciais();
            }
        }
        //*/

    }


     private void MovimentarJogador()
    {
        //dizer pra unity quais foram as teclas apertadas
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        oRigidbody2D.velocity = teclasApertadas.normalized * velocidadeDaNave * Time.deltaTime;

    }

    private void AtirarLaser()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            // Instantiate(laserDoJogador, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
           //* 
            if(temArmasEspeciais == true)
            {
                UseWeaponWithMaxDamage(); // Atira a arma com maior dano
            }
            else
            {
                Instantiate(laserDoJogador, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
            }
            //*/
        }
    }

        /*void Start()
    {
        // Inicialize o vetor de armas com GameObjects fictícios para este exemplo.
        ArmasEspeciais = new GameObject[4];
        for (int i = 0; i < ArmasEspeciais.Length; i++)
        {
            ArmasEspeciais[i] = new GameObject($"Weapon {i + 1}");
            ArmasEspeciais[i].AddComponent<WeaponInfo>().damage = UnityEngine.Random.Range(10, 100);  // Dano fictício para cada arma.
        }

        // Construa a heap MAX.
        BuildMaxHeap();
    }*/
//*
    public void AtivarArmasEspeciais() // Atualiza lista de armas especiais e inicializa o Heap
    {  
        tempoAtualDasArmasEspeciais = tempoMaximoDasArmasEspeciais;
        BuildMaxHeap();
    }


    private void BuildMaxHeap()
    {
        heapSize = armasEspeciaisAtuais.Count();

        // Comece do último nó não folha e faça heapify para baixo.
        for (int i = armasEspeciaisAtuais.Count() / 2 - 1; i >= 0; i--)
        {
            HeapifyDown(i);
        }
    }
    

   void HeapifyDown(int index)
    {
        int largest = index;
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;

        // Compare com o filho da esquerda.
        if (leftChild < heapSize && armasEspeciaisAtuais[leftChild].GetComponent<LaserDoJogador>().danoParaDar > armasEspeciaisAtuais[largest].GetComponent<LaserDoJogador>().danoParaDar)
        {
            largest = leftChild;
        }

        // Compare com o filho da direita.
        if (rightChild < heapSize && armasEspeciaisAtuais[rightChild].GetComponent<LaserDoJogador>().danoParaDar > armasEspeciaisAtuais[largest].GetComponent<LaserDoJogador>().danoParaDar)
        {
            largest = rightChild;
        }

        // Se o maior não é o nó atual, troque e faça heapify para baixo recursivamente.
        if (largest != index)
        {
            Swap(index, largest);
            HeapifyDown(largest);
        }
    }

    void Swap(int a, int b)
    {
        GameObject temp = armasEspeciaisAtuais[a];
        armasEspeciaisAtuais[a] = armasEspeciaisAtuais[b];
        armasEspeciaisAtuais[b] = temp;
    }

    public void UseWeaponWithMaxDamage()
    {
        if (heapSize > 0)
        {
            Debug.Log("maior arma sendo usada!");
            
            //ArmasEspeciais[0] = null;  // Substitua pela lógica real de usar a arma.

            Instantiate(armasEspeciaisAtuais[0], localDoDisparoDaEsquerda.position, localDoDisparoDaEsquerda.rotation);
            Instantiate(armasEspeciaisAtuais[0], localDoDisparoDaDireita.position, localDoDisparoDaDireita.rotation);


            

            if (armasEspeciaisAtuais.Count() == 0)
            {
                Debug.Log("O vetor de armas está vazio. Todas as armas foram usadas.");
            }
        }
        else
        {
            Debug.Log("O vetor de armas já está vazio. Todas as armas foram usadas.");
        }
    }
    
    
    private void DesativarArmasEspeciais()
    {
        
        tempoAtualDasArmasEspeciais = tempoMaximoDasArmasEspeciais;
        if(armasEspeciaisAtuais.Count() > 0)
        {
            armasEspeciaisAtuais.Remove(armasEspeciaisAtuais[0]);
            if(armasEspeciaisAtuais.Count() == 0)
                temArmasEspeciais = false;
                //desativar estrelas
            // Rebuild heap após usar a arma.
            BuildMaxHeap();
        }
        else
        {
            temArmasEspeciais = false;
        }
    }
    //*/
    
}


