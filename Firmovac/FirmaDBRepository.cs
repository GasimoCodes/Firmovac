using Firmovac.DataDefinitions;

namespace Firmovac
{
    public static class FirmaDBRepository
    {

        public static FirmaContact[]? GetContacts(FirmaDbContext dBContext, Firma f)
        {
            return null;
        }

        public static OborDefinition[] GetDefinitions(FirmaDbContext dBContext)
        {
            return dBContext.Obors.ToArray();
        }

        public static FirmaSource[] GetSources(FirmaDbContext dBContext)
        {
            return dBContext.FirmaSources.ToArray();
        }


    }
}
