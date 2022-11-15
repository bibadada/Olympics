using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympicsEF.Models;

namespace OlympicsEF.ViewModels
{
    class MainWindowViewModel
    {
        private List<athlete> _dati;

        public List<athlete> Dati
        {
            get { return _dati; }
            set { _dati = value; }
        }

        public MainWindowViewModel()
        {
            using(OlympicsContext context = new OlympicsContext())
            {
                Dati = context.athletes
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
                double? co = context.athletes
                    .Where(q => q.Medal != null)
                    .Where(q => q.Age != null)
                    .Count();
            }
        }

    }
}
