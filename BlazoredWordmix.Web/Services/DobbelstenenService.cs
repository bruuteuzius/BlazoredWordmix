using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazoredWordmix.Web.Models;


namespace BlazoredWordmix.Web.Services
{
    public class DobbelstenenService
    {
        private Random _random;

        public DobbelstenenService()
        {
            _random = new Random();
        }

        public List<Dobbelsteen> GetDobbelStenen()
        {
            var result = new List<Dobbelsteen>();
            for (int i = 1; i <= Constantes.AANTAL_DOBBELSTENEN; i++)
            {
                var kant = this.RandomKant(i);
                result.Add(new Dobbelsteen(kant));
            }

            return result;
        }

        public List<Woord> GetOplossing(List<Dobbelsteen> dobbelstenen)
        {
            var result = new List<Woord>();

            var bestand = File.ReadAllLines("wordlist.txt");
            var woordenlijst = new List<string>(bestand);
            
            // O H Z J D P I E A E S S R
            // 2 2 5 5 1 4 1 1 1 1 1 1 1

            string besteWoord = null;
            int hoogsteScore = 0;

            foreach (var woord in woordenlijst)
            {
                if (KanVormen(woord, dobbelstenen.Select(l => l.SpeelbareKant.Letter).ToList()))
                {
                    int score = BerekenScore(woord, dobbelstenen.Select(l => l.SpeelbareKant.Letter).ToList(),
                        dobbelstenen.Select(l => l.SpeelbareKant.Score).ToList());
                    if (score > hoogsteScore)
                    {
                        hoogsteScore = score;
                        besteWoord = woord;
                    }
                }
            }
            
            // kan nu alleen nog 1 woord maken, niet meerdere
            result.Add(new Woord { Score = hoogsteScore, Value = besteWoord });

            static bool KanVormen(string woord, List<char> beschikbareLetters)
            {
                var temp = new List<char>(beschikbareLetters);
                foreach (char c in woord.ToUpper())
                {
                    if (!temp.Remove(c)) return false;
                }

                return true;
            }

            static int BerekenScore(string woord, List<char> letters, List<int> scores)
            {
                int totaal = 0;
                var tempLetters = new List<char>(letters);
                var tempScores = new List<int>(scores);

                foreach (char c in woord.ToUpper())
                {
                    for (int i = 0; i < tempLetters.Count; i++)
                    {
                        if (tempLetters[i] == c)
                        {
                            totaal += tempScores[i];
                            tempLetters.RemoveAt(i);
                            tempScores.RemoveAt(i);
                            break;
                        }
                    }
                }

                return totaal;
            }

            return result;
        }

        public Kant RandomKant(int _id)
        {
            return _id switch
            {
                1 => new List<Kant>
                {
                    new Kant { Score = 2, Letter = 'U' },
                    new Kant { Score = 2, Letter = 'H' },
                    new Kant { Score = 2, Letter = 'C' },
                    new Kant { Score = 1, Letter = 'R' },
                    new Kant { Score = 2, Letter = 'O' },
                    new Kant { Score = 1, Letter = 'E' }
                }.ToArray()[_random.Next(0, 5)],
                2 => new List<Kant>
                {
                    new Kant { Score = 2, Letter = 'H' },
                    new Kant { Score = 3, Letter = 'M' },
                    new Kant { Score = 1, Letter = 'R' },
                    new Kant { Score = 1, Letter = 'I' },
                    new Kant { Score = 1, Letter = 'A' },
                    new Kant { Score = 1, Letter = 'F' }
                }.ToArray()[_random.Next(0, 5)],
                3 => new List<Kant>
                {
                    new Kant { Score = 1, Letter = 'N' },
                    new Kant { Score = 5, Letter = 'Z' },
                    new Kant { Score = 4, Letter = 'V' },
                    new Kant { Score = 3, Letter = 'B' },
                    new Kant { Score = 1, Letter = 'E' },
                    new Kant { Score = 1, Letter = 'S' }
                }.ToArray()[_random.Next(0, 5)],
                4 => new List<Kant>
                {
                    new Kant { Score = 2, Letter = 'G' },
                    new Kant { Score = 3, Letter = 'M' },
                    new Kant { Score = 1, Letter = 'E' },
                    new Kant { Score = 5, Letter = 'J' },
                    new Kant { Score = 1, Letter = 'N' },
                    new Kant { Score = 1, Letter = 'S' }
                }.ToArray()[_random.Next(0, 5)],
                5 => new List<Kant>
                {
                    new Kant { Score = 1, Letter = 'A' },
                    new Kant { Score = 1, Letter = 'D' },
                    new Kant { Score = 3, Letter = 'K' },
                    new Kant { Score = 2, Letter = 'O' },
                    new Kant { Score = 1, Letter = 'N' },
                    new Kant { Score = 1, Letter = 'R' }
                }.ToArray()[_random.Next(0, 5)],
                6 => new List<Kant>
                {
                    new Kant { Score = 1, Letter = 'S' },
                    new Kant { Score = 4, Letter = 'P' },
                    new Kant { Score = 1, Letter = 'E' },
                    new Kant { Score = 2, Letter = 'L' },
                    new Kant { Score = 1, Letter = 'S' },
                    new Kant { Score = 2, Letter = 'G' }
                }.ToArray()[_random.Next(0, 5)],
                7 => new List<Kant>
                {
                    new Kant { Score = 2, Letter = 'U' },
                    new Kant { Score = 1, Letter = 'D' },
                    new Kant { Score = 1, Letter = 'E' },
                    new Kant { Score = 2, Letter = 'L' },
                    new Kant { Score = 1, Letter = 'I' },
                    new Kant { Score = 2, Letter = 'T' }
                }.ToArray()[_random.Next(0, 5)],
                8 => new List<Kant>
                {
                    new Kant { Score = 6, Letter = 'X' },
                    new Kant { Score = 2, Letter = 'G' },
                    new Kant { Score = 1, Letter = 'D' },
                    new Kant { Score = 1, Letter = 'E' },
                    new Kant { Score = 3, Letter = 'K' },
                    new Kant { Score = 1, Letter = 'N' }
                }.ToArray()[_random.Next(0, 5)],
                9 => new List<Kant>
                {
                    new Kant { Score = 1, Letter = 'A' },
                    new Kant { Score = 3, Letter = 'B' },
                    new Kant { Score = 2, Letter = 'U' },
                    new Kant { Score = 2, Letter = 'H' },
                    new Kant { Score = 7, Letter = 'Y' },
                    new Kant { Score = 1, Letter = 'I' }
                }.ToArray()[_random.Next(0, 5)],
                10 => new List<Kant>
                {
                    new Kant { Score = 3, Letter = 'F' },
                    new Kant { Score = 1, Letter = 'E' },
                    new Kant { Score = 0, Letter = '#' },
                    new Kant { Score = 2, Letter = 'L' },
                    new Kant { Score = 1, Letter = 'N' },
                    new Kant { Score = 1, Letter = 'R' }
                }.ToArray()[_random.Next(0, 5)],
                11 => new List<Kant>
                {
                    new Kant { Score = 1, Letter = 'D' },
                    new Kant { Score = 3, Letter = 'M' },
                    new Kant { Score = 1, Letter = 'S' },
                    new Kant { Score = 1, Letter = 'I' },
                    new Kant { Score = 2, Letter = 'C' },
                    new Kant { Score = 1, Letter = 'E' }
                }.ToArray()[_random.Next(0, 5)],
                12 => new List<Kant>
                {
                    new Kant { Score = 1, Letter = 'S' },
                    new Kant { Score = 7, Letter = 'Q' },
                    new Kant { Score = 2, Letter = 'H' },
                    new Kant { Score = 1, Letter = 'A' },
                    new Kant { Score = 2, Letter = 'C' },
                    new Kant { Score = 1, Letter = 'I' }
                }.ToArray()[_random.Next(0, 5)],
                13 => new List<Kant>
                {
                    new Kant { Score = 3, Letter = 'W' },
                    new Kant { Score = 1, Letter = 'R' },
                    new Kant { Score = 1, Letter = 'A' },
                    new Kant { Score = 1, Letter = 'D' },
                    new Kant { Score = 2, Letter = 'T' },
                    new Kant { Score = 1, Letter = 'I' }
                }.ToArray()[_random.Next(0, 5)],
                _ => null,
            };
        }
    }
}