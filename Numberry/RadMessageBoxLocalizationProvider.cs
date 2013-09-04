using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls;

namespace Numberry
{
    public class RadMessageBoxLocalizationProvider : RadMessageLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadMessageStringID.AbortButton: return "Прервать";
                case RadMessageStringID.CancelButton: return "Отмена";
                case RadMessageStringID.IgnoreButton: return "Игнорировать";
                case RadMessageStringID.NoButton: return "Нет";
                case RadMessageStringID.OKButton: return "OK";
                case RadMessageStringID.RetryButton: return "Повторить";
                case RadMessageStringID.YesButton: return "Да";
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
}
