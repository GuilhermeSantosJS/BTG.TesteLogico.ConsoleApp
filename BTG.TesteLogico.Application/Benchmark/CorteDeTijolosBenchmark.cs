using BenchmarkDotNet.Attributes;
using BTG.TesteLogico.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.TesteLogico.Application.Benchmark
{
    public class CorteDeTijolosBenchmark
    {

        private CorteDeTijolosService corteDeTijolosService = new();
        private readonly IList<IList<int>> paredePequena;
        private readonly IList<IList<int>> paredeMedia;
        private readonly IList<IList<int>> paredeGrande;

        public CorteDeTijolosBenchmark()
        {
            paredePequena = GerarParede(100);
            paredeMedia = GerarParede(1000);
            paredeGrande = GerarParede(5000);
        }

        private IList<IList<int>> GerarParede(int altura)
        {
            Random rand = new();
            var parede = new List<IList<int>>();

            for (int i = 0; i < altura; i++)
            {
                int largura = 100; 
                var linha = new List<int>();
                while (largura > 0)
                {
                    int comprimento = rand.Next(1, 10);
                    if (comprimento <= largura)
                    {
                        linha.Add(comprimento);
                        largura -= comprimento;
                    }
                }
                parede.Add(linha);
            }

            return parede;
        }

        [Benchmark]
        public int TesteParedePequena()
        {
            return corteDeTijolosService.CorteDeTijolos(paredePequena);
        }

        [Benchmark]
        public int TesteParedeMedia()
        {
            return corteDeTijolosService.CorteDeTijolos(paredeMedia);
        }

        [Benchmark]
        public int TesteParedeGrande()
        {
            return corteDeTijolosService.CorteDeTijolos(paredeGrande);
        }
    }
}
