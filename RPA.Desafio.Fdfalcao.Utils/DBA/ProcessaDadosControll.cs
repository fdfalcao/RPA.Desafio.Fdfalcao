using RPA.Desafio.Fdfalcao.Utils.Dominio.Entidade;

namespace RPA.Desafio.Fdfalcao.Utils.DBA
{
    public class ProcessaDadosControll
    {
        public static void InsereResultado(ResultadoEntidade resultado)
        {
            string SQL = "INSERT INTO rpa_resultado ";
            SQL += "(wpm_str, keystrokes_int, accuracy_str, correctwords_int, wrongwords_int) VALUES (";
            SQL += $@"'{resultado.Wpm}', {resultado.KeyStrokes}, '{resultado.Accuracy}', ";
            SQL += $@"{resultado.CorrectWords}, {resultado.WrongWords}); ";

            ConectaBancoControll.ExecutaSQL(SQL);
        }
    }
}
