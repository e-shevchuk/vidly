using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [StringLength(32)]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 0;
    }
}