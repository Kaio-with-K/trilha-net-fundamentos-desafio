using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ESTACIONAMENTO.models
{
    public class Estacionamento
    {
        private decimal precoInicial { get; set; }
        private decimal precoPorHora { get; set; }
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora) {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo() {
            Console.WriteLine("Digite a placa de um veículo sem traços e sem espaços para continuar: ");
            string placaVeiculo = Console.ReadLine().ToUpper();
            // verifica se possui 7 caracteres
            if (placaVeiculo.Length != 7 ){
                Console.WriteLine("Placa inválida! O tamanho deve ser de 7 caracteres.");
            }
            //verifica se os 3 primeiros caracteres são letras
            else if (!Regex.IsMatch(placaVeiculo.Substring(0,3), "^[A-Z]{3}$")){
                Console.WriteLine("Placa inválida! Os 3 primeiros caracteres devem ser letras");
            }
            //verifica se o 4 caractere é número
            else if (!char.IsDigit(placaVeiculo[3])) {
                Console.WriteLine("Placa inválida! O quarto caractere deve ser um número (0 -9)");
            }
            //verifica se o quinto caracter é letra
            else if(!char.IsLetter(placaVeiculo[4])) {
                Console.WriteLine("Placa inválida! O quinto caracter deve ser uma letra (A-Z)");
            }
            //verifica se os dois últimos caracteres são números
            else if (!Regex.IsMatch(placaVeiculo.Substring(5,2), "^[0-9]{2}$")) {
                Console.WriteLine("Placa inválida! Os dois últimos digitos, devem ser números (0-9)");
            }
            else {
                Console.WriteLine("Placa válida cadastrada");
            }
            veiculos.Add(placaVeiculo);
            Console.WriteLine($"A placa {placaVeiculo} foi adicionada a lista");
        }
        public void RemoverVeiculo() {
            Console.WriteLine("Digite a placa do veículo para remover: ");
            string placaVeiculo = Console.ReadLine().ToUpper();
            if (veiculos.Any(x => x.ToUpper() == placaVeiculo.ToUpper())) {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas);
                Console.WriteLine($"O veículo {placaVeiculo} foi removido e o preço total foi de R$ {valorTotal}");
                veiculos.Remove(placaVeiculo);
            }
            else {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }

        }
        public void ListarVeiculo() {
            if (veiculos.Any()) {
                Console.WriteLine("Os veiculos estacionados aqui são: ");
                foreach (string listaVeiculos in veiculos) {
                    Console.WriteLine(listaVeiculos);
                }
            }
        }
    }
}