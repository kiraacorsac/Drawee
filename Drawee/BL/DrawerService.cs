using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drawee.BL
{
    public class DrawerService
    {
        private static DrawerService instance;
        private DrawerService() { }
        public static DrawerService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DrawerService();
                }
                return instance;
            }
        }


        public IList<Drawer> GetCommonUsers() //to the filesystem
        {
            return new List<Drawer>{
                new Drawer ("Azhsara",
                            "https://i.imgur.com/7yl8Kt0.png")
                {
                    Refsheet ="https://i.imgur.com/vTJccto.png",
                    InterestingLinks = new[] { "https://www.furaffinity.net/gallery/azsharakletete/" }
                },
                new Drawer ("Werella",
                            "https://i.imgur.com/LnPQh5E.png")
                {
                    Refsheet ="https://i.imgur.com/ye34joK.jpg",
                    InterestingLinks = new[] { "https://www.furaffinity.net/gallery/werella/" }
                },

                new Drawer ("Kiraa",
                            "https://i.imgur.com/JyhKLFJ.jpg")
                {
                    Refsheet = "https://i.imgur.com/lSQcQVd.png",
                    InterestingLinks = new[] { "https://1drv.ms/f/s!An0EFXyDrkpomwviknZOkPgDvZWC" }
                },


                new Drawer ("Mlpard",
                            "https://i.imgur.com/jRrC6ew.png")
                {
                    InterestingLinks = new [] { "https://www.furaffinity.net/gallery/mlpard/" }
                },

                new Drawer ("Rodney",
                            "https://i.imgur.com/CruUd8v.png")
                {
                    InterestingLinks = new[] { "https://www.furaffinity.net/gallery/rodneyfive/" }
                },
                new Drawer ("Blue",
                            "https://i.imgur.com/74oJN6f.jpg")
                {
                    Refsheet = "https://i.imgur.com/yYlwNF9.jpg",
                    InterestingLinks = new [] { "https://www.furaffinity.net/user/bluehoresewolf" }
                },
                new Drawer ("Greyfur",
                            "https://www.furry.cz/users/greyfur/char.jpg")
                {
                    Refsheet = "https://i.imgur.com/lgMYLXo.jpg"
                },
                new Drawer ("Zelus",
                            "https://i.imgur.com/XtZzYul.png"),
                new Drawer ("Mari",
                            "https://i.imgur.com/2Eb1DVD.png") {
                    Refsheet = "https://i.imgur.com/T7fjW7p.png"
                },
            };
        }
    }
}