using System.Collections.Generic;
using System.Threading.Tasks;
using BlazoredWordmix.Web.Models;
using System.Text;
using System;
using System.Linq;


namespace BlazoredWordmix.Web.Services
{
    public class DobbelstenenService
    {
        public DobbelstenenService()
        {
            
        }

        public async Task<List<Dobbelsteen>> GetDobbelStenen(){
            var result = new List<Dobbelsteen>();
            for (int i=1; i<= Constantes.AANTAL_DOBBELSTENEN; i++) {
                result.Add(new Dobbelsteen(i));
            }
            return await Task.FromResult(result);
        }

        public async Task<List<Woord>> GetOplossing(List<Dobbelsteen> dobbelstenen) 
        {
            var result = new List<Woord>();

            /*
                haal lijst op met woorden
                kijk of er woorden zijn waar meer dan de helft van de letters in gebruikt kunnen worden
                leg dat woord neer
                kijk of er met de overige letters een woord gemaakt kan worden
                kunnen de overige woorden dwars op het langste woord gelegd worden?
                
            */

            return await Task.FromResult(result);
        }
    }
}