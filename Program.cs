// IHC & UX - Lista 01
// Heurística 1 (Status): Exibe [Passo X de 3] em cada etapa do pedido.
// Heurística 3 (Controle e Liberdade): Permite digitar "voltar" ou "cancelar" a qualquer momento.
// Heurística 9 (Ajuda e Erros): Mensagens específicas quando o código do produto não existe.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, string> produtos = new Dictionary<int, string>()
        {
            {1, "Coxinha"},
            {2, "Pão de Queijo"},
            {3, "Pastel"},
            {4, "Suco"},
            {5, "Refrigerante"},
            {6, "Sanduíche"},
            {7, "Bolo"},
            {8, "Café"},
            {9, "Empada"},
            {10, "Água"}
        };

        int codigoProduto = 0;
        int quantidade = 0;

        while (true)
        {
            // PASSO 1 - Código do Produto
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[Passo 1 de 3] Seleção do Produto");
                Console.WriteLine("Digite o código do produto (1 a 10)");
                Console.WriteLine("Ou digite 'cancelar' para sair:");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar") return;

                if (int.TryParse(entrada, out codigoProduto))
                {
                    if (produtos.ContainsKey(codigoProduto))
                        break;
                    else
                        Console.WriteLine($"\nCódigo {codigoProduto} não encontrado. Nossos códigos vão de 1 a 10. Tente novamente.");
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida. Digite apenas números.");
                }

                Console.ReadKey();
            }

            // PASSO 2 - Quantidade
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[Passo 2 de 3] Quantidade");
                Console.WriteLine($"Produto: {produtos[codigoProduto]}");
                Console.WriteLine("Digite a quantidade desejada:");
                Console.WriteLine("Ou digite 'voltar' para alterar o produto, ou 'cancelar' para sair:");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar") return;
                if (entrada == "voltar") break;

                if (int.TryParse(entrada, out quantidade) && quantidade > 0)
                    goto Confirmacao;
                else
                    Console.WriteLine("\nQuantidade inválida. Digite um número maior que zero.");

                Console.ReadKey();
            }

            continue;

        Confirmacao:
            // PASSO 3 - Confirmação
            Console.Clear();
            Console.WriteLine("[Passo 3 de 3] Confirmação do Pedido");
            Console.WriteLine($"Produto: {produtos[codigoProduto]}");
            Console.WriteLine($"Quantidade: {quantidade}");
            Console.WriteLine("\nConfirmar pedido? (s/n)");
            Console.WriteLine("Ou digite 'voltar' para corrigir, ou 'cancelar' para sair:");

            string confirmacao = Console.ReadLine().ToLower();

            if (confirmacao == "cancelar") return;
            if (confirmacao == "voltar") continue;

            if (confirmacao == "s")
            {
                Console.WriteLine("\nPedido realizado com sucesso!");
                Console.ReadKey();
                return;
            }
        }
    }
}