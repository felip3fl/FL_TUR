using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FL_TUR.Model
{
    public class Sorteio
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("numero_concurso")]
        public long NumeroConcurso { get; set; }

        [JsonProperty("data_concurso")]
        public DateTimeOffset DataConcurso { get; set; }

        [JsonProperty("data_concurso_milliseconds")]
        public long DataConcursoMilliseconds { get; set; }

        [JsonProperty("local_realizacao")]
        public string LocalRealizacao { get; set; }

        [JsonProperty("rateio_processamento")]
        public bool RateioProcessamento { get; set; }

        [JsonProperty("acumulou")]
        public bool Acumulou { get; set; }

        [JsonProperty("valor_acumulado")]
        public long ValorAcumulado { get; set; }

        [JsonProperty("dezenas")]
        public string[] Dezenas { get; set; }

        [JsonProperty("premiacao")]
        public Premiacao[] Premiacao { get; set; }

        [JsonProperty("local_ganhadores")]
        public LocalGanhadore[] LocalGanhadores { get; set; }

        [JsonProperty("arrecadacao_total")]
        public long ArrecadacaoTotal { get; set; }

        [JsonProperty("data_proximo_concurso")]
        public DateTimeOffset DataProximoConcurso { get; set; }

        [JsonProperty("data_proximo_concurso_milliseconds")]
        public long DataProximoConcursoMilliseconds { get; set; }

        [JsonProperty("valor_estimado_proximo_concurso")]
        public long ValorEstimadoProximoConcurso { get; set; }

        [JsonProperty("valor_acumulado_especial")]
        public double ValorAcumuladoEspecial { get; set; }

        [JsonProperty("nome_acumulado_especial")]
        public string NomeAcumuladoEspecial { get; set; }
    }

    public partial class LocalGanhadore
    {
        [JsonProperty("local")]
        public string Local { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("quantidade_ganhadores")]
        public long QuantidadeGanhadores { get; set; }

        [JsonProperty("canal_eletronico")]
        public bool CanalEletronico { get; set; }
    }

    public partial class Premiacao
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("quantidade_ganhadores")]
        public long QuantidadeGanhadores { get; set; }

        [JsonProperty("valor_total")]
        public double ValorTotal { get; set; }

        [JsonProperty("acertos")]
        public long Acertos { get; set; }
    }
}
