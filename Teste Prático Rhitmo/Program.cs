using System;
using System.Collections.Generic;

namespace Estacionamento
{
    // Enum para tipos de veículos
    public enum TipoVeiculo
    {
        Moto,
        Carro,
        Van
    }

    // Classe para representar uma vaga de estacionamento
    public class Vaga
    {
        public TipoVeiculo Tipo { get; set; }
        public bool Ocupada { get; set; }

        public Vaga(TipoVeiculo tipo)
        {
            Tipo = tipo;
            Ocupada = false;
        }
    }

    // Classe para representar o estacionamento
    public class Estacionamento
    {
        private List<Vaga> vagas;

        public Estacionamento(int numVagasMoto, int numVagasCarro, int numVagasVan)
        {
            vagas = new List<Vaga>();

            for (int i = 0; i < numVagasMoto; i++)
            {
                vagas.Add(new Vaga(TipoVeiculo.Moto));
            }

            for (int i = 0; i < numVagasCarro; i++)
            {
                vagas.Add(new Vaga(TipoVeiculo.Carro));
            }

            for (int i = 0; i < numVagasVan; i++)
            {
                vagas.Add(new Vaga(TipoVeiculo.Van));
            }
        }

        // Método para contar vagas restantes
        public int VagasRestantes()
        {
            int count = 0;
            foreach (Vaga vaga in vagas)
            {
                if (!vaga.Ocupada)
                {
                    count++;
                }
            }
            return count;
        }

        // Método para contar vagas totais
        public int VagasTotais()
        {
            return vagas.Count;
        }

        // Método para verificar se o estacionamento está cheio
        public bool EstacionamentoCheio()
        {
            foreach (Vaga vaga in vagas)
            {
                if (!vaga.Ocupada)
                {
                    return false;
                }
            }
            return true;
        }

        // Método para verificar se o estacionamento está vazio
        public bool EstacionamentoVazio()
        {
            foreach (Vaga vaga in vagas)
            {
                if (vaga.Ocupada)
                {
                    return false;
                }
            }
            return true;
        }

        // Método para verificar se um determinado tipo de vaga está cheio
        public bool TipoVagaCheia(TipoVeiculo tipo)
        {
            foreach (Vaga vaga in vagas)
            {
                if (vaga.Tipo == tipo && !vaga.Ocupada)
                {
                    return false;
                }
            }
            return true;
        }

        // Método para contar quantas vagas as vans estão ocupando
        public int VagasVansOcupadas()
        {
            int count = 0;
            foreach (Vaga vaga in vagas)
            {
                if (vaga.Tipo == TipoVeiculo.Van && vaga.Ocupada)
                {
                    count++;
                }
            }
            return count;
        }

        // Método para contar quantas vagas de motos estão ocupadas
        public int VagasMotosOcupadas()
        {
            int count = 0;
            foreach (Vaga vaga in vagas)
            {
                if (vaga.Tipo == TipoVeiculo.Moto && vaga.Ocupada)
                {
                    count++;
                }
            }
            return count;
        }

        // Método para contar quantas vagas de carros estão ocupadas
        public int VagasCarrosOcupadas()
        {
            int count = 0;
            foreach (Vaga vaga in vagas)
            {
                if (vaga.Tipo == TipoVeiculo.Carro && vaga.Ocupada)
                {
                    count++;
                }
            }
            return count;
        }

        // Método para estacionar um veículo
        public bool EstacionarVeiculo(TipoVeiculo tipo)
        {
            foreach (Vaga vaga in vagas)
            {
                if (!vaga.Ocupada && (vaga.Tipo == tipo || (tipo == TipoVeiculo.Carro && vaga.Tipo == TipoVeiculo.Van)))
                {
                    vaga.Ocupada = true;
                    return true;
                }
            }
            return false;
        }

        // Método para liberar uma vaga
        public bool LiberarVaga(TipoVeiculo tipo)
        {
            foreach (Vaga vaga in vagas)
            {
                if (vaga.Tipo == tipo && vaga.Ocupada)
                {
                    vaga.Ocupada = false;
                    return true;
                }
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Estacionamento com 10 vagas para motos, 10 vagas para carros e 5 vagas para vans
            Estacionamento estacionamento = new Estacionamento(10, 10, 5);

            // Teste dos Métodos
            Console.WriteLine("Vagas restantes: " + estacionamento.VagasRestantes());
            Console.WriteLine("Vagas totais: " + estacionamento.VagasTotais());
            Console.WriteLine("Estacionamento cheio: " + estacionamento.EstacionamentoCheio());
            Console.WriteLine("Estacionamento vazio: " + estacionamento.EstacionamentoVazio());
            Console.WriteLine("Vagas de motos cheias: " + estacionamento.TipoVagaCheia(TipoVeiculo.Moto));
            Console.WriteLine("Vagas de vans ocupadas: " + estacionamento.VagasVansOcupadas());
            Console.WriteLine("Vagas de motos ocupadas: " + estacionamento.VagasMotosOcupadas());
            Console.WriteLine("Vagas de carros ocupadas: " + estacionamento.VagasCarrosOcupadas());
            Console.WriteLine("----------------------------");

            // Teste do estacionar alguns veículos
            estacionamento.EstacionarVeiculo(TipoVeiculo.Moto);
            estacionamento.EstacionarVeiculo(TipoVeiculo.Carro);
            estacionamento.EstacionarVeiculo(TipoVeiculo.Van);

            // Teste dos métodos após estacionar veículos
            Console.WriteLine("Vagas restantes: " + estacionamento.VagasRestantes());
            Console.WriteLine("Vagas totais: " + estacionamento.VagasTotais());
            Console.WriteLine("Estacionamento cheio: " + estacionamento.EstacionamentoCheio());
            Console.WriteLine("Estacionamento vazio: " + estacionamento.EstacionamentoVazio());
            Console.WriteLine("Vagas de motos cheias: " + estacionamento.TipoVagaCheia(TipoVeiculo.Moto));
            Console.WriteLine("Vagas de vans ocupadas: " + estacionamento.VagasVansOcupadas());
            Console.WriteLine("Vagas de motos ocupadas: " + estacionamento.VagasMotosOcupadas());
            Console.WriteLine("Vagas de carros ocupadas: " + estacionamento.VagasCarrosOcupadas());
            Console.WriteLine("----------------------------");

            // Teste para liberar algumas vagas
            estacionamento.LiberarVaga(TipoVeiculo.Moto);
            estacionamento.LiberarVaga(TipoVeiculo.Carro);

            // Teste dos métodos após liberar vagas
            Console.WriteLine("Vagas restantes: " + estacionamento.VagasRestantes());
            Console.WriteLine("Vagas totais: " + estacionamento.VagasTotais());
            Console.WriteLine("Estacionamento cheio: " + estacionamento.EstacionamentoCheio());
            Console.WriteLine("Estacionamento vazio: " + estacionamento.EstacionamentoVazio());
            Console.WriteLine("Vagas de motos cheias: " + estacionamento.TipoVagaCheia(TipoVeiculo.Moto));
            Console.WriteLine("Vagas de vans ocupadas: " + estacionamento.VagasVansOcupadas());
            Console.WriteLine("Vagas de motos ocupadas: " + estacionamento.VagasMotosOcupadas());
            Console.WriteLine("Vagas de carros ocupadas: " + estacionamento.VagasCarrosOcupadas());
            Console.WriteLine("----------------------------");
        }
    }
}
