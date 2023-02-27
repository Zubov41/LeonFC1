using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeonFC.DataBase;
using LeonFC.Windows;

namespace LeonFC.ClassHelper
{
        public class EFClass
        {
            public static FitnesClubLeonEntities1 context { get; set; } = new FitnesClubLeonEntities1();
        }
}