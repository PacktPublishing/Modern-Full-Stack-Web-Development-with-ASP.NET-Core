namespace Chapter9.Interfaces
{
    public interface IShipmentService
    {
        bool ShhipmentExists(string shipmentId);
        Task<IShipment> GetShipment(string shipmentId);
    }
}
