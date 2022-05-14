using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using RoundProject.Entities;
using System.Runtime.Serialization.Json;

namespace RoundProject.DAL
{
    class RoundFileRepo
    {
        public void Serialize(List<Round> rounds)
        {
            string objectSerialized = JsonSerializer.Serialize(rounds);
            File.WriteAllText("Round.json", objectSerialized);
        }
    }
}
