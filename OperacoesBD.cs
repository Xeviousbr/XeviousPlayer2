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
            tbM.Nome = data.Title;
            tbM.Ano = data.Year == null ? 0 : int.Parse(data.Year);
            tbM.Tempo = data.Duration.Seconds;
            tbM.Ano = int.Parse(data.Year);
            tbM.Banda = data.Artist;
            tbM.SetaGenero(data.Genre);
            tbM.TemImagem = data.Image == null ? 0 : 1;
            tbM.Tamanho = Tam;
            tbM.Lugar = lugar;
            tbM.Nome = Gen.TrataNome(tbM.Nome, tbM.Banda);
            tbM.Adiciona();
        }

    }
}
