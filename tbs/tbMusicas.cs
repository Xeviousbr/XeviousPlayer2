using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XeviousPlayer2
{
    public class tbMusicas
    {
        public int ID { get; set; }
        
        public string Lugar { get; set; }        
        public long Tamanho { get; set; }
        public int Tempo { get; set; }      // Quantidade de segundos
        public int MaxVol { get; set; }     // Não sei se tem como guardar os volumas acho qe sim
        public int TocadoEm { get; set; }
        public int Pular { get; set; }
        public int Pulado { get; set; }
        public int CutIni { get; set; }
        public int CutFim { get; set; }
        public int TemImagem { get; set; }
        public string Nome
        {
            get { return getNome(); }
            set { SetaNome(value); }
        }
        public string Banda
        {
            get { return getBanda(); }
            set { SetaBanda(value); }
        }
        public int Ano
        {
            get { return lcAno; }
            set { SetaAno(value); }
        }

        private int lcAno = 0;
        private int lcBanda = 0;
        private string lcNome = "";
        private string lcNmBanda = "";

        private int SetaAno(int value)
        {
            if (value<1900)
            {
                return 0;
            } else
            {
                // Incluir a musica numa lista de ano, ex. 2000-2009
                // Um grupo de ano, deve apontar para o próximo grupo de ano
                return value;
            }            
        }

        private int SetaBanda(string nome)
        {
            if (nome== "Mp3")
            {
                // Pegar o nome da banda pelo nome
                nome = lcNmBanda;
            } 
            // Pegar o ID da banda e colocar em Banda
            // Se não tem, adicionar e pegar o ID            
            return 0;
        }

        private string getBanda()
        {
            // localiza a banda a partir de lcBanda
            return "";
        }

        public void SetaGenero(string nome)
        {
            // Se não é vazio, deve procurar o estilo em Listas
            int x = 0;
            // Se não tem, cria a lista
            // Incluir a musica na lista
        }

        public string SetaNome(string value)
        {
            // Aqui deve ter críticas relacionadas ao nome
            // "001 - Thom Brennan - Pulse"
            lcNome = value;
            return value;
        }

        private string getNome()
        {
            return lcNome;
        }

        public void Adiciona()
        {
        //            public string Lugar { get; set; }
        //public long Tamanho { get; set; }
        //public int Tempo { get; set; }      // Quantidade de segundos
        //public int MaxVol { get; set; }     // Não sei se tem como guardar os volumas acho qe sim
        //public int TocadoEm { get; set; }
        //public int Pular { get; set; }
        //public int Pulado { get; set; }
        //public int CutIni { get; set; }
        //public int CutFim { get; set; }
        //public int TemImagem { get; set; }
        //private int lcAno = 0;
        //private int lcBanda = 0;
        //private string lcNome = "";

    }

}
}
