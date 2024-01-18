using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour
{
    Rigidbody rigi;
    public LayerMask queEsMuerte;
    public float fuerzaNave = 1000;
    public float fuerzarotacion = 30;
    public bool estadestruida = false;
    public GameManager manager;
    public ParticleSystem[] particulas;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        //int numeroHijos = transform.GetChild(0).GetChild(0).childCount;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Actualizar");
        if (!manager.estamosJugando) return;
        //transform.Rotate(Vector3.right * 2);

        if (Input.GetKey(KeyCode.D))

            transform.Rotate(Vector3.forward * -fuerzarotacion * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))

            transform.Rotate(Vector3.forward * fuerzarotacion * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
        {
            rigi.AddForce(transform.up * fuerzaNave);
            for (int i = 0; i < particulas.Length; i++) 
            {
                particulas[i].Play();
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (estadestruida) return; 
        if ((queEsMuerte & (1 << collision.collider.gameObject.layer)) != 0)
        {
            manager.AvisarMuerte();
            //Debug.Log(collision.collider.gameObject.layer);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Finish")) 
        {
            Debug.Log("¡Gane!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            manager.AgregarMoneda();
        }
    }
    
    public IEnumerator DestruirNave()
    {
        Debug.Log("hola");
        estadestruida = true;
        VolarComponentes();
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("adios");
    }

    void VolarComponentes()
    {
        Transform padre = transform.GetChild(0).GetChild(0);
        int numeroHijos = padre.childCount;

        for (int i = 0; i < numeroHijos; i++)
        {
            Debug.Log(i);
            //Destroy(rigi);
            GameObject hijo = padre.GetChild(i).gameObject;
            //(1,1,1) * 2
            Rigidbody hijoRigi = hijo.AddComponent<Rigidbody>();

            int x = Random.Range(-1000, 1000);
            int y = Random.Range(-1000, 1000);
            int z = Random.Range(-1000, 1000);

            Vector3 direccion = new Vector3(x, y, z);
            //Debug.Log(direccion);
            hijoRigi.AddForce(direccion);

            //ctr + k, ctr + c esto comenta
            //ctr + k, ctr + u quita comentario

            int xR = Random.Range(0, 360);
            int yR = Random.Range(0, 360);
            int zR = Random.Range(0, 360);

            Vector3 rotation = new Vector3(xR, yR, zR);

            transform.rotation = Quaternion.Euler(rotation);

            hijoRigi.AddForceAtPosition(direccion, Vector2.down);
        }
        
    }

}



