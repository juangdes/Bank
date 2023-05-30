namespace CPF
{
    public class Cpf
    {
        public bool IsCpfValid(string cpf)
        {
            // Remove caracteres não numéricos do CPF
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF possui 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos do CPF são iguais (ex.: 111.111.111-11)
            if (cpf.Distinct().Count() == 1)
                return false;

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int resto = soma % 11;
            int dv1 = resto < 2 ? 0 : 11 - resto;

            // Verifica o primeiro dígito verificador
            if (int.Parse(cpf[9].ToString()) != dv1)
                return false;

            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            resto = soma % 11;
            int dv2 = resto < 2 ? 0 : 11 - resto;

            // Verifica o segundo dígito verificador
            if (int.Parse(cpf[10].ToString()) != dv2)
                return false;

            // CPF válido
            return true;
        }

        public static void Main()
        {
            
        }
    }
}