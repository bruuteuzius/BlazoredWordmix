using NUnit.Framework;
using BlazoredWordmix.Web.Models;
using System.Collections.Generic;
using System.Text; 
using System; 

namespace BlazoredWordmix.Tests
{
    [TestFixture]
    public class WoordenMatrix
    {
        private List<Woord> _woorden;
        private List<Kant> _dobbelstenen;

        [SetUp]
        public void Setup()
        {
            _woorden = new List<Woord>{ 
                new Woord { Value = "leuk" },
                new Woord { Value = "koel" },
                new Woord { Value = "klem" },
                new Woord { Value = "komt" },
                new Woord { Value = "leek" },
             };

             _dobbelstenen = new List<Kant> {
                 new Kant{ Score = 2, Letter = "l" },
                 new Kant{ Score = 1, Letter = "e" },
                 new Kant{ Score = 2, Letter = "u" },
                 new Kant{ Score = 3, Letter = "k" },
                 new Kant{ Score = 2, Letter = "o" },
                 new Kant{ Score = 3, Letter = "m" },
                 new Kant{ Score = 2, Letter = "t" },
             };
        }

        [Test]
        public void OverzichtXY()
        {
            var sb = new StringBuilder();

            sb.Append("woord/letter");
            foreach(var letter in _dobbelstenen) {
                sb.Append($";{letter.Letter}-{letter.Score}");
            }
            sb.AppendLine(";");
            for(int w=0; w < _woorden.Count; w++) {
                sb.Append($"{_woorden[w].Value};");
                for(int k=0; k < _dobbelstenen.Count; k++) {
                    sb.Append($"{_dobbelstenen[k].Score};");
                }
                sb.AppendLine();
            }           

            Console.WriteLine(sb.ToString());            
        }
    }
}