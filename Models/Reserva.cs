namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (Suite != null && Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                throw new Exception("A suite estar com a capacidade inferior a de hospede recebido.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valorSemDesconto = DiasReservados * Suite.ValorDiaria;
            decimal valorFinal = valorSemDesconto; 
            //decimal valor = 0;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (Suite == null)
            
                throw new InvalidOperationException("Suite não foi cadastrada para esta reserva");
                 
            decimal valor = DiasReservados * Suite.ValorDiaria;
            
            //Imprementando os 10% descontto
             if (DiasReservados >= 10)
            {
                decimal desconto = valor * 0.1m;
                decimal valorComDesconto = valor - desconto;
                Console.WriteLine($"Valor sem desconto: {valorSemDesconto:C}");
                Console.WriteLine($"Desconto de 10% ({desconto:C}) aplicado. " +
                    $"Valor final: {valorComDesconto:C}");
                return valorComDesconto;
            }
            else
            {
                Console.WriteLine($"Valor total: {valorSemDesconto:C}");
                Console.WriteLine("Desconto não aplicado, pois a quantidade de dias reservados é menor que 10.");
            }

            return valorFinal;
        }
    }
}