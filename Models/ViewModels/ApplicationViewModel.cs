using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TestI.Models.ViewModels
{
    public class ApplicationViewModel
    {
        public Application Application { get; set; }

        public IEnumerable<SelectListItem> TDDStatus { get; set; }

        public IEnumerable<SelectListItem> TDDClient { get; set; }

        public IEnumerable<SelectListItem> TDDRepair { get; set; }

        public IEnumerable<SelectListItem> TDDMachineTool { get; set; }
    }
}
