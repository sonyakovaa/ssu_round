using System;
using System.IO;
using RoundProject.BLL;
using RoundProject.DAL;
using RoundProject.PLL;
using System.Text.Json;
using RoundProject.Entities;
using System.Collections.Generic;

namespace RoundProject
{
    class Program
    {
        static void Main(string[] args)
        {
            const string _nameJsonFile = "Round.json";
            if (File.Exists(_nameJsonFile))
            {
                string objectJsonFile = File.ReadAllText(_nameJsonFile);
                List<Round> rounds = JsonSerializer.Deserialize<List<Round>>(objectJsonFile);

                IRoundRepo roundRepo = new RoundInMemoryRepo(rounds);
                IRoundLogic roundLogic = new RoundLogicImpl(roundRepo);
                ConsoleInterface consoleInterface = new ConsoleInterface(roundLogic);
                consoleInterface.Start();
            }
            else
            {
                IRoundRepo roundRepo = new RoundInMemoryRepo();
                IRoundLogic roundLogic = new RoundLogicImpl(roundRepo);
                ConsoleInterface consoleInterface = new ConsoleInterface(roundLogic);
                consoleInterface.Start();
            }
        }
    }
}
