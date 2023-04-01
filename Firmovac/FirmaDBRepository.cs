using Firmovac.DataDefinitions;
using Microsoft.EntityFrameworkCore;

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

        public static Firma[] getFirmsById(FirmaDbContext dBContext, int[] ids)
        {
            return dBContext.Firms.Where(x => ids.Contains(x.Id)).Include("Obor").Include("Source").Include(q => q.Contact).Include(q => q.Events).ToArray();
        }



    }
}
