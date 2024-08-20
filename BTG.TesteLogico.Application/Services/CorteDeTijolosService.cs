using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.TesteLogico.Application.Services
{
    public class CorteDeTijolosService
    {
        public int CorteDeTijolos(IList<IList<int>> paredeDeTijolos)
        {
            Dictionary<int, int> contagemDeArestas = ContagemDeArestas(paredeDeTijolos);

            int maximoDeArestas = PosicaoComMaiorNumeroDeArestas(contagemDeArestas);

            int menorNumeroDeTijolosCortados = paredeDeTijolos.Count - maximoDeArestas;

            return menorNumeroDeTijolosCortados;
        }

        private static int PosicaoComMaiorNumeroDeArestas(Dictionary<int, int> contagemDeArestas)
        {
            int maximoDeArestas = 0;

            foreach (var arestas in contagemDeArestas.Values)
            {
                maximoDeArestas = Math.Max(maximoDeArestas, arestas);
            }

            return maximoDeArestas;
        }

        private static Dictionary<int, int> ContagemDeArestas(IList<IList<int>> paredeDeTijolos)
        {
            Dictionary<int, int> contagemDeArestas = [];

            foreach (var linhaDeTijolos in paredeDeTijolos)
            {
                int posicaoDoArray = 0;

                for (int i = 0; i < linhaDeTijolos.Count - 1; i++)
                {
                    posicaoDoArray += linhaDeTijolos[i];
                    if (!contagemDeArestas.TryGetValue(posicaoDoArray, out int value))
                    {
                        value = 0;
                        contagemDeArestas[posicaoDoArray] = value;
                    }
                    contagemDeArestas[posicaoDoArray] = ++value;
                }
            }

            return contagemDeArestas;
        }
    }
}
