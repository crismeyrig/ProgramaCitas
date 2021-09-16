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
        public static bool Guardar(Citas citas)
        {
            if (!Existe(citas.CitaId))
                return Insertar(citas);
            else
                return Modificar(citas);
        }
        private static bool Insertar(Citas citas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Citas.Add(citas);
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Citas citas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(citas).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var citas = contexto.Citas.Find(id);

                if (citas != null)
                {
                    contexto.Citas.Remove(citas);
                    paso = contexto.SaveChanges() > 0;
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

            return paso;
        }

        public static Citas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Citas citas;

            try
            {
                citas = contexto.Citas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return citas;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Citas.Any(e => e.CitaId == id);
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
    }
}
       