using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GApp.GwinApp.Entities.MultiLanguage
{
    [ComplexType]
    public class LocalizedString
    {
        public string French { get; set; }
        public string English { get; set; }
        public string Arab { get; set; }
        public override string ToString()
        {
            return this.Current;
        }
        [NotMapped]
        public string Current
        {
            get
            {
                switch (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpperInvariant())
                {
                    case "FR":
                        if (French != null)
                            return French;
                        else
                            return this.GetCode("FR");
                    case "EN":
                        if (English != null)
                            return English;
                        else
                            return this.GetCode("EN");
                    case "AR":
                        if (Arab != null)
                            return Arab;
                        else
                            return this.GetCode("AR");
                }
                return string.Empty;
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

        private string GetCode(string TwoLetterISOLanguageName)
        {
            if (this.English != null)
                return TwoLetterISOLanguageName + "_" + this.English;
            if (this.French != null)
                return TwoLetterISOLanguageName + "_" + this.French;
            if (this.Arab != null)
                return TwoLetterISOLanguageName + "_" + this.Arab;
            return string.Empty;
        }
    }
}
