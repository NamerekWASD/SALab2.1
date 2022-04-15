namespace SALab2._1.ConsoleMenu.Interfaces
{
    internal interface IMenu<T>
    {
        void RenderOptions();
        T ReadOption();
    }
}
