using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_horas_trabajo
{
    public class Registro_Horas
    {
        public DateTime registrationDay;
        public int hours;
        public int idDeveloper;
        public int idProject;

        public Registro_Horas()
        {
        }

        public Registro_Horas(DateTime registrationDay, int hours, int idDeveloper, int idProject)
        {
            this.registrationDay = registrationDay;
            this.hours = hours;
            this.idDeveloper = idDeveloper;
            this.idProject = idProject;
        }


    }
}
