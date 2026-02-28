# Taller SMTP – Integración de Notificaciones por Email en Unity

## Descripción general

Este proyecto consiste en un mini-juego desarrollado en Unity que integra un sistema de notificaciones por correo electrónico utilizando SMTP.  
El objetivo principal es demostrar la integración funcional entre la lógica del juego, la interfaz de usuario y el envío real de correos electrónicos.

---

## Evento que dispara la notificación

El juego funciona con un sistema de puntaje.  

Cada vez que el jugador destruye un objeto (Hex), el puntaje aumenta.  
Cuando el jugador alcanza un puntaje específico (milestones cada 10 puntos y el puntaje final de 100), se ejecuta el envío de una notificación por correo electrónico.

En el caso del puntaje final (100 puntos), se envía un correo indicando que el jugador completó la partida.

---

## Flujo básico del envío SMTP

El envío se realiza desde la clase `EmailManager`.

El flujo es el siguiente:

1. Se construye dinámicamente el asunto y el cuerpo del mensaje, incluyendo:
   - Puntaje alcanzado
   - Fecha y hora del evento
2. Se crea un objeto `MailMessage` con:
   - Remitente (fromEmail)
   - Destinatario ingresado por el usuario
   - Asunto
   - Cuerpo
3. Se configura el cliente SMTP:
   - Servidor: `smtp.gmail.com`
   - Puerto: 587
   - SSL habilitado
   - Autenticación mediante contraseña de aplicación
4. Se realiza el envío utilizando `SmtpClient`.

El método de envío es asíncrono para evitar bloquear la ejecución del juego.

---

## Manejo de respuestas del servidor

El envío está contenido dentro de un bloque `try-catch`.

- Si el envío es exitoso, se retorna un resultado positivo y la interfaz muestra un mensaje indicando que el correo fue enviado correctamente.
- Si ocurre un error (por ejemplo, credenciales incorrectas o límite de envío), se captura la excepción y se muestra el mensaje de error en pantalla.

De esta forma, el usuario puede visualizar claramente el estado del envío directamente desde la interfaz del juego.

---

## Interfaz

La interfaz permite:

- Ingresar el correo destino.
- Iniciar la partida.
- Visualizar el puntaje actual.
- Ver el estado del envío del correo (enviando, éxito o error).

Esto permite observar claramente todo el flujo desde el evento del juego hasta la notificación por email.
