using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class denunciaCN
    {
        private denunciaCD denunciaData = new denunciaCD();

        public string GuardarDenuncia(Denuncia d)
        {
            return denunciaData.RegistrarDenuncia(d);
        }

        public List<Denuncia> ObtenerDenuncias(string estado)
        {
            return denunciaData.ListarDenuncias(estado);
        }

        public string ResponderDenuncia(int id, int usuarioID, string respuesta, string nuevoEstado)
        {
            // 🟡 Primero obtenemos la denuncia por su ID
            Denuncia denuncia = denunciaData.ObtenerPorID(id); // Asegúrate de tener este método en denunciaCD

            if (denuncia == null)
                return "La denuncia no existe";

            // 🟡 Actualizamos en base de datos
            string resultadoBD = denunciaData.ActualizarRespuesta(
                denuncia.DenunciaID,
                usuarioID,
                respuesta,
                nuevoEstado
            );

            if (resultadoBD != "ok") return resultadoBD;

            // 🟡 Enviar correo si hay correo registrado
            if (!string.IsNullOrWhiteSpace(denuncia.Correo))
            {
                try
                {
                    MailMessage mensaje = new MailMessage();
                    mensaje.To.Add(denuncia.Correo);
                    mensaje.Subject = "Respuesta a su denuncia sanitaria - SIRESA";
                    mensaje.IsBodyHtml = true;
                    mensaje.Body = $@"
                        Estimada/o {denuncia.Nombres},<br><br>
                        Hemos recibido su denuncia y le informamos lo siguiente:<br><br>
                        <b>Respuesta:</b> {respuesta}<br><br>
                        Gracias por ayudarnos a mejorar la vigilancia sanitaria.<br><br>
                        Atentamente,<br>
                        <b>SIRESA - Supervisión Municipal</b>";

                    mensaje.From = new MailAddress("TUCORREO@gmail.com", "SIRESA Denuncias");

                    SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                    cliente.Credentials = new NetworkCredential("TUCORREO@gmail.com", "TU_CONTRASEÑA_APP");
                    cliente.EnableSsl = true;

                    cliente.Send(mensaje);
                }
                catch (Exception ex)
                {
                    return "error al enviar correo: " + ex.Message;
                }
            }

            return "ok";
        }
    }
}
