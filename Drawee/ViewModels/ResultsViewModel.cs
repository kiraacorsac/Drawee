using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;
using Drawee.BL;

namespace Drawee.ViewModels
{
	public class ResultsViewModel : DotvvmViewModelBase
	{
        public string ResultAcessee { get; set; }
        public IEnumerable<Result> Results { get; set; }
        public IEnumerable<Result> SelectiveResults { get; set; }

        public void ComputeSelectiveResults()
        {
            SelectiveResults = Results.Where(r => r.Drawer.Name == ResultAcessee);
        }

        public ResultsViewModel()
        {
            Results = PairingService.Instance.PairedDrawers;
            SelectiveResults = new List<Result>();
        }
        
	}

}

