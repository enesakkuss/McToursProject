namespace McTours.VehicleDefinitions
{
    [Flags]
    public enum Utility
    {
        None=0,
        Wifi=1,
        Toilet=2,
        SmartScreen=4,
        Plug=8,
        Hanger=16
    }
}