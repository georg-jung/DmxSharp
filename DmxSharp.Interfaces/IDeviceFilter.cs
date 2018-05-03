namespace DmxSharp.Interfaces
{
    public interface IDeviceFilter<TDevice> where TDevice : IDevice
    {
        IDeviceState<TDevice> Filter(IDeviceState<TDevice> state);
    }
}