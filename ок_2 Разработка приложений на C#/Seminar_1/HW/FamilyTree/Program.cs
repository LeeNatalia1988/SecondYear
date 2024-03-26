using FamilyTree.Model;
using FamilyTree.Service;
using FamilyTree.View;

namespace FamilyTree
{
    internal class Program
    {
        public static void Main(string[] args) {

            FamilyMember familyMember_5 = new FamilyMember()
            {
                Name = "Елена",
                SurName = "Иванова",
                DateOfBirth = new DateTime(1968, 07, 11),
                Gender = Gender.Female
            };// мама

            FamilyMember familyMember_6 = new FamilyMember()
            {
                Name = "Александр",
                SurName = "Иванов",
                DateOfBirth = new DateTime(1968, 04, 08),
                Gender = Gender.Male
            };// папа

            familyMember_5.Partner = familyMember_6;
            familyMember_6.Partner = familyMember_5;

            FamilyMember familyMember_7 = new FamilyMember()
            {
                Name = "Светлана",
                SurName = "Ли",
                DateOfBirth = new DateTime(1964, 03, 01),
                Gender = Gender.Female
            };// свекровь

            FamilyMember familyMember_8 = new FamilyMember()
            {
                Name = "Эдуард",
                SurName = "Ли",
                DateOfBirth = new DateTime(1964, 09, 15),
                Gender = Gender.Male
            };// свекр

            familyMember_7.Partner = familyMember_8;
            familyMember_8.Partner = familyMember_7;

            FamilyMember familyMember_1 = new FamilyMember()
            {
                Name = "Наталья",
                SurName = "Ли",
                DateOfBirth = new DateTime(1988, 01, 03),
                Gender = Gender.Female,
                Mother = familyMember_5,
                Father = familyMember_6
            };// я

            FamilyMember familyMember_2 = new FamilyMember()
            {
                Name = "Феликс",
                SurName = "Ли",
                DateOfBirth = new DateTime(1990, 08, 31),
                Gender = Gender.Male,
                Mother = familyMember_7,
                Father = familyMember_8
            };// Феликс

            familyMember_1.Partner = familyMember_2;
            familyMember_2.Partner = familyMember_1;

            FamilyMember familyMember_3 = new FamilyMember()
            {
                Name = "Владислав",
                SurName = "Ли",
                DateOfBirth = new DateTime(2014, 06, 14),
                Gender = Gender.Male,
                Mother = familyMember_1,
                Father = familyMember_2
            };// сын

            FamilyMember familyMember_4 = new FamilyMember()
            {
                Name = "Лия",
                SurName = "Ли",
                DateOfBirth = new DateTime(2018, 06, 20),
                Gender = Gender.Female,
                Mother = familyMember_1,
                Father = familyMember_2
            };// дочь

            var service = new FamilyTreeService();
            service.AddPerson(familyMember_8, familyMember_7, familyMember_6, familyMember_5, familyMember_4, familyMember_3,
                familyMember_2, familyMember_1);

            SearchView.SayHello();
            int personForSearch = SearchView.SearchRelatives();
            if (personForSearch == 1)
            {
                Console.WriteLine($"\tСупруг/Супруга для: {familyMember_1.Name} {familyMember_1.SurName}\n" +
                $"{service.GetPartner(familyMember_1)}");
                Console.WriteLine();
                Console.WriteLine($"\tЕго/Её родители:\n{service.GetFather(service.GetPartner(familyMember_1))}\n" + 
                $"{service.GetMother(service.GetPartner(familyMember_1))}");

            }
            else if (personForSearch == 2)
            {
                Console.WriteLine($"\tСупруг/Супруга для: {familyMember_2.Name} {familyMember_2.SurName}\n" +
               $"{service.GetPartner(familyMember_2)}");
                Console.WriteLine();
                Console.WriteLine($"\tЕго/Её родители:\n{service.GetFather(service.GetPartner(familyMember_2))}\n" +
                $"{service.GetMother(service.GetPartner(familyMember_2))}");
            }
            else
            {
                Console.WriteLine("Что-то пошло не так...");
            }
        }
    }
 }

