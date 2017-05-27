using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Models
{
    public class AlunoMOD
    {
        public AlunoMOD()
        {
            ID_CARREIRA = new CarreiraMOD();
        }
        public Int32 ID { get; set; }
        public String NM_Nome{ get; set; }
        public CarreiraMOD ID_CARREIRA { get; set; }
    }
}