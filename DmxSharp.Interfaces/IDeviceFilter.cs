namespace DmxSharp.Interfaces
{
    public interface IDeviceFilter
    {
        bool Active { get; set; }
        IDeviceState<TDevice> Filter<TDevice>(IDeviceState<TDevice> state) where TDevice : IDevice;
    }

    public interface IDeviceFilter<TDevice> : IDeviceFilter where TDevice : IDevice
    {
        IDeviceState<TDevice> Filter(IDeviceState<TDevice> state);
    }
}