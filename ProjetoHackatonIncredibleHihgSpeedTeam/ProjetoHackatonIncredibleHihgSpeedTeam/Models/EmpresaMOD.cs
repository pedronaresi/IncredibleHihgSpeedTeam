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
            ID_CARREIRA = new CarreiraMOD();
        }
        public Int32 ID { get; set; }
        public String NM_NOME { get; set; }
        public CarreiraMOD ID_CARREIRA{ get; set; }
    }
}