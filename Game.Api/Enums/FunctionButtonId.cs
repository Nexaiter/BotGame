using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Api.Enums
{
    public enum FunctionButtonId
    {
        [Description("Add 1 crystal")]
        AddCrystal = 1,
        [Description("Change name")]
        ChangeName = 2,
        [Description("Buy 1 common ticket")]
        BuyCommonTicket = 3,
        [Description("Buy 1 uncommon ticket")]
        BuyUncommonTicket = 4,
        [Description("Buy 1 rare ticket")]
        BuyRareTicket = 5,
        [Description("Buy 1 super rare ticket")]
        BuySuperRareTicket = 6,
        
    }
}
