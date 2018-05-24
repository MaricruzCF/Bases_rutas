using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases_rutas
{
    class Lista
    {
        private Base _primero = null;

        public void AgregarFinal(Base base_)
        {
            // En caso de lista vacia
            if (_primero == null)
            {
                _primero = base_;
                _primero.Siguiente = _primero;
            }
            else
            {
                Base temp = _primero;
                while (temp.Siguiente != _primero)
                    temp = temp.Siguiente;
                base_.Siguiente = _primero;
                temp.Siguiente = base_;
            }
        }

        public Base Buscar(string nombre)
        {
            if (_primero == null)
                return null;
            else if (_primero.Siguiente == _primero)
            {
                if (_primero.Nombre == nombre)
                    return _primero;
                return null;
            }
            else
            {
                Base temp = _primero;
                while (temp.Siguiente != _primero)
                {
                    if (temp.Nombre == nombre)
                        return temp;
                    temp = temp.Siguiente;
                }
                return null;
            }
        }

        public Base EliminarUltimo()
        {
            if (_primero == null)
                return null;
            else if (_primero.Siguiente == _primero)
            {
                Base temp = _primero;
                _primero = null;
                temp.Siguiente = null;
                return temp;
            }
            else
            {
                Base anterior = _primero;
                Base actual = _primero.Siguiente;

                while (actual.Siguiente != _primero)
                {
                    anterior = actual;
                    actual = actual.Siguiente;
                }

                anterior.Siguiente = _primero;
                actual.Siguiente = null;
                return actual;
            }
        }

        public Base EliminarInicio()
        {
            if (_primero == null)
                return null;
            else if (_primero.Siguiente == _primero)
            {
                Base temp = _primero;
                _primero = null;
                temp.Siguiente = null;
                return temp;
            }
            else
            {
                Base temp = _primero.Siguiente;

                while (temp.Siguiente != _primero)
                    temp = temp.Siguiente;

                temp.Siguiente = _primero.Siguiente;
                Base eliminado = _primero;
                _primero = temp.Siguiente;
                eliminado.Siguiente = null;
                return eliminado;
            }
        }

        public Base Eliminar(string nombre)
        {
            if (_primero == null)
                return null;
            else if (_primero.Siguiente == _primero)
            {
                if (_primero.Nombre == nombre)
                {
                    Base temp = _primero;
                    _primero = null;
                    temp.Siguiente = null;
                    return temp;
                }
                return null;
            }
            else if (_primero.Nombre == nombre)
            {
                Base temp = _primero.Siguiente;

                while (temp.Siguiente != _primero)
                    temp = temp.Siguiente;

                temp.Siguiente = _primero.Siguiente;
                Base eliminado = _primero;
                _primero = temp.Siguiente;
                eliminado.Siguiente = null;
                return eliminado;
            }
            else
            {
                Base anterior = _primero;
                Base actual = _primero.Siguiente;

                while (actual.Siguiente != _primero)
                {
                    if (actual.Nombre == nombre)
                    {
                        anterior.Siguiente = actual.Siguiente;
                        actual.Siguiente = null;
                        return actual;
                    }
                    anterior = actual;
                    actual = actual.Siguiente;
                }

                if (actual.Nombre == nombre)
                {
                    anterior.Siguiente = actual.Siguiente;
                    actual.Siguiente = null;
                    return actual;
                }
                return null;
            }
        }

        public string Listar()
        {
            if (_primero != null)
            {
                string str = _primero.ToString() + System.Environment.NewLine; ;
                Base temp = _primero;
                while (temp.Siguiente != _primero)
                {
                    str += temp.Siguiente.ToString() + System.Environment.NewLine;
                    temp = temp.Siguiente;
                }
                return str;
            }
            return "null";
        }

        public string Ruta(string nombreBase, System.DateTime horaInicio, System.DateTime horaFin)
        {
            Base temp = Buscar(nombreBase);
            if (temp != null)
            {
                string str = temp.Nombre + ": " + horaInicio + System.Environment.NewLine;
                while (horaInicio < horaFin)
                {
                    horaInicio = horaInicio.AddMinutes(temp.Duracion);
                    temp = temp.Siguiente;
                    str += temp.Nombre + ": " + horaInicio + System.Environment.NewLine;
                }
                return str;
            }
            return "null";
        }
    }
}
