
namespace RPA.Desafio.Fdfalcao.Utils.DBA
{
    public class DadosAcessoBancoModel
    {
        private static string _IPServidor = "localhost";
        public static string IPServidor
        {
            get => _IPServidor;
            private set => _IPServidor = value;
        }

        private static string _BancoNome = "db_desafio_rpa";
        public static string BancoNome
        {
            get => _BancoNome;
            private set => _BancoNome = value;
        }

        private static string _BancoUsuario = "postgres";
        public static string BancoUsuario
        {
            get => _BancoUsuario;
            private set => _BancoUsuario = value;
        }

        private static string _BancoSenha = "sysdba";
        public static string BancoSenha
        {
            get => _BancoSenha;
            set => _BancoSenha = value;
        }

        private static int _BancoPorta = 5432;
        public static int BancoPorta
        {
            get => _BancoPorta;
            private set => _BancoPorta = value;
        }
    }
}
