using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BDCards : MonoBehaviour
{
  // Variables
  public List<string> ataquesNames = new List<string>();
  public List<string> defensaNames = new List<string>();
  public List<string> mesaNames = new List<string>();

  public List<List<(int, int)>> master  = new List<List<(int, int)>>();


  public static BDCards Instance { get; private set; }

  private void Awake()
  {
    Instance = this;

    ataquesNames.Add("Correos falsos 'Phishing'");
    ataquesNames.Add("Virus descargados de páginas web");
    ataquesNames.Add("Computadoras con configuración inadecuada suceptible a ataques informáticos."); 
    ataquesNames.Add("USB con codigo malicioso o malware que contamina redes y computadoras.");
    ataquesNames.Add("Existen herramientas de hacking que pueden descifrar las contraseñas debiles, sobre todo las que usan palabras comunes. Ej. DNI, mes y año, fecha de nacimiento, nombres, etc.");
    ataquesNames.Add("Los datos sensibles como número de tarjeta y contraseñas que permanecen en dispositivos en desuso puede ser sustraidos de manera no autorizada. ");
    ataquesNames.Add("Las redes sociales pueden ser utilizadas para obtener información personal de los usuario como el nombre, contactos, fotos, videos, fecha de cumpleaños, viajes para robar tu identidad digital.");
    ataquesNames.Add("Una persona puede ser influenciada por una persona de confianza para otorgar acceso a su información. Ej. Compartir la contraseña con un colega para que atienda mis pendientes mientras estoy de vacaciones.");
    ataquesNames.Add("Robo o perdida de telefono para comprometer datos bancarios como numero de tarjeta y contraseña");


    defensaNames.Add("Contar con un seguridad de correos en la organización");
    defensaNames.Add("Conocer sobre los peligros de estafas en correos electronicos");

    defensaNames.Add("Utilizar antivirus para cuidarse de paginas riesgosas");
    defensaNames.Add("Mantener aplicaciones actualizadas para protegerse de ataques");

    defensaNames.Add("Contar con buenas practicas de seguridad al conectar dispositivos a la red");
    defensaNames.Add("Mantener a raya dispositivos no bienvenidos en la red de internet");
    
    defensaNames.Add("Requerir reconocer al usuario al acceder a un dispositivo");
    
    defensaNames.Add("Conocer sobre los riesgos de conectar dispositivos extraños");

    defensaNames.Add("Contar con contraseñas fuertes");
    defensaNames.Add("No escribir contraseñas en lugares cercanos al computador");
    defensaNames.Add("Utilizar autenticación avanzada (de doble factor)");

    defensaNames.Add("Eliminar información de dispositivos en desuso");
    defensaNames.Add("Asegurar el no funcionamiento de dispositivos sin usar");

    defensaNames.Add("No publicar información sensible en redes sociales");
    defensaNames.Add("Mantener a raya notificaciones spam en las redes sociales");

    defensaNames.Add("Mantenerse alerta sobre consultas personales de cuentas personales");


    List<int> defIndex = new List<int> {  0, 1, 6, 10, 14, 
                                          2, 3, 14, 
                                          4, 5, 6, 7, 
                                          7, 2, 3, 
                                          8, 9, 10, 6, 
                                          11, 12, 6, 
                                          13, 14, 15, 
                                          15, 6, 
                                          6, 8, 9, 10, 11};
    List<int> puntaje  = new List<int> { 4, 4, 3, 3, 2,
                                         2, 2, 1, 
                                         3, 3, 2, 1, 
                                         2, 2, 1, 
                                         4, 4, 4, 3,
                                         2, 2, 1, 
                                         2, 2, 1,
                                         2, 1,
                                         4, 2, 2, 3, 3};

    List<int> dim  = new List<int> {5, 3, 4, 3, 4, 3, 3, 2, 5};
    int contTemp = 0;
    for (int i = 0; i < ataquesNames.Count; i++)
    {
      List<(int, int)> temp  = new List<(int, int)>();
      (int, int) pairP = (1, 1);
      //Debug.Log("Dim[i]: " + dim[i]);
      for (int j = 0; j < dim[i]; j++)
      {
        //Debug.Log("contTemp: " + contTemp);
        pairP.Item1 = defIndex[contTemp];
        pairP.Item2 = puntaje[contTemp];
        temp.Add(pairP);
        contTemp++;
      }
      master.Add(temp);
    }

    //Debug.Log("Master: "+ master);

  }

  public int ReturningScore(int indexAttack, int indexDefense) // Registrar en cards cual indice es la carta seleccionada
  {
    string res = string.Join(", ", master[indexAttack]);
    
    Debug.Log("Is this your attack? " + res + " and your card: " + indexDefense); //FIX:   Indexdefense es 0 para cuando llega aqui revisar mañana
    return 3;
  }
}
