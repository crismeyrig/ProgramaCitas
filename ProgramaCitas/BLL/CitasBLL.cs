using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ProgramaCitas.Entidades;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using ProgramaCitas.DAL;

namespace ProgramaCitas.BLL
{

    public class CitasBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.cita.Any(e => e.CitaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        //———————————————————————————————————————————————————[ GUARDAR - REGISTRO ]———————————————————————————————————————————————————
        public static bool Guardar(Citas cita)
        {
            if (!Existe(cita.CitaId))
                return Insertar(cita);
            else
                return Modificar(cita);
        }
        
        //———————————————————————————————————————————————————[ MODIFICAR - EN LA BD ]———————————————————————————————————————————————————
        private static bool Modificar(Citas cita)
        {
            Contexto contexto = new Contexto();
            bool modificado = false;

            try
            {
                contexto.Entry(cita).State = EntityState.Modified;
                modificado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return modificado;
        }
        //———————————————————————————————————————————————————[ ELIMINAR - REGISTRO ]———————————————————————————————————————————————————
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var usuario = contexto.Citas.Find(id);

                if (usuario != null)
                {
                    contexto.Citas.Remove(Cita);
                    eliminado = (contexto.SaveChanges() > 0);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return eliminado;
        }
        //———————————————————————————————————————————————————[ BUSCAR - REGISTRO ]———————————————————————————————————————————————————
        public static Citas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Citas usuario = new Citas();

            try
            {
                usuario = contexto.Citas.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return usuario;
        }
        //———————————————————————————————————————————————————[ LISTAR ]———————————————————————————————————————————————————
        public static List<Citas> GetList(Expression<Func<Citas, bool>> cita)
        {
            Contexto contexto = new Contexto();
            List<citas> Lista = new List<Citas>();

            try
            {
                Lista = contexto.Citas.Where(cita).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Lista;
        }
       
        
        //——————————————————————————————————————————————[ GET ]——————————————————————————————————————————————
        public static List<Citas> GetCitas()
        {
            List<Citas> lista = new List<Citas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Citas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}