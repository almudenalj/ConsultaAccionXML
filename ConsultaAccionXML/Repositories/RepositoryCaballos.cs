using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsultaAccionXML.Models;
using ConsultaAccionXML.Providers;

namespace ConsultaAccionXML.Repositories
{
    public class RepositoryCaballos : IRepositoryCaballos
    {
        PathProvider pathprovider;

        public RepositoryCaballos(PathProvider pathprovider)
        {
            this.pathprovider = pathprovider;
        }

        public List<Caballo> GetCaballos()
        {
            String path =
               this.pathprovider.MapPath("Caballos.xml", Folders.Documents);
            XDocument docxml = XDocument.Load(path);
            var consulta = from datos in docxml.Descendants("caballo")
                          
                           select new Caballo
                           {
                               IdCaballo = int.Parse(datos.Element("idcaballo").Value)
,
                               Nombre = datos.Element("nombre").Value
,
                               Nivel = datos.Element("nivel").Value
,
                               Edad = int.Parse(datos.Element("edad").Value)
                           };
            return consulta.ToList();
        }
        public Caballo BuscarCaballo(int idcaballo)
        {
            String path =
                 this.pathprovider.MapPath("Caballos.xml", Folders.Documents);
            XDocument docxml = XDocument.Load(path);
            var consulta = from datos in docxml.Descendants("caballo")
                           where datos.Element("idcaballo").Value
                           == idcaballo.ToString()
                           select new Caballo
                           {
                               IdCaballo = int.Parse(datos.Element("idcaballo").Value),
 
                               Nombre = datos.Element("nombre").Value,
 
                               Nivel = datos.Element("nivel").Value,
 
                               Edad = int.Parse(datos.Element("edad").Value)
                           };
            return consulta.FirstOrDefault();
        }
        public void InsertarCaballo(int idcaballo, string nombre, string nivel, int edad)
        {
            String path =
                 this.pathprovider.MapPath("Caballos.xml", Folders.Documents);
            XDocument docxml = XDocument.Load(path);
            //TENEMOS QUE CREAR NUEVOS OBJETOS XElement
            XElement xmlcaballo = new XElement("caballo");
            //DEBEMOS CREAR NUEVOS XElement ANIDADOS EN EL NODO CABALLO
            xmlcaballo.Add(new XElement("idcaballo", idcaballo));
            xmlcaballo.Add(new XElement("nombre", nombre));
            xmlcaballo.Add(new XElement("nivel", nivel));
            xmlcaballo.Add(new XElement("edad", edad));
            //DEBEMOS AÑADIR EL XElement AL DOCUMENTO PRINCIPAL
            docxml.Element("caballos").Add(xmlcaballo);
            docxml.Save(path);

        }

        public void EliminarCaballo(int idcaballo)
        {
            String path =
               this.pathprovider.MapPath("Caballos.xml", Folders.Documents);
            XDocument docxml = XDocument.Load(path);
            
            var consulta = from datos in docxml.Descendants("caballo")
                           where datos.Element("idcaballo").Value
                           == idcaballo.ToString()
                           select datos;
            XElement xmlcaballo = consulta.FirstOrDefault();
            xmlcaballo.Remove();
            docxml.Save(path);

        }

    }
}
