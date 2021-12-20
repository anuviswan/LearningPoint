namespace BenchmarkMappers.Poco
{
    public class ComplexObjectDestination
    {
        public int Id { get; set; }

        public IEnumerable<int> Values { get; set; }

        public List<ComplexObjectDestination> ComplexCollection { get; set; }
    }
}
