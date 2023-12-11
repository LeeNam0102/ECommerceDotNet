using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Value_Objects
{
    public class Money : IEquatable<Money>
    {
        // Dùng decimal cho tiền tệ vì nó hỗ trợ số thập phân và có độ chính xác cao.
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            // Kiểm tra tham số đầu vào nếu cần thiết.
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be non-negative.", nameof(amount));
            }

            if (string.IsNullOrWhiteSpace(currency))
            {
                throw new ArgumentException("Currency must be specified.", nameof(currency));
            }

            Amount = amount;
            Currency = currency.ToUpper(); // Chuyển đổi sang chữ in hoa để so sánh không phân biệt chữ hoa chữ thường.
        }

        // Override Equals và GetHashCode để có thể so sánh giữa các đối tượng Money.
        public override bool Equals(object obj)
        {
            return Equals(obj as Money);
        }

        public bool Equals(Money other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Amount == other.Amount && Currency == other.Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

        // Override ToString để có thể hiển thị đúng thông tin của đối tượng Money.
        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }

        // Các phương thức tạo mới hoặc thay đổi giá trị của Money có thể được thêm vào nếu cần thiết.
    }
}
