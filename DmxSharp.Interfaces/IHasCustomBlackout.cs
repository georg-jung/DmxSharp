namespace DmxSharp.Interfaces
{
    public interface IHasCustomBlackout : IDevice
    {
        IDeviceState<IDevice> GetBlackouState();
    }
}