using System;
using System.Collections.Generic;
using System.Linq; // Necessário para o método .Any()

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            // A lista 'veiculos' já foi inicializada na declaração da variável.
            // this.veiculos = new List<string>(); // Não é estritamente necessário aqui se já inicializado acima
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            string placaDigitada = Console.ReadLine(); // Lê a placa digitada pelo usuário
            veiculos.Add(placaDigitada); // Adiciona a placa à lista de veículos
            Console.WriteLine($"Veículo com placa '{placaDigitada}' adicionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placaParaRemover = Console.ReadLine(); // Armazena a placa digitada para remoção

            // Verifica se o veículo existe
            // O template original usa .Any(), então manterei para resolver o TODO.
            if (veiculos.Any(x => x.ToUpper() == placaParaRemover.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal
                // *IMPLEMENTE AQUI*
                string entradaHoras = Console.ReadLine(); // Lê a entrada de horas como string
                int horas = 0; // Inicializa horas
                decimal valorTotal = 0; // Inicializa valorTotal

                // Converte a entrada de horas para inteiro.
                // ATENÇÃO: Esta conversão pode causar erro se o usuário digitar algo não numérico.
                // Para um projeto básico, assumimos entrada válida.
                try
                {
                    horas = Convert.ToInt32(entradaHoras);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada de horas inválida. Por favor, digite um número inteiro.");
                    return; // Sai do método se a entrada for inválida
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Número de horas muito grande ou muito pequeno para ser processado.");
                    return; // Sai do método se o número for inválido
                }

                // Validação básica para horas não negativas
                if (horas < 0)
                {
                    Console.WriteLine("A quantidade de horas não pode ser negativa. Operação de remoção cancelada.");
                    return;
                }

                valorTotal = precoInicial + (precoPorHora * horas); // Calcula o valor total

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                veiculos.Remove(placaParaRemover); // Remove o veículo da lista

                Console.WriteLine($"O veículo '{placaParaRemover}' foi removido e o preço total foi de: R$ {valorTotal:F2}"); // Formata para 2 casas decimais
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            // O template original usa .Any(), então manterei para resolver o TODO.
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                for (int i = 0; i < veiculos.Count; i++) // Percorre a lista usando um loop for
                {
                    Console.WriteLine($"- {veiculos[i]}"); // Exibe cada veículo da lista
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}