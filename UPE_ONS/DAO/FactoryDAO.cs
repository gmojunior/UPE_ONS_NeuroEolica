namespace UPE_ONS.DAO
{
    public class FactoryDAO
    {
        private static FactoryDAO instance;

        public CPTECDAO CPTECDAO { get; internal set; }
        public PrevEOLDAO PrevEOLDAO { get; internal set; }
        public ParqueEolicoDAO ParqueEolicoDAO { get; internal set; }
        
        public PotenciaMediaHoraMesDAO PotenciaMediaHoraMesDAO { get; internal set; }
        public PrevisorDAO PrevisorDAO { get; internal set; }
        
        private FactoryDAO()
        {
            this.CPTECDAO = new CPTECDAO();
            this.PrevEOLDAO = new PrevEOLDAO();
            this.PotenciaMediaHoraMesDAO = new PotenciaMediaHoraMesDAO();
            this.ParqueEolicoDAO = new ParqueEolicoDAO();
            this.PrevisorDAO = new PrevisorDAO();
        }

        public static FactoryDAO getInstance()
        {
            if(instance == null)
                instance = new FactoryDAO();
            return instance;
        }        
    }
}