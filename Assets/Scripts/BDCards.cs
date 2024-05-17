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


  public static BDCards Instance { get; private set; }

  private void Awake()
  {
    Instance = this;

    ataquesNames.Add("Correos falsos 'Phishing'");
    ataquesNames.Add("Virus descargados de páginas web");
    ataquesNames.Add("Computadoras con configuración inadecuada suceptible a ataques informáticos."); 
    ataquesNames.Add("Robo o perdida de telefono para comprometer datos bancarios como numero de tarjeta y contraseña");
    ataquesNames.Add("USB con codigo malicioso o malware que contamina redes y computadoras.");
    ataquesNames.Add("Existen herramientas de hacking que pueden descifrar las contraseñas debiles, sobre todo las que usan palabras comunes. Ej. DNI, mes y año, fecha de nacimiento, nombres, etc.");
    ataquesNames.Add("Los datos sensibles como número de tarjeta y contraseñas que permanecen en dispositivos en desuso puede ser sustraidos de manera no autorizada. ");
    ataquesNames.Add("Las redes sociales pueden ser utilizadas para obtener información personal de los usuario como el nombre, contactos, fotos, videos, fecha de cumpleaños, viajes para robar tu identidad digital.");
    ataquesNames.Add("Una persona puede ser influenciada por una persona de confianza para otorgar acceso a su información. Ej. Compartir la contraseña con un colega para que atienda mis pendientes mientras estoy de vacaciones.");

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
    

  }

  void Start()
  {
    //Faltan poner muchas más cartas <----


  }

  void Update()
  {

  }
}
