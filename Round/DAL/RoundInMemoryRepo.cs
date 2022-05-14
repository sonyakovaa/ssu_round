using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using RoundProject.Entities;

namespace RoundProject.DAL
{
    public class RoundInMemoryRepo : IRoundRepo
    {
        private readonly List<Round> _rounds;
        private int _counter;

        public RoundInMemoryRepo(List<Round> rounds)
        {
            _rounds = new List<Round>(rounds);
            _counter = _rounds.Count;
        }
        public RoundInMemoryRepo()
        {
            _rounds = new List<Round>();
            _counter = _rounds.Count;
        }
        public int GetId(Round round)
        {
            return round.Id;
        }
        public Round Add(Round round)
        {
            if (round.Id.Equals(0))
            {
                if (round.RADIUS > 0)
                {
                    round.Id = _rounds.Count + 1;
                    _rounds.Add(round);
                    RoundFileRepo roundFileRepo = new RoundFileRepo();
                    roundFileRepo.Serialize(_rounds);
                    return round;
                }
                else
                {
                    throw new Exception("Round incorrect");
                }
            }
            else
            {
                throw new Exception("Round already exists");
            }
        }

        public List<Round> GetAll()
        {
            return _rounds;
        }

        public Round Update(int id, Round round)
        {
            foreach (Round rnd in _rounds)
            {
                if (rnd.Id == id)
                {
                    if (rnd.RADIUS > 0)
                    {
                        rnd.A = round.A;
                        rnd.RADIUS = round.RADIUS;
                        RoundFileRepo roundFileRepo = new RoundFileRepo();
                        roundFileRepo.Serialize(_rounds);
                        return rnd;
                    }
                    else
                    {
                        throw new Exception("Round incorrect");
                    }
                }
            }
            throw new Exception("Round not found");
        }

        public bool Delete(int id)
        {
            for (int i = 0; i < _rounds.Count; ++i)
            {
                if (_rounds[i].Id == id)
                {
                    _rounds.RemoveAt(i);
                    for (int j = i; j < _rounds.Count; j++)
                    {
                        _rounds[j].Id -= 1;
                    }
                    RoundFileRepo roundFileRepo = new RoundFileRepo();
                    roundFileRepo.Serialize(_rounds);
                    return true;
                }
            }

            return false;
        }
    }
}
