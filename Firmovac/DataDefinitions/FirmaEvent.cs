namespace Firmovac.DataDefinitions
{
    public class FirmaEvent
    {
        public int Id { get; set; }

        public DateTime EventDate { get; set; }
        

        /// <summary>
        /// Cachovani firmy co event porada
        /// </summary>
        public Firma Porada { get; set; }

    }
}
