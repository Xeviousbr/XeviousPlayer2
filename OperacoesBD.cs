using PVS.MediaPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XeviousPlayer2
{
    public class OperacoesBD
    {
        public void AdicionaNoBD(Metadata data, long Tam, string lugar)
        {
            tbMusicas tbM = new tbMusicas();
            tbM.Nome = getNome(data.Title);
            tbM.Ano = data.Year == null ? 0 : int.Parse(data.Year);
            tbM.Tempo = data.Duration.Seconds;
            tbM.Ano = int.Parse(data.Year);
            tbM.Banda = data.Artist;
            tbM.SetaGenero(data.Genre);
            tbM.TemImagem = data.Image == null ? 0 : 1;
            tbM.Tamanho = Tam;
            tbM.Lugar = lugar;
            tbM.Adiciona();
        }

        private string getNome(string Nome)
        {
            int codLetra = 0;
            string LetrasValidas = "áàéèêâíìîóòôúùüãõç";
            string CaractsInvalidos = " -._(){}&";
            char AspaD = (Char)34;
            char Aspa = (Char)44;
            Nome = RetiraLetras(Nome, CaractsInvalidos);
            Nome = RetiraLetras(Nome, CaractsInvalidos, true);
            Nome = Nome.Replace(AspaD, Aspa);
            for (int a = 0; a < Nome.Length; a++)
            {
                char Letra = Convert.ToChar(Nome[a]);
                codLetra = Convert.ToInt32(Letra);
                if ((codLetra < 32) || (codLetra > 122))
                {
                    if (LetrasValidas.IndexOf(Letra)==-1)
                    {
                        char[] letras = Nome.ToCharArray();
                        letras[a] = '_';
                        Nome = new string(letras);
                    }
                }
            }
            Nome = Nome.Replace(@"/", " ");

            // Verificar se os 3 primeiros caracteres são numericos, se for, retirar
            // Verificar se os 2 primeiros caracteres são numericos, se for, retirar
            if (Nome.Substring(2,2) == "0 ")
                Nome = Nome.Substring(2);

            // Retirar o nome da banda

            return Nome;
        }

        #region Funções que podem ser públicas

        private string RetiraLetras(string Texto, string letras, bool Finais =false)
        {
            bool Sair = false;
            bool Achou = false;
            do
            {
                Achou = false;
                for (int i = 0; i < letras.Length; i++)
                {
                    char Letra = letras[i];
                    if (Finais==false)
                    {
                        if (Texto[1]==Letra)
                        {
                            Texto = Texto.Substring(2);
                            Achou = true;
                        }
                    } else
                    {
                        if (Texto[Texto.Length-1] == Letra)
                        {
                            Texto = Texto.Substring(0, Texto.Length-1);
                            Achou = true;
                        }
                    }
                }
                if (Achou==false)
                    Sair = true;
            } while (Sair==false);            
           return Texto;
        }

        #endregion
    }
}
