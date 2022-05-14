using System;
using System.Collections.Generic;
using System.Text;
using RoundProject.Entities;

namespace RoundProject.BLL
{
    public interface IRoundLogic
    {
        Round Create(int xa, int ya, int r);

        List<Round> FindAll();

        Round Update(int id, int xa, int ya, int r);

        Boolean Delete(int id);

        Round Find(int id);
        Double LengthCircle(int id);

        Double SquareCircle(int id);
    }
}
