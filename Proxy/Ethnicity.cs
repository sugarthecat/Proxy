namespace Proxy
{
    internal class Culture
    {
        private string nameBase;

        public Culture()
        {
            nameBase = NameGenerator.getNewName();
        }
    }
}