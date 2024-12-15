using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    // Classe para armazenar as informações de cada usuário
    class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        //Calcular a idade
        public int Idade
        {
            get
            {
                var hoje = DateTime.Today;
                int idade = hoje.Year - DataNascimento.Year;

                // Ajusta a idade caso o aniversário ainda não tenha ocorrido este ano
                if (DataNascimento.Date > hoje.AddYears(-idade))
                    idade--;

                return idade;
            }
        }
    }

    static void Main(string[] args)
    {
        List<Usuario> usuarios = new List<Usuario>();
        string continuar;
        int proximoId = 1;

        Console.WriteLine("=== Sistema de Cadastro de Usuários ===");

        do
        {
            Usuario usuario = new Usuario();
            usuario.ID = proximoId;

            Console.Write("Digite o nome: ");
            usuario.Nome = Console.ReadLine();

            //Validação da data de nascimento.
            bool dataValida = false;
            do
            {
                Console.Write("Digite a data de nascimento (dd/MM/yyyy): ");
                string dataInput = Console.ReadLine();
                dataValida = DateTime.TryParseExact(dataInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataNascimento);

                // Verifica se a data de nascimento não é maior que a data atual
                if (dataValida && dataNascimento <= DateTime.Today)
                {
                    usuario.DataNascimento = dataNascimento;
                }
                else if (dataNascimento > DateTime.Today)
                {
                    Console.WriteLine("Data inválida! A data de nascimento não pode ser maior que a data atual.");
                    dataValida = false;
                }
                else
                {
                    Console.WriteLine("Data inválida. Tente novamente no formato dd/MM/yyyy.");
                    dataValida = false;
                }
            } while (!dataValida);

            //Validação do email.
            bool emailValido = false;
            do
            {
                Console.Write("Digite o e-mail (domínio @mastercoin.com.br): ");
                usuario.Email = Console.ReadLine();

                // Verifica se o e-mail contém o domínio correto e se já foi cadastrado
                if (!string.IsNullOrEmpty(usuario.Email) &&
                     usuario.Email.EndsWith("@mastercoin.com.br") &&
                     !usuarios.Exists(u => u.Email.Equals(usuario.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    emailValido = true;
                }
                else if (usuarios.Exists(u => u.Email.Equals(usuario.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("E-mail já cadastrado! Por favor, use outro e-mail.");
                }
                else
                {
                    Console.WriteLine("E-mail inválido! O e-mail deve pertencer ao domínio @mastercoin.com.br.");
                }
            } while (!emailValido);

            //Validação da senha.
            bool senhaValida = false;
            do
            {
                Console.Write("Digite a senha (mínimo 8 caracteres, incluindo letras, números e caracteres especiais): ");
                usuario.Senha = Console.ReadLine();

                // Valida a senha com Regex
                if (!string.IsNullOrEmpty(usuario.Senha) &&
                    usuario.Senha.Length >= 8 &&
                    Regex.IsMatch(usuario.Senha, @"[A-Za-z]") && // Contém letras
                    Regex.IsMatch(usuario.Senha, @"\d") &&       // Contém números
                    Regex.IsMatch(usuario.Senha, @"[\W_]"))     // Contém caracteres especiais
                {
                    senhaValida = true;
                }
                else
                {
                    Console.WriteLine("Senha inválida! A senha deve ter pelo menos 8 caracteres, incluindo letras, números e caracteres especiais.");
                }
            } while (!senhaValida);

            usuarios.Add(usuario);
            proximoId++;

            Console.Write("Deseja cadastrar outro usuário? (S/N): ");
            continuar = Console.ReadLine();

        } while (continuar?.Trim().ToUpper() == "S");

        Console.WriteLine("\n=== Usuários Cadastrados ===");
        
        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"ID: {usuario.ID}");
            Console.WriteLine($"Nome: {usuario.Nome}");
            Console.WriteLine($"Idade: {usuario.Idade} anos");
            Console.WriteLine("-------------------------------");
        }

        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}

