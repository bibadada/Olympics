using System.Collections.Generic;
using Olympics.Controllers;
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
                Pagina = 1;
                GetData();
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
                Pagina = 1;
                GetData();
            }
        }

        private string _filtroGames;

        public string FiltroGames
        {
            get { return _filtroGames; }
            set { _filtroGames = value;
                NotifyPropretyChanged("FiltroGames");
                if (value != null)
                    ListaSport = Partecipations.GetDistinctSport(value);
                FiltroEvent = null;
                FiltroSport = null;
                Pagina = 1;
                GetData();
            }
        }

        private string _filtroSport;

        public string FiltroSport
        {
            get { return _filtroSport; }
            set { _filtroSport = value;
                NotifyPropretyChanged("FiltroSport");
                if(value != null)
                    ListaEvent = Partecipations.GetDistinctEvent(value);
                Pagina = 1;
                GetData();
            }
        }

        private string _filtroEvent;

        public string FiltroEvent
        {
            get { return _filtroEvent; }
            set { _filtroEvent = value;
                NotifyPropretyChanged("FiltroEvent");
                Pagina = 1;
                GetData();
            }
        }

        private string _filtroMedal;

        public string FiltroMedal
        {
            get { return _filtroMedal; }
            set { _filtroMedal = value;
                NotifyPropretyChanged("FiltroMedal");
                Pagina = 1;
                GetData();
            }
        }

        private int _righePagina;

        public int RighePagina
        {
            get { return _righePagina; }
            set { _righePagina = value;
                NotifyPropretyChanged("RighePagina");
                Pagina = 1;
                GetData();
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

        #region BindingUX
        private string _lablePagine;

        public string LabelPagine
        {
            get { return _lablePagine; }
            set { _lablePagine = value;
                NotifyPropretyChanged("LabelPagine");
            }
        }

        private bool _primaEnabled;

        public bool PrimaEnabled
        {
            get { return _primaEnabled; }
            set { _primaEnabled = value;
                NotifyPropretyChanged("PrimaEnabled");
            }
        }

        private bool _avantiEnabled;

        public bool AvantiEnabled
        {
            get { return _avantiEnabled; }
            set { _avantiEnabled = value;
                NotifyPropretyChanged("AvantiEnabled");
            }
        }

        private bool _indietroEnabled;

        public bool IndietroEnabled
        {
            get { return _indietroEnabled; }
            set { _indietroEnabled = value;
                NotifyPropretyChanged("IndietroEnabled");
            }
        }

        private bool _ultimaEnabled;

        public bool UltimaEnabled
        {
            get { return _ultimaEnabled; }
            set { _ultimaEnabled = value;
                NotifyPropretyChanged("UltimaEnabled");
            }
        }
        #endregion

        private int _pagina;

        public int Pagina
        {
            get { return _pagina; }
            set
            {
                _pagina = value;
                //GetData();
                PrimaEnabled = true;
                IndietroEnabled = true;
                AvantiEnabled = true;
                UltimaEnabled = true;
                if (value == 1)
                {
                    PrimaEnabled = false;
                    IndietroEnabled = false;
                }
                if (value == PagineTotali)
                {
                    AvantiEnabled = false;
                    UltimaEnabled = false;
                }
                buildStringLabel();
            }
        }


        private int PagineTotali;



        public void Setup()
        {
            ListaRighePagina = new List<int> { 10, 20, 50 };
            Pagina = 1;
            ListaSex =   Partecipations.GetDistinctList("Sex");
            ListaGames = Partecipations.GetDistinctList("Games");
            ListaMedal = Partecipations.GetDistinctList("Medal");
            RighePagina = 10;

        }

        public void AzzeraFiltri()
        {
            FiltroName = null;
            FiltroSex = null;
            FiltroGames = null;
            FiltroSport = null;
            FiltroEvent = null;
            FiltroMedal = null;
            GetData();
        }

        private void buildStringLabel()
        {
            LabelPagine = "Pagina " + Pagina + " di " + PagineTotali;
        }

        private void GetData()
        {
            ListaPartecipation = Partecipations.GetPartecipations(FiltroName, FiltroSex, FiltroGames, FiltroSport, FiltroEvent, FiltroMedal, Pagina, RighePagina);
            PagineTotali = (int) Partecipations.GetNumberPartecipations(FiltroName, FiltroSex, FiltroGames, FiltroSport, FiltroEvent, FiltroMedal) / RighePagina;
            PagineTotali++;
            buildStringLabel(); 
        }

        public void Avanti()
        {
            Pagina++;
            GetData();
        }

        public void Indietro()
        {
            Pagina--;
            GetData();
        }

        public void Prima()
        {
            Pagina = 1;
            GetData();
        }

        public void Ultima()
        {
            Pagina = PagineTotali;
            GetData();
        }
    }
}
