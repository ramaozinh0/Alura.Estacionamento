using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "André Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";
            
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1490", "preto", "Gol")]
        [InlineData("Ramon Alves", "AWD-1999", "Azul", "Wrx")]
        [InlineData("Douglas Joao", "ADS-1998", "preto", "Palio")]
        [InlineData("Maria dores", "ASD-1440", "Cinza", "EcoSport")]

        public void ValidaFaturamentoComVariosVeiculos(string proprietario,
                                                       string placa, 
                                                       string cor,
                                                       string modelo)
        {

            //Arrange
            Patio Estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            Estacionamento.RegistrarEntradaVeiculo(veiculo);
            Estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = Estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("André Silva", "ASD-1490", "preto", "Gol")]
        public void LocalizaVeiculoNoPatio(
            string proprietario, 
            string placa, 
            string cor, 
            string modelo)
        {
            //Arrange
            Patio estacionamento =  new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario  = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }


    }
}
