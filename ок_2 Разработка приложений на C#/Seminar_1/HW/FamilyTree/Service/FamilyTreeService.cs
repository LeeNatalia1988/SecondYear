using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTree.Model;

namespace FamilyTree.Service
{
    internal class FamilyTreeService
    {
        private List<FamilyMember> Family { get; set; }


        public FamilyTreeService()
        {
            Family = new List<FamilyMember>();
        }

        public void AddPerson(params FamilyMember[] member)
        {
            if (member != null && member.Length > 0)
            {
                Family.AddRange(member);
            }
        }

        public FamilyMember GetFather(FamilyMember member) => member.Father;

        public FamilyMember GetMother(FamilyMember member) => member.Mother;

        public FamilyMember GetPartner(FamilyMember member) => member.Partner;
    }
}
