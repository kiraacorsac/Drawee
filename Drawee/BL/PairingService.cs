using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drawee.BL
{
    public class PairingService
    {
        private static PairingService instance;
        private PairingService() { }
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

        public void Pair(IEnumerable<Drawer> drawers)
        {
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
        }
    }
}