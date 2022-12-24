namespace lesson1
{
    class Conutry_Capital
    {
        string country;
        string capital;

        public Conutry_Capital(string country, string capital)
        {
            this.country = country;
            this.capital = capital;
        }

        public string Country { get { return country; } set => country = value; }
        public string Capital { get { return capital; } set => capital = value; }
    }
}
