using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Firmovac.DataDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;

namespace Firmovac.DataDefinitions
{
    public class FirmaCsvMap : ClassMap<Firma>
    {
        public FirmaCsvMap()
        {
            Map(m => m.Id).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.isAktivni).Index(2);
            Map(m => m.Obor.Name).Index(3);
            Map(m => m.Source).Index(4);
            Map(m => m.Note).Index(5);
            Map(m => m.JsonColumns).Index(6);

            Map(m => m.Contact).Convert(row =>
            {
                var contacts = row.Value.Contact;
                return string.Join(", ", contacts.Select(c => $"{c.Name}, {c.Email}, {c.Phone}"));
            }).Index(7);

            Map(m => m.Events).Convert(row =>
            {
                var events = row.Value.Events;
                return string.Join(", ", events.Select(e => $"{e.Name}, {e.EventDate}"));
            }).Index(8);
        }
    }
}
