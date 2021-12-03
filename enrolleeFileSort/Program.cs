using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EnrolleeFileSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read the CSV into a generic list
            List<Enrollee> newMemberList = File.ReadAllLines("C:\\Users\\Public\\enrolleeList.csv")
                                          .Skip(1)
                                          .Select(m => Utilities.parseFile(m))
                                          .ToList();

            //First get the highest version #s
            List<Enrollee> filteredbyVersion = new List<Enrollee>();

            var queryMemberList =
                from member in newMemberList
                group member by member.userId into memberGroup
                orderby memberGroup.Key
                select memberGroup;

            foreach (var nameGroup in queryMemberList)
            {
                Console.WriteLine($"Key: {nameGroup.Key}");
                foreach (var enrollee in nameGroup)
                {

                    Console.WriteLine($"\t{enrollee.userId}, {enrollee.firstName}, {enrollee.lastName}," +
                        $" {enrollee.insuranceCompany}, {enrollee.versionNumber}");
                }

                Enrollee latest = nameGroup.OrderByDescending(p => p.versionNumber).FirstOrDefault();
                filteredbyVersion.Add(latest);
            }                

            //Group the list by Insurance Company Name
            var queryInsuranceCompanies =
            from member in filteredbyVersion//newMemberList
            group member by member.insuranceCompany into newGroup
            orderby newGroup.Key
            select newGroup;

            
            foreach (var insuranceGroup in queryInsuranceCompanies)
            {
                List<Enrollee> finalVersion = new List<Enrollee>();
                Console.WriteLine($"Key: {insuranceGroup.Key}");
                foreach (var insuranceMember in insuranceGroup)
                { 

                    Console.WriteLine($"\t{insuranceMember.userId}, {insuranceMember.firstName}, {insuranceMember.lastName}," +
                        $" {insuranceMember.insuranceCompany}, {insuranceMember.versionNumber}");
                    
                    finalVersion.Add(insuranceMember);  
                }

                //Create a file for each insurance company
                Utilities.ExportCsv(finalVersion, insuranceGroup.Key.ToString());
            }
        }
    }
}
