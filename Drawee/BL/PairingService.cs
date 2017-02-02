using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Drawee.BL
{
    public class PairingService
    {
        public IList<DrawingPair> PairedDrawers { get; private set; }
        public IEnumerable<Drawer> Drawers { get; set; }
        public DateTime LastGeneration { get; set; }
        public string Paste { get; set; }

        private static readonly Lazy<PairingService> instance = new Lazy<PairingService>(() => new PairingService());
        public static PairingService Instance => instance.Value;

        private PairingService()
        {
            //var user = getUser();
            //var lastGeneration = user.GetPastes().OrderByDescending(p => p.Submitted).First();
            //Paste = lastGeneration.Text;
            //LastGeneration = lastGeneration.Submitted;
        }

        public async Task Pair(IEnumerable<Drawer> drawers)
        {
            Drawers = drawers;
            var random = new Random();
            var shuffledList = drawers.OrderBy(d => random.Next()).ToList();

            PairedDrawers = shuffledList.Zip(
                    shuffledList.Skip(1),
                    (d1, d2) => new DrawingPair()
                    {
                        Drawer = d1,
                        Drawee = d2
                    }
                ).ToList();
            PairedDrawers.Add(new DrawingPair()
            {
                Drawer = shuffledList.Last(),
                Drawee = shuffledList.First()
            });

            LastGeneration = DateTime.Now;
          
        }
    }
}