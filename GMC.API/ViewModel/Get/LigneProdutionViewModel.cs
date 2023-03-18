namespace GMC.API.ViewModel.Get
{
    public class LigneProductionViewModel
    {
        public string CodeLigneProduction { get; set; }
        public int Etat { get; set; }
        public string Observation { get; set; }
        public string RobotTraitement { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateMaj { get; set; }
        public string Hostname { get; set; }
        public int Boucle { get; set; }
        public int Forced { get; set; }
        public int ProduitForced { get; set; }

    }
}
