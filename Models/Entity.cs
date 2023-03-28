using BASF.MES.Framework.StorageHandlerMD.Models;

namespace ConsoleApp1.Models
{
    internal class Entity
    {
        public Entity(MasterDataEntity dto)
        {           
            this.ProductionEngineerAddress = dto.ProductionEngineerAddress;
             this.Name = dto.Name;
              this.CyclicMessagesEngineerAddress = dto.CyclicMessagesEngineerAddress;
        }

        public string Name { get; set; }

        public string GeneralEngineerAddress { get; set; }

        public string ProductionEngineerAddress { get; set; }

        public string CyclicMessagesEngineerAddress { get; set; }

        public string QualityEngineerAddress { get; set; }

        public string PlantMaintenanceEngineerAddress { get; set; }
    }
}
