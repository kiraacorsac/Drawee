using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;
using Drawee.BL;
using System.IO;

namespace Drawee.ViewModels
{
    public class ResultsViewModel : DotvvmViewModelBase
    {
        public string ResultAcessee { get; set; }
        public DateTime LastGeneration { get; set; }
        public IEnumerable<Drawer> Drawers { get; set; }
        public IEnumerable<Result> Results { get; set; }
        public IEnumerable<Result> SelectiveResults { get; set; }
        public string Filesys { get; set; }
        public int Val { get; set; }
        public string Pastebin { get; set; }
        private PairingService serv;



        public void Write()
        {
            using (var fs = new StreamWriter("lisk"))
            {
                fs.WriteLine("delf");
            }
        }

        [AllowStaticCommand]
        public static int Plusone(int val)
        {
            return 1 + val;
        }

        [AllowStaticCommand]
        public void Read()
        {
            using (var fs = new StreamReader("lisk"))
            {
                Filesys = fs.ReadToEnd();
            }
        }

        public bool PicturesVisible { get; set; }

        public void ComputeSelectiveResults()
        {
            if (Results != null)
            {
                SelectiveResults = Results.Where(
                    r => r.Drawer.Name.ToLower() == ResultAcessee.ToLower()
                    );
            }

        }

        public ResultsViewModel()
        {
            serv = PairingService.Instance;
            LastGeneration = serv.LastGeneration;
            Results = serv.PairedDrawers;
            Drawers = serv.Drawers;
            Pastebin = serv.Paste;
            SelectiveResults = new List<Result>();
        }

    }

}

