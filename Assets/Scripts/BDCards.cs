using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BDCards : MonoBehaviour
{
  // Variables
  public List<string> ataquesNames = new List<string>();
  public List<string> defensaNames = new List<string>();
  public List<string> specialCards = new List<string>();
  public List<string> mesaNames = new List<string>();

  public List<List<int>> defensaPoints = new List<List<int>>();

  public List<string> ataquesNamesShort = new List<string>();
  public List<string> ataquesInfo = new List<string>();

  public List<List<(int, int)>> master = new List<List<(int, int)>>();


  public static BDCards Instance { get; private set; }

  private void Awake()
  {
    Instance = this;

    ataquesNames.Add("Correos falsos 'Phishing'");
    ataquesNames.Add("Virus descargados de páginas web");
    ataquesNames.Add("Computadoras con configuración inadecuada suceptible a ataques informáticos.");
    ataquesNames.Add("USB con codigo malicioso o malware que contamina redes y computadoras.");
    ataquesNames.Add("Existen herramientas de hacking que pueden descifrar las contraseñas débiles, sobre todo las que usan palabras comunes. "); //Ej. DNI, mes y año, fecha de nacimiento, nombres, etc.
    ataquesNames.Add("Los datos sensibles como número de tarjeta y contraseñas que permanecen en dispositivos en desuso puede ser sustraidos de manera no autorizada. ");
    ataquesNames.Add("Las redes sociales pueden ser utilizadas para obtener información personal de los usuarios para robar tu identidad digital."); // como el nombre, contactos, fotos, videos, fecha de cumpleaños, viajes
    ataquesNames.Add("Una persona puede ser influenciada por una persona de confianza para otorgar acceso a su información. "); //Ej. Compartir la contraseña con un colega para que atienda mis pendientes mientras estoy de vacaciones.
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
    List<int> puntaje = new List<int> { 4, 4, 3, 3, 2,
                                         2, 2, 1,
                                         3, 3, 2, 1,
                                         2, 2, 1,
                                         4, 4, 4, 3,
                                         2, 2, 1,
                                         2, 2, 1,
                                         2, 1,
                                         4, 2, 2, 3, 3};

    List<int> dim = new List<int> { 5, 3, 4, 3, 4, 3, 3, 2, 5 };
    int contTemp = 0;
    for (int i = 0; i < ataquesNames.Count; i++)
    {
      List<(int, int)> temp = new List<(int, int)>();
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
    specialCards.Add("Quitar dos cartas");
    specialCards.Add("+10 Puntos");
    specialCards.Add("-5 Puntos Enemigos");
    specialCards.Add("Saltar turno enemigo");


    //Guidebook
    ataquesNamesShort.Add("Phishing");
    ataquesNamesShort.Add("Viruses");
    ataquesNamesShort.Add("Dispositivos con poca seguridad interna");
    ataquesNamesShort.Add("Perdida de dispositivo");
    ataquesNamesShort.Add("USB con malware");
    ataquesNamesShort.Add("Descifrado de contraseñas");
    ataquesNamesShort.Add("Dispositivos en desuso mal deshechados");
    ataquesNamesShort.Add("Seguridad en redes sociales");
    ataquesNamesShort.Add("Cuentas personales compartidas");

    ataquesInfo.Add("El phishing es una técnica de fraude en la que un atacante se hace pasar por una entidad confiable (como un banco, empresa o familiar) para engañar a una persona y obtener información confidencial, como contraseñas, números de tarjetas o datos personales, a través de correos electrónicos, mensajes de texto o sitios web falsos.");
    ataquesInfo.Add("Los viruses de la web son programas maliciosos que se infiltran en tu computador al descargar archivos infectados o visitar sitios web comprometidos. Estos virus pueden robar datos personales como contraseñas, números de tarjetas y otra información sensible. Lo hacen registrando las teclas que presionas, con capturas de pantalla, accediendo a tus archivos o incluso tomando el control total de tu dispositivo.");
    ataquesInfo.Add("Las computadoras con configuraciones inadecuadas, como sistemas desactualizados, contraseñas débiles y falta de antivirus, son vulnerables a ataques informáticos. Estas brechas de seguridad permiten a los atacantes instalar malware, robar datos personales y acceder a información confidencial sin autorización, lo que pone en riesgo la privacidad del usuario.");
    ataquesInfo.Add("El robo o pérdida de un celular puede comprometer gravemente tus datos personales, como números de tarjeta y contraseñas. Si el dispositivo no está protegido con contraseñas seguras o autenticación biométrica, los delincuentes pueden acceder a aplicaciones bancarias u otra información.");
    ataquesInfo.Add("Un USB con código malicioso o malware puede infectar redes y computadoras al conectarse a un dispositivo. Este malware puede propagarse rápidamente, robando datos sensibles, comprometiendo la seguridad de la red y permitiendo a los atacantes controlar sistemas de manera remota. Además, puede instalar software espía que registra contraseñas y otra información confidencial, poniendo en riesgo la privacidad y la integridad de la información almacenada en las computadoras y la red afectada");
    ataquesInfo.Add("Existen herramientas de hacking que pueden descifrar contraseñas débiles, especialmente aquellas que utilizan palabras comunes. Estas herramientas emplean técnicas como ataques de diccionario y ataques de fuerza bruta. En un ataque de diccionario, el hacker utiliza una lista predefinida de palabras comunes, frases y combinaciones para adivinar la contraseña. En un ataque de fuerza bruta, el hacker prueba todas las combinaciones posibles hasta encontrar la correcta. Ambas técnicas son efectivas contra contraseñas cortas o simples, lo cual se mitiga con contraseñas complejas.");
    ataquesInfo.Add("Los dispositivos en desuso que contienen datos sensibles, como números de tarjeta y contraseñas, representan un riesgo significativo si no se gestionan adecuadamente. Si estos dispositivos no se borran o destruyen correctamente, los atacantes pueden recuperar información almacenada utilizando técnicas de recuperación de datos. Esta información puede ser utilizada para cometer fraude, robo de identidad y otros actos maliciosos, comprometiendo la seguridad y privacidad de los antiguos propietarios.");
    ataquesInfo.Add("Las redes sociales pueden ser utilizadas por atacantes para obtener información personal de los usuarios y robar su identidad digital. Los perfiles públicos y las publicaciones a menudo contienen datos sensibles, como fechas de nacimiento, direcciones, información sobre familiares y patrones de comportamiento. Los delincuentes pueden usar esta información para responder preguntas de seguridad, crear perfiles falsos y acceder a cuentas bancarias o servicios en línea. Por ello, es crucial gestionar la privacidad en las redes sociales y limitar la cantidad de información personal compartida públicamente.");
    ataquesInfo.Add("Una persona puede ser influenciada por alguien de confianza para otorgar acceso a su información, un método conocido como ingeniería social. Los atacantes pueden hacerse pasar por amigos, familiares o colegas para ganarse la confianza de la víctima y obtener datos sensibles, como contraseñas o información financiera. Esta confianza malintencionada puede llevar a la divulgación de información personal y comprometer la privacidad del individuo afectado.");

    //Indice ataque, score 
    /*List<<int, int>> scoreDefensas = new List<<int, int>> {  
      (0, 4), 
      (0, 4),
      (1, 2), (3, 1),
      (1, 2), (3, 1),
      (2, 3),
      (2, 3),
      (0, 3), (2, 2), (4, 3), (5, 1), (7, 1), (8, 4),
      (2, 1), (3, 2),
      (4, 4), (8, 2),
      (4, 4), (8, 2),
      (0, 3), (4, 4), (8, 3)
      };
    */

    for (int i = 0; i < defensaNames.Count; i++)
    {
      List<int> temps = new List<int>();
      for (int j = 0; j < ataquesInfo.Count; j++)
      {
          temps.Add(0);
      }
      defensaPoints.Add(temps);
    }

  }

  /*public void Start()
  {
    Debug.Log(defensaPoints.Count);
    Debug.Log(defensaPoints[0].Count);
  }*/

  public int ReturningScore(int indexAttack, int indexDefense) // Registrar en cards cual indice es la carta seleccionada
  {
    string res = string.Join(", ", master[indexAttack]);
    for (int i = 0; i < master[indexAttack].Count; i++)
    {
      //Debug.Log("Master? " + master[indexAttack][i].Item1);
      if (master[indexAttack][i].Item1 == indexDefense)
      {
        //Debug.Log("Is this your attack? " + res + " and your card: " + indexDefense + "and your score: " + master[indexAttack][i].Item2); //FIX:   Indexdefense es 0 para cuando llega aqui revisar mañana
        return master[indexAttack][i].Item2;
      }
    }

    return 0;
  }



}
