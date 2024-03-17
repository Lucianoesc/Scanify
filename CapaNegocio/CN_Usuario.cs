﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();

        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();
        }
        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Username == "")
            {
                Mensaje += "Es necesario el username del usuario\n";
            }
            if (obj.Clave == "")
            {
                Mensaje += "Es necesario la clave del usuario\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del usuario\n";
            }
            if (obj.Apellido == "")
            {
                Mensaje += "Es necesario el apellido del usuario\n";
            }
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario del documento del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.Registrar(obj, out Mensaje);
            }
        }
        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Username == "")
            {
                Mensaje += "Es necesario el username del usuario\n";
            }

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario del documento del usuario\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del usuario\n";
            }
            if (obj.Apellido == "")
            {
                Mensaje += "Es necesario el apellido del usuario\n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Es necesario la clave del usuario\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }
        }
        public bool ActualizarDigitoVerificador(int idUsuario, out char digitoVerificador, out string mensaje)
        {
            bool exito = false;
            digitoVerificador = '\0';
            mensaje = string.Empty;

            try
            {
                exito = objcd_usuario.ActualizarDigitoVerificador(idUsuario, out digitoVerificador, out mensaje);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                // Manejar la excepción según sea necesario
            }

            return exito;
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);

        }


    }
}
