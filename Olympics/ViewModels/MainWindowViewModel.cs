using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olympics.Models;

namespace Olympics.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        #region BindingFiltri
        private string _filtroName;

        public string FiltroName
        {
            get { return _filtroName; }
            set
            { 
                _filtroName = value;
                NotifyPropretyChanged("FiltroName");
            }
        }

        private string _filtroSex;

        public string FiltroSex
        {
            get { return _filtroSex; }
            set 
            { 
                _filtroSex = value;
                NotifyPropretyChanged("FiltroSex");
            }
        }

        private string _filtroGames;

        public string FiltroGames
        {
            get { return _filtroGames; }
            set { _filtroGames = value;
                NotifyPropretyChanged("FiltroGames");
            }
        }


        private string _filtroSport;

        public string FiltroSport
        {
            get { return _filtroSport; }
            set { _filtroSport = value;
                NotifyPropretyChanged("FiltroSport");
            }
        }

        private string _filtroEvent;

        public string FiltroEvent
        {
            get { return _filtroEvent; }
            set { _filtroEvent = value;
                NotifyPropretyChanged("FiltroEvent");
            }
        }

        private string _filtroMedal;

        public string FiltroMedal
        {
            get { return _filtroMedal; }
            set { _filtroMedal = value;
                NotifyPropretyChanged("FiltroMedal");
            }
        }

        private int _righePagina;

        public int RighePagina
        {
            get { return _righePagina; }
            set { _righePagina = value;
                NotifyPropretyChanged("RighePagina");
            }
        }

        #endregion

        #region BindingSorgenti

        private List<string> _listaSex;

        public List<string> ListaSex
        {
            get { return _listaSex; }
            set { _listaSex = value;
                NotifyPropretyChanged("ListaSex");
            }
        }

        private List<string> _listaGames;

        public List<string> ListaGames
        {
            get { return _listaGames; }
            set
            {
                _listaGames = value;
                NotifyPropretyChanged("ListaGames");
            }
        }

        private List<string> _listaSport;

        public List<string> ListaSport
        {
            get { return _listaSport; }
            set
            {
                _listaSport = value;
                NotifyPropretyChanged("ListaSport");
            }
        }

        private List<string> _listaEvent;

        public List<string> ListaEvent
        {
            get { return _listaEvent; }
            set
            {
                _listaEvent = value;
                NotifyPropretyChanged("ListaEvent");
            }
        }

        private List<string> _listaMedal;

        public List<string> ListaMedal
        {
            get { return _listaMedal; }
            set
            {
                _listaMedal = value;
                NotifyPropretyChanged("ListaMedal");
            }
        }

        private List<Partecipation> _listaPartecipation;

        public List<Partecipation> ListaPartecipation
        {
            get { return _listaPartecipation; }
            set { _listaPartecipation = value;
                NotifyPropretyChanged("ListaPartecipation");
            }
        }

        private List<int> _listaRighePagina;

        public List<int> ListaRighePagina
        {
            get { return _listaRighePagina; }
            set { _listaRighePagina = value;
                NotifyPropretyChanged("ListaRighePagina");
            }
        }



        #endregion


        internal void Setup()
        {
            ListaRighePagina = new List<int> { 10, 20, 50 };
            RighePagina = 10;

            //TODO popolamenti vari iniziali
            
        }




    }
}
