using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_horas_trabajo
{
    public class Proyecto
    {
        public int idProject;
        public string projectName;
        public int projectCategoria;
        public int hoursDuration;
        public DateTime startDate;
        public Boolean assigned;
        public Boolean finished;
        public int idDev;

        public Proyecto()
        {
        }

        public Proyecto(int idProject, string projectName, int projectCategoria, int hoursDuration, DateTime startDate)
        {
            this.idProject = idProject;
            this.projectName = projectName;
            this.projectCategoria = projectCategoria;
            this.hoursDuration = hoursDuration;
            this.startDate = startDate;
            this.assigned = false;
            this.finished = false;
        }

        //Metodo para escribir los detalles del proyecto
        public void detailsProject()
        {
            Console.WriteLine($"Nombre del proyecto: {this.projectName}");
            Console.WriteLine($"Categoria: {this.projectCategoria}");
            Console.WriteLine($"Fechas de inicio: {this.startDate}");
            Console.WriteLine($"Duración: {this.hoursDuration} horas");
            if (assigned)
            {
                Console.WriteLine("Asignado: Si");
            }
            else
            {
                Console.WriteLine("Asignado: No");
            }

            if (finished)
            {
                Console.WriteLine("Estado: Finalizado");
            }
            else
            {
                Console.WriteLine("Estado: En progreso");
            }
        }

        //Metodo para asignar un Desarrollador a un proyecto y cambiar su estado a asignado
        public void AssignDeveloper(int idDev)
        {
            this.idDev = idDev;
            this.assigned = true;
        }

        //Metodo para escribir los proyectos contenidos en una lista
        public void listProjects(List<Proyecto> Projects)
        {
            foreach (Proyecto projec in Projects)
            {
                Console.WriteLine($"Id: {projec.idProject} Nombre: {projec.projectName}");
                Console.WriteLine();
            }
        }

        //Metodo para escribir los proyectos contenidos en una lista filtrando por condiciones finalizados, no finalizados, asignados o no asignados
        public void listProjects(List<Proyecto> Projects, bool ban, int op)
        {
            foreach (Proyecto projec in Projects)
            {
                switch (op)
                {
                    case 1:
                        if (projec.finished == ban)
                        {
                            Console.WriteLine($"Id: {projec.idProject} Nombre: {projec.projectName}");
                            Console.WriteLine();
                        }
                        break;

                    case 2:
                        if (projec.assigned == ban)
                        {
                            Console.WriteLine($"Id: {projec.idProject} Nombre: {projec.projectName}");
                            Console.WriteLine();
                        }
                        break;
                }               
            }
        }

        //Metodo para obtener un proyecto especifico de una lista mediante su id
        public Proyecto listProjects(List<Proyecto> Projects, int idAssi)
        {
            foreach (Proyecto projec in Projects)
            {
                if (projec.idProject == idAssi)
                {
                    return projec;
                    
                }
            }
            return null;
        }

        //Metodo para cambiar el estado de un proyecto a finalizado
        public void finishProject()
        {
            this.finished = true;
        }
    }
}
