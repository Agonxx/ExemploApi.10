namespace Exemplo.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string? value)
        {
            return string.IsNullOrWhiteSpace(value);
        }


        public static bool IsCpfValid(this string? cpf)
        {
            // validação simplificada ou completa depois
            return true;
        }
    }

}
