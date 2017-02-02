using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using Drawee.BL;
using Drawee.Controls;

namespace Drawee.ViewModels
{
    public class SetupViewModel : DotvvmViewModelBase
    {
        public bool Enabled { get; set; }
        public static PairingService pair { get; set; } = PairingService.Instance;
        public IList<Drawer> Drawers { get; set; }
        public string NewGuestDrawer { get; set; }
        public DateTime LastGeneration { get; set; } = pair.LastGeneration;

        public SetupViewModel()
        {
            var task = JsonStorageService.Instance.GetDrawersAsync();
            task.Wait();
            Drawers = task.Result;
        }

        public void AddNewGuestDrawer()
        {
            if(Drawers.Select(d => d.Name).Contains(NewGuestDrawer) || string.IsNullOrWhiteSpace(NewGuestDrawer))
            {
                return;
            }
            Drawers.Add(new Drawer(NewGuestDrawer,
                                   "https://i.imgur.com/EHWNFi5.png")
            {
                IsGuest = true
            });

            //PickedDrawers = new List<Drawer>();           //TU
        }

        public void GeneratePairs()
        {
            if (Drawers.Where(d => d.Picked).Count() == 0)
            {
                return;
            }
            pair.Pair(Drawers.Where(d => d.Picked));
            LastGeneration = pair.LastGeneration;
        }

        public void Changed()
        {
            { }
        }
    }
}
