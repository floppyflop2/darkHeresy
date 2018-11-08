using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyModel.DTO
{
    class PlayerDTO
    {
        public int Id { get; set; }
        public PersonalInfo Info { get; set; }
        public Characteristic Stats { get; set; }
        public string Background { get; set; }
    }
}
