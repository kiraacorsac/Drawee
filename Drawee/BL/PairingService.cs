using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pastebin;
using Newtonsoft.Json;

namespace Drawee.BL
{
    public class PairingService
    {
        private static PairingService instance;
        public static PairingService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PairingService();
                }
                return instance;
            }
        }

        public IList<Result> PairedDrawers { get; private set; }
        public IEnumerable<Drawer> Drawers { get; set; }
        public DateTime LastGeneration { get; set; }
        public string Paste { get; set; }

        private User getUser()
        {
            var pastebin = new Pastebin.Pastebin("");
            return pastebin.LogIn("Kiraa", "");
        }

        private PairingService()
        {
            var user = getUser();
            var lastGeneration  = user.GetPastes().OrderByDescending(p => p.Submitted).First();
            Paste = lastGeneration.Text;
            LastGeneration = lastGeneration.Submitted;
        }

        public void Pair(IEnumerable<Drawer> drawers)
        {
            Drawers = drawers;
            var random = new Random();
            var shuffledList = drawers.OrderBy(d => random.Next()).ToList();

            PairedDrawers = shuffledList.Zip(
                    shuffledList.Skip(1),
                    (d1, d2) => new Result()
                    {
                        Drawer = d1,
                        Drawee = d2
                    }
                ).ToList();
            PairedDrawers.Add(new Result()
            {
                Drawer = shuffledList.Last(),
                Drawee = shuffledList.First()
            });

            LastGeneration = DateTime.Now;
            var generation = JsonConvert.SerializeObject(PairedDrawers);
            var response = getUser().CreatePaste("kokot", "text", generation, PasteExposure.Unlisted);
            
        }
    }
}