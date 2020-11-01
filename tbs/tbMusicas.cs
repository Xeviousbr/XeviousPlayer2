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

        public int Banda { get; set; }
        /* public int Banda
        {
            get { return getBanda(); }
            set { SetaBanda(value); }
        } */
        public string NomeBanda { get; set; }

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

        public int SetaBanda(string bandaTemp)
        {
            bool MusValida = true;
            if (bandaTemp.Length < 3) MusValida = false;
            if (bandaTemp == "Mp3") MusValida = false;
            if (MusValida == false)
            {
                int PosHifen = Nome.IndexOf('-');
                if (PosHifen > -1) 
                {
                    int PosUltHifen = Nome.LastIndexOf('-');
                    if (PosUltHifen!= PosHifen)
                        NomeBanda = Nome.Substring(PosUltHifen+2);
                    else
                        NomeBanda = Nome.Substring(PosHifen+2);
                    
                } 
            } else
            {
                NomeBanda = bandaTemp;
            }
            return 0;
        }

        private string getBanda()
        {
            return lcNmBanda;
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
            try
            {
                using (var cmd = DalHelper.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Musicas(Nome, Lugar, Banda) values (@Nome, @Lugar, @Banda)";
                    cmd.Parameters.AddWithValue("@Nome", Nome);
                    cmd.Parameters.AddWithValue("@Lugar", Lugar);
                    cmd.Parameters.AddWithValue("@Banda", Banda);                    
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            /* tbM.Nome = data.Title;
            tbM.Ano = data.Year == null ? 0 : int.Parse(data.Year);
            tbM.Tempo = data.Duration.Seconds;
            tbM.Ano = int.Parse(data.Year);
            tbM.Banda = data.Artist;
            tbM.SetaGenero(data.Genre);
            tbM.TemImagem = data.Image == null ? 0 : 1;
            tbM.Tamanho = Tam;
            tbM.Lugar = lugar; */

            /* CREATE TABLE "Musicas"(
                "IDMusica"  INTEGER UNIQUE,
                "Nome"  TEXT NOT NULL,
                "Lugar" TEXT NOT NULL,
                "Banda" INTEGER,
                "Tamanho"   INTEGER,
                "BitRate"   INTEGER,
                "Tempo" TEXT,
                "MaxVol"    INTEGER,
                "Equalizacao"   INTEGER,
                "TocadoEm"  TEXT,
                "Unid"  INTEGER,
                "Pular" INTEGER,
                "Pulado"    INTEGER,
                "CutIni"    INTEGER,
                "CutFim"    INTEGER,
                PRIMARY KEY("IDMusica" AUTOINCREMENT)
            ); */

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
