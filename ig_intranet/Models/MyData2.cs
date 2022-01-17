
namespace EnumSample.Models
{
    public class MyData2
    {
        public int Id { get; set; }

        public MyEnum Enum11 { get; set; }

        public MyEnum? Enum22 { get; }

        public FlagsEnum FlagsEnum { get; set; }
    }
}