using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Manager_Mobile.Data
{
    public class MeterViewModels
    {
        
        public ObservableCollection<MeterModels> EquipamentModels { get; set; }
        public MeterViewModels()
        {
            EquipamentModels = new ObservableCollection<MeterModels>();
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROT ESTENDIDA G100 160M3/H 3\" FL 150", ID = 0 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROT ESTENDIDA G40 65M3/H 2\" FL 150", ID = 1 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROT Estendida G65 100M3/H 2\"", ID = 2 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROT ESTENDIDA G65 100M3/H 2\" FL 150#", ID = 3 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G100 160M3/H 2\" FL 125#", ID = 4 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G100 160M3/H 3\" FL 150#", ID = 6 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G100 160M3/H 3\" FL 300#", ID = 7 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G16 25M3/H 1-1/2\" BSP", ID = 8 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G160 250M3/H 3\" FL 150#", ID = 9 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G160 250M3/H 3\" FL 300#", ID = 10 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G25 40M3/H 1-1/2\" BSP", ID = 11 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G25 40M3/H 1-1/2\" FL", ID = 12 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G25 40M3/H 1-1/2\" FL 150#", ID = 13 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G25 40M3/H 2\" FL 150#", ID = 14 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G250 400M3/H 4\" FL 150#", ID = 15 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G40 65M3/H 1-1/2\" BSP", ID = 16 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G40 65M3/H 2\" FL", ID = 17 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G40 65M3/H 2\" FL 150#", ID = 18 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G400 650M3/H 4\" FL 150#", ID = 19 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G65 100M3/H 2\" FL", ID = 20 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G65 100M3/H 2\" FL 150#", ID = 21 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G65 100M3/H 2\" FL 300#", ID = 22 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA  G100 160M3/H 3\" FL 150#", ID = 23 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G1000 1600M3/H 6\" FL 150#", ID = 24 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G1000 1600M3/H 8\" FL 125#", ID = 25 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G1000 1600M3/H 8\" FL 300#", ID = 26 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G160 250M3/H 3\" FL 125#", ID = 27 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G160 250M3/H 3\" FL 150#", ID = 28 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G160 250M3/H 4\" FL 150#", ID = 29 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G1600 2500M3/H 10\" FL 125#", ID = 30 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G1600 2500M3/H 10\" FL 150#", ID = 31 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G1600 2500M3/H 8\" FL 150#", ID = 32 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G1600 2500M3/H 8\" FL 300#", ID = 33 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G1600 2500M3/H 8\"300#", ID = 34 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G250 400M3/H 3\" FL 125#", ID = 35 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G250 400M3/H 3\" FL 150#", ID = 36 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G250 400M3/H 4\" FL", ID = 37 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G250 400M3/H 4\" FL 150#", ID = 38 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G2500 4000M3/H 12\" FL 125#", ID = 39 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G2500 4000M3/H 12\" FL 150#", ID = 40 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G400 650M3/H 4\" FL 125#", ID = 41 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G400 650M3/H 4\" FL 150#", ID = 42 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G400 650M3/H 6\" FL 125#", ID = 43 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G65 100M3/H 2\" FL 150#", ID = 44 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G650 1000M3/H 6\" FL 125#", ID = 45 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G650 1000M3/H 6\" FL 150#", ID = 46 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURNINA G650 1000M3/H 6\" FL 125#", ID = 47 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MEDIDOR FLEX FLOW DN4\" #150", ID = 48 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G16 25M3/H 1-1/2\" FL 125#", ID = 49 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED ROTATIVO G25 40M3/H 1-1/2\" ", ID = 50 });
            this.EquipamentModels.Add(new MeterModels() { Name = "MED TURBINA G1000 1600M3/H 8\"300#", ID = 51 });

        }
    
    }
}
