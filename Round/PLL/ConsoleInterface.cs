using System;
using System.Collections.Generic;
using System.Text;
using RoundProject.BLL;

namespace RoundProject.PLL
{
    class ConsoleInterface
    {
        private const string AddRound = "ADD";
        private static readonly string[] AddRoundArgs = { "X", "Y", "RADIUS" };

        private const string GetRound = "GET";
        private static readonly string[] GetRoundArgs = { "ID" };

        private const string GetRounds = "GETALL";

        private const string LengthCircle = "LENGTH_CIRCLE";
        private static readonly string[] LengthCircleArgs = { "ID" };

        private const string SquareCircle = "SQUARE_CIRCLE";
        private static readonly string[] SquareCircleArgs = { "ID" };

        private const string UpdateRound = "UPDATE";
        private static readonly string[] UpdateRoundArgs = { "ID", "NEW_X", "NEW_Y", "NEW_RADIUS" };

        private const string DeleteRound = "DELETE";
        private static readonly string[] DeleteRoundArgs = { "ID" };

        private const string Hint = "HINT";
        private const string Exit = "EXIT";

        private const string UnknownCommand = "UNKNOWN COMMAND";
        private const string WrongArgument = "Wrong argument(s)";

        private readonly IRoundLogic _roundLogic;

        public ConsoleInterface(IRoundLogic roundLogic)
        {
            this._roundLogic = roundLogic;
        }

        public void Start()
        {
            Console.WriteLine(GetHint());
            for (; ; )
            {
                try
                {
                    Console.Write(">>> ");
                    List<String> arguments = new List<String>(Console.ReadLine().Split(" "));
                    string command = arguments[0].ToUpper();
                    arguments.RemoveAt(0);
                    switch (command)
                    {
                        case AddRound:
                            if (arguments.Count != AddRoundArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_roundLogic.Create(int.Parse(arguments[0]), int.Parse(arguments[1]),
                                                                        int.Parse(arguments[2])));
                            }

                            break;
                        case GetRound:
                            if (arguments.Count != GetRoundArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_roundLogic.Find(Convert.ToInt32(arguments[0])));
                            }

                            break;
                        case GetRounds:
                            Console.WriteLine(String.Join("\n", _roundLogic.FindAll()));
                            break;
                        case UpdateRound:
                            if (arguments.Count != UpdateRoundArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_roundLogic.Update(
                                    Convert.ToInt32(arguments[0]),
                                    Convert.ToInt32(arguments[1]),
                                    Convert.ToInt32(arguments[2]),
                                    Convert.ToInt32(arguments[3])));
                            }

                            break;
                        case DeleteRound:
                            if (arguments.Count != GetRoundArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_roundLogic.Delete(Convert.ToInt32(arguments[0])));
                            }
                            break;
                        case LengthCircle:
                            if (arguments.Count != LengthCircleArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_roundLogic.LengthCircle(int.Parse(arguments[0])));
                            }
                            break;
                        case SquareCircle:
                            if (arguments.Count != SquareCircleArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_roundLogic.SquareCircle(int.Parse(arguments[0])));
                            }
                            break;
                        case Hint:
                            Console.WriteLine(GetHint());
                            break;
                        case Exit:
                            return;
                        default:
                            Console.WriteLine(UnknownCommand);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static String GetHint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AddRound).Append(": ").Append(String.Join(", ", AddRoundArgs)).Append('\n');
            sb.Append(GetRounds).Append('\n');
            sb.Append(GetRound).Append(": ").Append(String.Join(", ", GetRoundArgs)).Append('\n');
            sb.Append(UpdateRound).Append(": ").Append(String.Join(", ", UpdateRoundArgs)).Append('\n');
            sb.Append(DeleteRound).Append(": ").Append(String.Join(", ", DeleteRoundArgs)).Append('\n');
            sb.Append(LengthCircle).Append(": ").Append(String.Join(", ", LengthCircleArgs)).Append('\n');
            sb.Append(SquareCircle).Append(": ").Append(String.Join(", ", SquareCircleArgs)).Append('\n');
            ;
            sb.Append(Hint).Append('\n');
            sb.Append(Exit).Append('\n');

            return sb.ToString();
        }
    }
}
