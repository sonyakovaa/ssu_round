using System;
using System.Collections.Generic;
using System.Text;
using RoundProject.Entities;
using RoundProject.DAL;

namespace RoundProject.BLL
{
    public class RoundLogicImpl : IRoundLogic
    {
        private readonly IRoundRepo _roundRepo;

        public RoundLogicImpl(IRoundRepo roundRepo)
        {
            this._roundRepo = roundRepo;
        }

        public Round Create(int a1, int a2, int r)
        {
            if (r > 0)
            {
                Point a = new Point { X = a1, Y = a2 };
                Round round = new Round { A = a, RADIUS = r };
                return _roundRepo.Add(round);
            }
            else
            {
                throw new Exception("Incorrect radius");
            }
        }

        public List<Round> FindAll()
        {
            List<Round> rounds = _roundRepo.GetAll();
            return rounds;
        }

        public Round Update(int id, int a1, int a2, int r)
        {
            if (r > 0)
            {
                Point a = new Point { X = a1, Y = a2 };
                Round roundTemplate = new Round { A = a, RADIUS = r };
                return _roundRepo.Update(id, roundTemplate);
            }
            else
            {
                throw new Exception("Incorrect radius");
            }
        }

        public bool Delete(int id)
        {
            return _roundRepo.Delete(id);
        }

        public Round Find(int id)
        {
            List<Round> rounds = _roundRepo.GetAll();
            foreach (Round rnd in rounds)
            {
                if (rnd.Id == id)
                {
                    return rnd;
                }
            }

            return null;
        }

        public double LengthCircle(int id)
        {
            List<Round> rounds = _roundRepo.GetAll();
            bool flag = false;
            foreach (Round r in rounds)
            {
                if (r.Id == id)
                {
                    flag = true;
                    return r.LengthCircle(r.RADIUS);
                }
            }

            if (flag == false)
            {
                Console.WriteLine("Incorrect ID");
            }

            return -1.0;
        }

        public double SquareCircle(int id)
        {
            List<Round> rounds = _roundRepo.GetAll();
            bool flag = false;
            foreach (Round r in rounds)
            {
                if (r.Id == id)
                {
                    flag = true;
                    return r.SquareCircle(r.RADIUS);
                }
            }

            if (flag == false)
            {
                Console.WriteLine("Incorrect ID");
            }

            return -1.0;
        }
    }
}
