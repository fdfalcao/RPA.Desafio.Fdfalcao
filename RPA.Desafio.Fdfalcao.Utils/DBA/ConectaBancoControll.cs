using Npgsql;

namespace RPA.Desafio.Fdfalcao.Utils.DBA
{
    public class ConectaBancoControll
    {
        private static NpgsqlConnection BancoConnection;

        public static string Conexao()
        {
            try
            {
                string sConecta = "Host=" + DadosAcessoBancoModel.IPServidor +
                    ";Username=" + DadosAcessoBancoModel.BancoUsuario +
                    ";Password=" + DadosAcessoBancoModel.BancoSenha +
                    ";Database=" + DadosAcessoBancoModel.BancoNome +
                    ";Port=" + DadosAcessoBancoModel.BancoPorta;
                BancoConnection = new NpgsqlConnection(sConecta);
                BancoConnection.Open();

                return "Conectado com sucesso;";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string FechaConexao()
        {
            try
            {

                if (BancoConnection != null)
                {
                    BancoConnection.Close();
                    BancoConnection = null;
                }

                return "Conexão fechada com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static bool ExecutaSQL(string sSQL)
        {

            try
            {
                if (BancoConnection == null)
                {
                    Conexao();
                }

                NpgsqlCommand command = new NpgsqlCommand(sSQL, BancoConnection)
                {
                    CommandTimeout = 0
                };

                command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                FechaConexao();
            }
        }
    }
}
