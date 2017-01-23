using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using Drawee.BL;

namespace Drawee.ViewModels
{
    public class SetupViewModel : DotvvmViewModelBase
    {

        public IList<Drawer> Drawers { get; set; }
        public string NewGuestDrawer { get; set; } 
        public IList<Drawer> PickedDrawers { get; set; }
        public DateTime LastGeneration { get; set; }

        public SetupViewModel()
        {
            Drawers = DrawerService.Instance.GetCommonUsers();

            PickedDrawers = new List<Drawer>();
        }

        public void AddNewGuestDrawer()
        {
            Drawers.Add(new Drawer(NewGuestDrawer, new List<string>(), true));
            //PickedDrawers = new List<Drawer>();           //TU
        }

        public void GeneratePairs()
        {
            var pairService = PairingService.Instance;
            pairService.Pair(PickedDrawers);
        }

    }
}
