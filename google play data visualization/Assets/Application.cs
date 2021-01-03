namespace DefaultNamespace
{
    public class Application
    {
        public string Name { get; set; }
        public CategoriesEnum Category { get; set; }
        public float Rating { get; set; }
        public int Reviews { get; set; }
        public int Installs { get; set; }
        public float Size { get; set; }
        public float Price { get; set; }

        public Application()
        {
            Size = 4;
            Price = 0;
            Installs = 10000;
        }
    }
}