using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public float velocidadeDoInimigo;
    public Transform localDoDisparo;
    public GameObject laserDoInimigo;
    public float tempoMaximoEntreOsLasers;

    public float tempoAtualDosLasers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();
        AtirarLaser();
    }

    private void MovimentarInimigo()
    {
        transform.Translate(Vector3.left * velocidadeDoInimigo * Time.deltaTime);
    }


    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;

        if(tempoAtualDosLasers <= 0)
        {
            Instantiate(laserDoInimigo, localDoDisparo.position, Quaternion.Euler(0f, 0f, 90f));
            
            tempoAtualDosLasers = tempoMaximoEntreOsLasers;
            
        }
    }
}
