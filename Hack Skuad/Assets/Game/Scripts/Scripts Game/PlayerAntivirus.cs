using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// La clase del jugador Antivirus
/// </summary>
public class PlayerAntivirus : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Dado dadoColumna, dadoFila;
    bool puedeTirarDado = true;
    public AudioSource Desplazar;

    [SerializeField]
    Transform ContenedorDadosAntivirus;

    // Variables de tipo ContenedorArray que simulan los caminos por donde se va a mover el player Antivirus
    public ContenedorArray camino1;
    public ContenedorArray camino2;
    public ContenedorArray camino3;
    public ContenedorArray camino4;

    // Velocidad de movimiento del player Antivirus
    private float velocidadMovimiento = 2f;
    private float velocidadMovimiento2 = 0.1f;

    // Variable booleana para validar que la ubicacion del player Antivirus, sea correcta en el mundo del juego
    public bool ubicacionCorrecta { get; set; }
    public bool ubicacionCorrecta2 { get; set; }

    ControladorPrincipal controladorPrincipal;

    [SerializeField]
    private GameObject botonDado;

    List<GameObject> listaBotonDados;

    DadoAntivirus dadoAntivirus;
    Animator animadorAntivirus;
    // Use this for initialization
    void Start()
    {
        controladorPrincipal = FindObjectOfType<ControladorPrincipal>();
        ubicacionCorrecta = false; // Se inicializa la posici�n del Antivirus como false
        ubicacionCorrecta2 = false;
        dadoAntivirus = botonDado.GetComponent<DadoAntivirus>();
        animadorAntivirus = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void TirarDado()
    {
        if (puedeTirarDado)
        {
            StartCoroutine(dadoFila.RodarDadoFila());

        }
    }


    // M�todo que realiza la ubicaci�n inicial del player Antivirus, en cualquiera de los 4 carriles de juego
    // Pas�ndole como parametros los valores de la fila y la columna que deben ser arrojados por el dado
    public void UbicarAntivirus(int fila, int columna)
    {
        animadorAntivirus.SetBool("Caminata",true);
        switch (fila)
        {
            case 0:
                this.transform.position = Vector2.MoveTowards(transform.position, camino1.listaPuntosDeCamino[columna].transform.position, Time.deltaTime * velocidadMovimiento); // Se le dice al player antivirus en que posicion ubicarse en la fila 0
                if (this.transform.position == camino1.listaPuntosDeCamino[columna].transform.position) // Se eval�a que la posici�n a la que se dirig�o es correcta
                {
                    ubicacionCorrecta = true;
                    animadorAntivirus.SetBool("Caminata", false);
                }
                break;
            case 1:
                this.transform.position = Vector2.MoveTowards(transform.position, camino2.listaPuntosDeCamino[columna].transform.position, Time.deltaTime * velocidadMovimiento); // Se le dice al player antivirus en que posicion ubicarse en la fila 1
                if (this.transform.position == camino2.listaPuntosDeCamino[columna].transform.position)
                {
                    ubicacionCorrecta = true;
                    animadorAntivirus.SetBool("Caminata", false);
                }
                break;
            case 2:
                this.transform.position = Vector2.MoveTowards(transform.position, camino3.listaPuntosDeCamino[columna].transform.position, Time.deltaTime * velocidadMovimiento); // Se le dice al player antivirus en que posicion ubicarse en la fila 2
                if (this.transform.position == camino3.listaPuntosDeCamino[columna].transform.position)
                {
                    ubicacionCorrecta = true;
                    animadorAntivirus.SetBool("Caminata", false);
                }
                break;
            case 3:
                this.transform.position = Vector2.MoveTowards(transform.position, camino4.listaPuntosDeCamino[columna].transform.position, Time.deltaTime * velocidadMovimiento); // Se le dice al player antivirus en que posicion ubicarse en la fila 3
                if (this.transform.position == camino4.listaPuntosDeCamino[columna].transform.position)
                {
                    ubicacionCorrecta = true;
                    animadorAntivirus.SetBool("Caminata", false);
                }
                break;
        }
        
    }

    // M�todo que realiza la invocaci�n de los dados al momento que el virus est� en su posici�n correcta al momento de iniciar el juego
    public void InvocarDadosPosicionamiento()
    {
        Transform contenedorDados = ContenedorDadosAntivirus;
        GameObject dadoDefaultAnti;
        listaBotonDados = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            dadoDefaultAnti = Instantiate(botonDado, contenedorDados);
            listaBotonDados.Add(dadoDefaultAnti);
        }
    }
    public void AgregarDadosAdicionales()
    {
        Transform contenedorDados = ContenedorDadosAntivirus;
        GameObject dadoDefaultAnti;
        dadoDefaultAnti = Instantiate(botonDado, contenedorDados);
        listaBotonDados.Add(dadoDefaultAnti);
    }

    public List<int> tomarMovimientos()
    {
        List<int> listaMovimientos = new List<int>();
        for (int i = 0; i < listaBotonDados.Count; i++)
        {
            for (int j = 0; j < dadoAntivirus.ladosDado.Length; j++)
            {
                if (listaBotonDados[i].GetComponent<Image>().sprite.Equals(dadoAntivirus.ladosDado[j]))
                {
                    listaMovimientos.Add(j);
                }
            }
        }
        return listaMovimientos;
    }

    //GameObject[] arrayTemporal1; // Arreglo de tipo gameobject que almacenar� un vector temporalmente

    // M�todo para mover al jugador Antivirus, seg�n el parametro que se le env�a, desde el m�todo de tipo enum
    public void MoverAntivirus(int opcion)
    {
        
        GameObject[] arrayTemporal1 = obtenerVector(); // En el vector temporal se almacena el vector en donde se encuentra ubicado el jugador antivirus en el instante
        int posicion = obtenerPocisionVector(arrayTemporal1); // Se crea una variable temporal int de posicion, que almacena la posici�n en donde se encuentra el gameobject de posicion en su respectivo vector "camino"
        if (opcion == 0) // Se evalua la opcion entregada por el parametro, si es abajo
        {
   
            //Desplazar.Play();
            if (arrayTemporal1.Equals(camino1.listaPuntosDeCamino)) // Se evalua que el vector en la variable temporal sea igual al camino 1
            {
                do // El personaje antivirus se mover� hasta el camino siguiente del camino 1, osea el camino 2
                {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, camino2.listaPuntosDeCamino[posicion].transform.position, Time.deltaTime * velocidadMovimiento2);
                    if (this.transform.position == camino2.listaPuntosDeCamino[posicion].transform.position) ubicacionCorrecta2 = true;
                } while (!ubicacionCorrecta2);
                foreach (var item in controladorPrincipal.ObtenerVirus())
                {
                    item.GetComponent<PlayerVirus>().VerificarChoqueAntivirus();
                }
            }
            if (arrayTemporal1.Equals(camino2.listaPuntosDeCamino)) // Se evalua que el vector en la variable temporal sea igual al camino 2
            {
                do // El personaje antivirus se mover� hasta el camino siguiente del camino 2, osea el camino 3
                {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, camino3.listaPuntosDeCamino[posicion].transform.position, Time.deltaTime * velocidadMovimiento2);
                    if (this.transform.position == camino3.listaPuntosDeCamino[posicion].transform.position) ubicacionCorrecta2 = true;
                } while (!ubicacionCorrecta2);
                foreach (var item in controladorPrincipal.ObtenerVirus())
                {
                    item.GetComponent<PlayerVirus>().VerificarChoqueAntivirus();
                }
            }
            if (arrayTemporal1.Equals(camino3.listaPuntosDeCamino)) // Se evalua que el vector en la variable temporal sea igual al camino 3
            {
                do // El personaje antivirus se mover� hasta el camino siguiente del camino 3, osea el camino 4
                {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, camino4.listaPuntosDeCamino[posicion].transform.position, Time.deltaTime * velocidadMovimiento2);
                    if (this.transform.position == camino4.listaPuntosDeCamino[posicion].transform.position) ubicacionCorrecta2 = true;
                } while (!ubicacionCorrecta2);
                foreach (var item in controladorPrincipal.ObtenerVirus())
                {
                    item.GetComponent<PlayerVirus>().VerificarChoqueAntivirus();
                }
            }
        }

        if (opcion == 1) // Se evalua la opcion entregada por el parametro, si es arriba
        {
   
            //Desplazar.Play();
            if (arrayTemporal1.Equals(camino2.listaPuntosDeCamino)) // Se evalua que el vector en la variable temporal sea igual al camino 2
            {
                do // El personaje antivirus se mover� hasta el camino anterior del camino 2, osea el camino 1
                {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, camino1.listaPuntosDeCamino[posicion].transform.position, Time.deltaTime * velocidadMovimiento2);
                    if (this.transform.position == camino1.listaPuntosDeCamino[posicion].transform.position) ubicacionCorrecta2 = true;
                } while (!ubicacionCorrecta2);
                foreach (var item in controladorPrincipal.ObtenerVirus())
                {
                    item.GetComponent<PlayerVirus>().VerificarChoqueAntivirus();
                }
            }
            if (arrayTemporal1.Equals(camino3.listaPuntosDeCamino)) // Se evalua que el vector en la variable temporal sea igual al camino 3
            {
                do // El personaje antivirus se mover� hasta el camino anterior del camino 3, osea el camino 2
                {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, camino2.listaPuntosDeCamino[posicion].transform.position, Time.deltaTime * velocidadMovimiento2);
                    if (this.transform.position == camino2.listaPuntosDeCamino[posicion].transform.position) ubicacionCorrecta2 = true;
                } while (!ubicacionCorrecta2);
                foreach (var item in controladorPrincipal.ObtenerVirus())
                {
                    item.GetComponent<PlayerVirus>().VerificarChoqueAntivirus();
                }
            }
            if (arrayTemporal1.Equals(camino4.listaPuntosDeCamino)) // Se evalua que el vector en la variable temporal sea igual al camino 4
            {
                do // El personaje antivirus se mover� hasta el camino anterior del camino 4, osea el camino 3
                {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, camino3.listaPuntosDeCamino[posicion].transform.position, Time.deltaTime * velocidadMovimiento2);
                    if (this.transform.position == camino3.listaPuntosDeCamino[posicion].transform.position) ubicacionCorrecta2 = true;
                } while (!ubicacionCorrecta2);
                foreach (var item in controladorPrincipal.ObtenerVirus())
                {
                    item.GetComponent<PlayerVirus>().VerificarChoqueAntivirus();
                }
            }
        }

        if (opcion == 2) // Se evalua la opcion entregada por el parametro, si es "derecha"
        {
 
            //Desplazar.Play();
            do // El personaje antivirus se mover� en el mismo vector pero a una posici�n adelante
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, arrayTemporal1[posicion + 1].transform.position, Time.deltaTime * velocidadMovimiento2);
                if (this.transform.position == arrayTemporal1[posicion + 1].transform.position) ubicacionCorrecta2 = true;
            } while (!ubicacionCorrecta2); // El movimiento lo realizar� hasta que la posici�n del jugador antivirus en el mundo sea igual a la de la posici�n siguiente 
            foreach (var item in controladorPrincipal.ObtenerVirus())
            {
                item.GetComponent<PlayerVirus>().VerificarChoqueAntivirus();
            }
        }

        if (opcion == 3) // Se evalua la opcion entregada por el parametro, si es "izquierda"
        {
    
            //Desplazar.Play();
            do // El personaje antivirus se mover� en el mismo vector pero a una posici�n detr�s
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, arrayTemporal1[posicion - 1].transform.position, Time.deltaTime * velocidadMovimiento2);
                if (this.transform.position == arrayTemporal1[posicion - 1].transform.position) ubicacionCorrecta2 = true;
            } while (!ubicacionCorrecta2); // El movimiento lo realizar� hasta que la posici�n del jugador antivirus en el mundo sea igual a la de la posici�n anterior
            foreach (var item in controladorPrincipal.ObtenerVirus())
            {
                item.GetComponent<PlayerVirus>().VerificarChoqueAntivirus();
            }
        }

    }

    GameObject[] arrayTemporal; // Arreglo de tipo gameobject que almacenar� un vector temporalmente

    // M�todo para obtener el camino en donde se encuentra situado el jugador antivirus en el instante
    public GameObject[] obtenerVector()
    {
        Vector2 posicionActual = this.transform.position;
        for (int i = 0; i < 10; i++)
        {
            if (posicionActual.Equals(camino1.listaPuntosDeCamino[i].transform.position))
            {
                arrayTemporal = camino1.listaPuntosDeCamino;
            }
            if (posicionActual.Equals(camino2.listaPuntosDeCamino[i].transform.position))
            {
                arrayTemporal = camino2.listaPuntosDeCamino;
            }
            if (posicionActual.Equals(camino3.listaPuntosDeCamino[i].transform.position))
            {
                arrayTemporal = camino3.listaPuntosDeCamino;
            }
            if (posicionActual.Equals(camino4.listaPuntosDeCamino[i].transform.position))
            {
                arrayTemporal = camino4.listaPuntosDeCamino;
            }
        }
        return arrayTemporal;
    }

    public int obtenerPocisionVector(GameObject[] arrayAEvaluar)
    {
        int posicion = 0;
        Vector2 posicionActual = this.transform.position;
        for (int i = 0; i < 10; i++)
        {
            if (posicionActual.Equals(arrayAEvaluar[i].transform.position))
            {
                posicion = i;
            }
        }
        return posicion;
    }

    public IEnumerator EjecutarJugadaAntivirus()
    {
        int i = 0;
        int opcion = 0;
        do
        {

            yield return new WaitForSeconds(1f);
            opcion = int.Parse(player.jugada.Substring(i, 1));
            
            MoverAntivirus(opcion);
            i++;
            ubicacionCorrecta2 = false;
        } while (i != tomarMovimientos().Count);

    }

    public void EjecutarJugada()
    {
        StartCoroutine(EjecutarJugadaAntivirus());
    }

    public void EjecutarGuardar()
    {
        GuardarJugada();
        
    }

    public void GuardarJugada()
    {
        player.jugada = "";
        for (int i = 0; i < tomarMovimientos().Count; i++)
        {
            player.jugada += tomarMovimientos()[i];
        }
        //player.jugada += ";";
    }
}
