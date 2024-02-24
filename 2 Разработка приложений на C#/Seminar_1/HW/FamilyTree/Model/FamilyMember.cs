using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.Model
{
    internal class FamilyMember
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public FamilyMember Partner { get; set; }
        public Gender Gender { get; set; }
        public FamilyMember Mother { get; set; }
        public FamilyMember Father { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }


        public override string ToString()
        {
            return $"\tИмя:\t\t\t{Name}\n\tФамилия:\t\t{SurName}\n\tДата рождения:\t\t{DateOfBirth.ToShortDateString()}\n";
        }
    }
}
