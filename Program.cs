using System;
using System.Collections.Generic;

namespace DIO.Bank
{
  class Program
  {
    static List<Conta> listContas = new List<Conta>();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarContas();
            break;
          case "2":
            InserirConta();
            break;
          case "3":
            Transferir();
            break;
          case "4":
            Sacar();
            break;
          case "5":
            Depositar();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsuario = ObterOpcaoUsuario();
      }
    }

    private static void Transferir()
    {
      Console.Write("Digite o número da conta de origem: ");
      int indiceContaOrigem = int.Parse(Console.ReadLine());

      Console.Write("Digite o número da conta de destino: ");
      int indiceContaDestino = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser transferido: ");
      double valorTransferencia = double.Parse(Console.ReadLine());

      listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
    }

    private static void Depositar()
    {
      Console.Write("Digite o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser depositado: ");
      double valorDeposito = double.Parse(Console.ReadLine());

      listContas[indiceConta].Depositar(valorDeposito);
    }

    private static void Sacar()
    {
      Console.Write("Digite o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser sacado: ");
      double valorSaque = double.Parse(Console.ReadLine());

      listContas[indiceConta].Sacar(valorSaque);
    }
    private static void ListarContas()
    {
      Console.WriteLine("Listar Contas");
      if (listContas.Count == 0)
      {
        Console.WriteLine("Nenhuma conta cadastrada.");
        return;
      }
      for (int i = 0; i < listContas.Count; i++)
      {
        Conta conta = listContas[i];
        Console.Write("#{0} - ", i);
        Console.WriteLine(conta.Detalhes());
      }
    }

    private static void InserirConta()
    {
      Console.WriteLine("Inserir nova Conta");
      Console.WriteLine("Digite 1 para Conta Pessoa Física ou 2 para Pessoa Juridica: ");

      int entradaTipoConta;

      if(int.TryParse(Console.ReadLine(), out int entrada))
      {
          if(entrada >= 3)
          {
              throw new ArgumentException("Digito incorreto, digite 1 Pessoa Física ou 2 Pessoa Juridica");
          }
          entradaTipoConta = entrada;
      } 
      else
      {
          throw new ArgumentException("Digito incorreto, digite 1 Pessoa Física ou 2 Pessoa Juridica");
      }   

      Console.WriteLine("Digite o Nome do Cliente: ");
      string entradaNome = Console.ReadLine();

      if(entradaNome.Length <= 3)
      {
          throw new ArgumentException("Nome não pode ter menos de 3 caracteres");
      }

      Console.WriteLine("Digite o saldo inicial: ");

      double entradaSaldo;

      if(double.TryParse(Console.ReadLine(), out double saldo))
      {
          entradaSaldo = saldo; 
      } 
      else
      {
          throw new ArgumentException("Valor inválido");
      }

      Console.WriteLine("Digite o crédito: ");
      double entradaCredito;

      if(double.TryParse(Console.ReadLine(), out double credito))
      {
          entradaCredito = credito; 
      } 
      else
      {
          throw new ArgumentException("Valor inválido");
      }

      Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

      listContas.Add(novaConta);
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine("1- Listar contas");
      Console.WriteLine("2- Inserir nova conta");
      Console.WriteLine("3- Transferir");
      Console.WriteLine("4- Sacar");
      Console.WriteLine("5- Depositar");
      Console.WriteLine("C- Limpar tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
