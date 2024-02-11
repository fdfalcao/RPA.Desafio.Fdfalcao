
namespace RPA.Desafio.Fdfalcao.Utils.Dominio.Entidade
{
    public class ResultadoEntidade
    {
        private string _wpm;
        private int _keyStrokes;
        private string _accuracy;
        private int _correctWords;
        private int _wrongWords;

        public ResultadoEntidade(string wpm, int keyStrokes, string accuracy, int correctWords, int wrongWords)
        {
            Wpm = wpm;
            KeyStrokes = keyStrokes;
            Accuracy = accuracy;
            CorrectWords = correctWords;
            WrongWords = wrongWords;
        }

        public string Wpm
        {
            get { return _wpm; }
            set { _wpm = value; }
        }

        public int KeyStrokes
        {
            get { return _keyStrokes; }
            set { _keyStrokes = value; }
        }

        public string Accuracy
        {
            get { return _accuracy; }
            set { _accuracy = value; }
        }

        public int CorrectWords
        {
            get { return _correctWords; }
            set { _correctWords = value; }
        }

        public int WrongWords
        {
            get { return _wrongWords; }
            set { _wrongWords = value; }
        }
    }
}
