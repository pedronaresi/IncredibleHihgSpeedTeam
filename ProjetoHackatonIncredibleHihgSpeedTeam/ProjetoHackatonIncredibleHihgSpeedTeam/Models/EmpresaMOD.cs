using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Models
{
    public class EmpresaMOD
    {
        public EmpresaMOD()
        {
            Carreira = new CarreiraMOD();
        }
        public Int32 ID { get; set; }
        public String Nome { get; set; }
        public CarreiraMOD Carreira{ get; set; }
    }
}