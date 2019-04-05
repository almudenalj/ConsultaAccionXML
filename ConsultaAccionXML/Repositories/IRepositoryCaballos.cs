using ConsultaAccionXML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaAccionXML.Repositories
{
    public interface IRepositoryCaballos
    {
        List<Caballo> GetCaballos();
        Caballo BuscarCaballo(int idcaballo);
        void InsertarCaballo(int idcaballo, String nombre, String nivel, int edad);
        void EliminarCaballo(int idcaballo);
        
    }
}
