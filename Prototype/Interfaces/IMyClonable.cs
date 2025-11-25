namespace Prototype.Interfaces
{
    internal interface IMyClonable<T> where T : class
    {
        T MyClone();
    }
}
