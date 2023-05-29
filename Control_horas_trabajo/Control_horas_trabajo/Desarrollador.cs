using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Control_horas_trabajo
{
    public class Desarrollador
    {
        public int idDeveloper;
        public String name;
        public DateTime dateAdmission;
        public String email;
        public int category;
        public List<Proyecto> projects;
        public List<Registro_Horas> records;

        public Desarrollador()
        {
        }

        public Desarrollador(int idDeveloper, string name, DateTime dateAdmission, string email, int category)
        {
            this.idDeveloper = idDeveloper;
            this.name = name;
            this.dateAdmission = dateAdmission;
            this.email = email;
            this.category = category;
            this.projects = new List<Proyecto>();
            this.records = new List<Registro_Horas>();  
        }


        //Metodo para escribir los detalles del Desarrollador
        public void Presentacion()
        {
            Console.WriteLine($"Desarrollador categoria: {category}");
            Console.WriteLine($"Nombre: {name}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Fecha de ingreso fue {dateAdmission}");
            Console.WriteLine();
        }

        public int getidDeveloper()
        {
            return this.idDeveloper;
        }

        public void setidDeveloper(int idDeveloper)
        {
            this.idDeveloper = idDeveloper;
        }

        //Metodo para asignar un proyecto al Desarrollador
        public void AssignProject(Proyecto project)
        {
            this.projects.Add(project);
            Console.WriteLine("Asignación exitosa");
        }

        //Metodo para escribir datos de Desarrolladores contenidos en una lista
        public void listDevelopers(List<Desarrollador> Developers)
        {
            foreach (Desarrollador Develop in Developers)
            {
                Console.WriteLine($"Id: {Develop.idDeveloper} Nombre: {Develop.name}");
                Console.WriteLine();
            }
        }

        //Metodo para obtener un Desarrollador especifico de una lista mediante su id
        public Desarrollador listDevelopers(List<Desarrollador> Developers, int idDev)
        {
            foreach (Desarrollador Develop in Developers)
            {
                if (Develop.idDeveloper == idDev)
                {
                    return Develop;

                }
            }
            return null;
        } 

        //Metodo para crear un registro de horas de trabajo
        public bool TimeRecords(int idDev, int idProject)
        {
            Proyecto p = new Proyecto();
            p = p.listProjects(this.projects, idProject);
            if (!p.finished)
            {
                Console.WriteLine("¿Horas a registrar?");
                int hours = int.Parse(Console.ReadLine());

                Console.WriteLine("Fecha de registro de horas (formato YYYY/MM/DD)");
                string timeReg = Console.ReadLine();
                string[] dayHour = timeReg.Split('/');
                DateTime dayHours = new DateTime(int.Parse(dayHour[0]), int.Parse(dayHour[1]), int.Parse(dayHour[2]));

                Registro_Horas timeH = new Registro_Horas(dayHours, hours, idDev, idProject);

                this.records.Add(timeH);

                checkHour(idProject);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Metodo para verificar si el proyecto cumplio con sus horas establecidas, invocado cuando se hace un registro de horas
        public void checkHour(int idProject)
        {
            int hoursWork = 0;
            foreach (Registro_Horas rec in records)
            {
                if(rec.idProject == idProject)
                {
                    hoursWork += rec.hours;
                }
            }

            Proyecto p = new Proyecto();

            p = p.listProjects(this.projects, idProject);
            if(hoursWork >= p.hoursDuration)
            {
                int index = this.projects.IndexOf(p);
                this.projects.Remove(p);
                p.finishProject();
                this.projects.Insert(index, p);
            }
        }

        //Metodo para escribir los proyectos asignados al Desarrollador
        public void ProjectsAssig()
        {
            foreach(Proyecto proj in this.projects)
            {
                proj.detailsProject();
                Console.WriteLine();
            }
        }
    }
}
