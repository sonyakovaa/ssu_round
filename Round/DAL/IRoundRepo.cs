using System;
using System.Collections.Generic;
using System.Text;
using RoundProject.Entities;

namespace RoundProject.DAL
{
    public interface IRoundRepo
    {
        Round Add(Round round);

        Round Update(int id, Round round);
        
        int GetId(Round round);

        List<Round> GetAll();

        Boolean Delete(int id);
    }
}
