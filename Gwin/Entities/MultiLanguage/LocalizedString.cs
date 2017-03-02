using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Gwin.Entities.MultiLanguage
{
    [ComplexType]
    public class LocalizedString
    {
        public string French { get; set; }
        public string English { get; set; }
        public string Arab { get; set; }
        public override string ToString()
        {
            return English;
        }
        [NotMapped]
        public string Current
        {
            get
            {
                switch (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpperInvariant())
                {
                    case "FR":
                        return French;
                    case "EN":
                        return English;
                    case "AR":
                        return Arab;
                }
                return ToString();
            }
            set
            {
                switch (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpperInvariant())
                {
                    case "FR":
                        French = value;
                        break;
                    case "EN":
                        English = value;
                        break;
                    case "AR":
                        Arab = value;
                        break;
                }
            }
        }
    }
}
