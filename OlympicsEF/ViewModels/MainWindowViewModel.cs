using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympicsEF.Models;
using System.Data.Entity;

namespace OlympicsEF.ViewModels
{
    class MainWindowViewModel
    {
        private List<Medal> _dati;

        public List<Medal> Dati
        {
            get { return _dati; }
            set { _dati = value; }
        }

        public MainWindowViewModel()
        {
            using(OlympicsContext context = new OlympicsContext())
            {
                /*
                List<athlete> athletes = context.athletes
                    //.Where(a => a.IdAthlete == 7 && a.Year == 1992)
                    .Where(a => a.NOC.Contains("ITA"))
                    .OrderBy(ob => ob.IdAthlete).ThenByDescending(ob=> ob.Id)
                    .Skip(10)
                    .Take(10)
                    .ToList();

                athlete primo = context.athletes
                    //.Where(a => a.Year == 1992)
                    .OrderBy(ob => ob.Name).FirstOrDefault(a => a.Year == 19920);

                //Età media dei medagliati
                double? avg = context.athletes
                    .Where(q => q.Medal != null)
                    .Where(q => q.Age != null)
                    .Average(a => a.Age);

                //Età massima medagliati
                int co = context.athletes
                    .Where(q => q.Medal != null)
                    .Where(q => q.Age != null)
                    .Count();

                //Elenco nazioni partecipanti nel 2012
                var nazioni = context.athletes
                    .Where(q => q.Year == 2012)
                    .Select(s => new Nazione
                    {
                        NOC = s.NOC //Equivalente a: (quando anonimo l'oggetto creato)
                        //s.NOC
                    }).Distinct().OrderBy(ob => ob.NOC).ToList();
                Dati = nazioni;

                var p = context.athletes.Where(q => q.Year == 2012)
                    .GroupBy(gb => new
                    {
                        gb.NOC
                    })
                    .Select(s => new
                    { 
                        s.Key.NOC, Partecipations = s.Count()
                    }).Where(q => q.Partecipations > 100)
                    .OrderBy(ob => ob.NOC)
                    .ToList();

                

                //Tutti i medagliati
                var q1 = context.AthletesNFs//.Include(i => i.Medals)
                    .Where(q => q.Medals.Count() > 0)
                    .ToList();

                //Tutti i medagliati d'oro
                var q2 = context.AthletesNFs
                    .Where(q => q.Medals.Any(a => a.Medal1 == "Gold"))
                    .ToList();


                List<Medal> q3 = context.Medals
                    .Include(i => i.AthletesNF)
                    .ToList();
                
                Dati = q3;
                */

                //var es1 = context.

            }
        }

    }
}
