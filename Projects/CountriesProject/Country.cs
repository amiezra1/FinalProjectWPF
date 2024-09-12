using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectWPF.CountriesProject
{
    public class Country
    {
        public Name Name { get; set; }
        public string Region { get; set; }
        public long Population { get; set; }

        public List<string> Capital { get; set; }
        public Flag Flags { get; set; }

        public string CapitalDisplay => Capital != null && Capital.Any() ? string.Join(", ", Capital) : "No capital";

        // Choose the PNG version of the flag for display
        public string FlagImageUrl => Flags != null ? Flags.Png : null;
    }

    public class Flag
    {
        public string Png { get; set; }
        public string Svg { get; set; }
    }

    public class Name
    {
        public string Common { get; set; }

        public override string ToString()
        {
            return Common;
        }
    }
}
